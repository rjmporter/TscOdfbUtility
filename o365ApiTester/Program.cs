using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json.Linq;

namespace o365ApiTester
{
   internal static class Program
   {
      internal static readonly AuthenticationContext authContext =
         new AuthenticationContext( SiteSettings.Authority );
      internal static JObject JSONResponse( string url, HttpMethod method, AuthenticationResult authResult, string apiPayload = "" )
      {
         HttpWebRequest webClientRequest;
         webClientRequest = WebRequest.CreateHttp( new Uri( url ) );
         webClientRequest.Method = method.ToString();
         webClientRequest.Headers.Add( "Authorization", authResult.CreateAuthorizationHeader() );
         if ( method != HttpMethod.Get )
         {
            using ( var writer = new StreamWriter( webClientRequest.GetRequestStream() ) )
            {
               writer.Write( apiPayload );

            }
         }
         WebResponse response;
         JObject jsonResponse = null;
         try
         {
            response = webClientRequest.GetResponse();
         }
         catch ( WebException webEx )
         {
            response = webEx.Response;
         }
         using ( var reader = new StreamReader( response.GetResponseStream() ) )
         {
            jsonResponse = JObject.Parse( reader.ReadToEnd() );
         }
         return jsonResponse;
      }
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault( false );
         Application.Run( new Form1() );
      }
   }
}
