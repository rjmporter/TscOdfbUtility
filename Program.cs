using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens;
using adalAuthContext = Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationContext;
using TechSmith.Custom.SharePoint;
using Microsoft.SharePoint.Client;
using System.Diagnostics;
using System.Configuration;

namespace ConsoleApplication1
{
   class Program
   {
      static void Main( string[] args )
      {

         var oneDriveResourceId = ConfigurationManager.AppSettings[ "oneDriveResourceId" ];
         var oneDriveApiEndpoint = ConfigurationManager.AppSettings[ "oneDriveApiEndpoint" ];
         var graphResourceId = ConfigurationManager.AppSettings[ "graphResourceId" ];
         var graphApiEndpoint = ConfigurationManager.AppSettings[ "graphApiEndpoint" ];

         adalAuthContext authctx = new adalAuthContext( "https://login.microsoftonline.com/common", false );
         var oneDriveTokenResponse = authctx.AcquireToken( oneDriveResourceId, "17f3b8e2-7365-4f52-bae7-a2dd70310cdf", new Uri( "http://localhost/eb2c041088c22f67fecaffda29528308" ) );
         var graphTokenResponse = authctx.AcquireToken( graphResourceId, "17f3b8e2-7365-4f52-bae7-a2dd70310cdf", new Uri( "http://localhost/eb2c041088c22f67fecaffda29528308" ) );
         do
         {
            Console.WriteLine();
            Console.WriteLine( "Enter API call" );
            var call = Console.ReadLine();

            Console.WriteLine( "Choose an Option" );
            Console.WriteLine( "1. Call with OneDrive api" );
            Console.WriteLine( "2. Call with Graph api" );

            string apiCall = "";
            string authHeader = "";
            Task tApiCall=null;
            var api = int.Parse( Console.ReadLine() );
            switch ( api )
            {
               case 1:
                  apiCall = oneDriveApiEndpoint + call.Trim( '/' );
                  authHeader = oneDriveTokenResponse.CreateAuthorizationHeader();
                  break;
               case 2:
               default:

                  authHeader = graphTokenResponse.CreateAuthorizationHeader();
                  apiCall = graphApiEndpoint + call.Trim( '/' );

                  break;
            }
            try
            {
               tApiCall = GetApiResponse( authHeader, apiCall );
            }
            catch ( WebException webEx )
            {
               switch ( webEx.Status )
               {
                  case WebExceptionStatus.ProtocolError:
                     oneDriveTokenResponse = authctx.AcquireToken( oneDriveResourceId );
                     graphTokenResponse = authctx.AcquireToken( graphResourceId );
                     Console.WriteLine( webEx.ToString() );
                     break;
                  default:
                     throw;
               }
            }
            catch ( Exception ex )
            {
               Console.WriteLine( ex.ToString() );
            }
            tApiCall?.Wait();
         } while ( !GetContinueResponse() );

         Console.ReadLine();
      }
      private static async Task GetApiResponse( string authHeader, string apiCall )
      {
         using ( WebClient wc = new WebClient() )
         {
            wc.Headers.Add( "Authorization", authHeader );
            var wcReply = await wc.DownloadStringTaskAsync( apiCall );
            
            var jobj = JObject.Parse( wcReply );
            Console.WriteLine( jobj.ToString( Formatting.Indented ) );
         }
      }
      private static bool GetContinueResponse()
      {
         Console.Write( "Try again? (Y/N)" );
         ConsoleKey key;
         string response = Console.ReadLine();
         Enum.TryParse( response?.ToCharArray()[ 0 ].ToString(), out key );
         bool isDone = key == ConsoleKey.Y;
         return isDone;
      }

      private struct FilesApiInfo
      {
         public string UserName;
         public string ListRelativeUrl;
      }
      private static FilesApiInfo GetInfo( ClientContext ctx, string guid )
      {
         FilesApiInfo retVal;

         var file = ctx.Web.GetFileById( Guid.Parse( guid ) );
         var listFolder = file.ListItemAllFields.ParentList.RootFolder;
         var query = new CamlQuery();
         var userResult = ctx.LoadQuery( ctx.Web.SiteUserInfoList.GetItems( query ) ).Where( u => ( bool )u.FieldValues[ "IsSiteAdmin" ] );
         ctx.Load( file );
         ctx.Load( listFolder );
         ctx.ExecuteQuery();

         retVal.UserName = userResult.FirstOrDefault().FieldValues[ "UserName" ].ToString();
         retVal.ListRelativeUrl = file.ServerRelativeUrl.Replace( listFolder.ServerRelativeUrl, "" ).TrimStart( '/' );

         return retVal;

      }


   }
   public static class AuthContextExtentions
   {
      public static AuthenticationResult AcquireToken( this adalAuthContext ctx, string resourceId )
      {
         return ctx.AcquireToken( resourceId, "17f3b8e2-7365-4f52-bae7-a2dd70310cdf", new Uri( "http://localhost/eb2c041088c22f67fecaffda29528308" ) );
      }
   }
}
