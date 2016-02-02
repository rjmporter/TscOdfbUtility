using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.SharePoint.Client;
using Newtonsoft.Json.Linq;

namespace o365.FileHandler.OneDriveApi.Helper
{
   public class SharePointOnlineUri : Uri
   {
      public SharePointOnlineUri( string url ) : base( url )
      {
      }
   }
   public static class SharePointOnlineUriExtentions
   {
      public static string GetSharePointResourceIdFromFileHandlerGetPutUri( this SharePointOnlineUri fileHandlerGetPutUri )
      {
         return string.IsNullOrWhiteSpace( fileHandlerGetPutUri.PathAndQuery.Trim( '/' ) ) ?
                  fileHandlerGetPutUri.AbsoluteUri :
                  fileHandlerGetPutUri.AbsoluteUri.Replace( fileHandlerGetPutUri.PathAndQuery, string.Empty );
      }
      public static async Task<string> GetDrivesApiCallForSelectedFile( this SharePointOnlineUri fileHandlerFileGetOrPutUri, Guid FileHandlerFileId, AuthenticationResult SharepointAdalAuthResult )
      {
         using ( var context = new ClientContext( fileHandlerFileGetOrPutUri.GetSharePointWebUrlFromFileHandlerGetPutUri() ) )
         {
            context.ExecutingWebRequest += ( sender, e ) =>
                                       {
                                          e.WebRequestExecutor.RequestHeaders.Add( "Authorization", SharepointAdalAuthResult.CreateAuthorizationHeader() );
                                       };

            var webRequestUrl = await Task.Run( () =>
                                       {
                                          return GetSharePointMetaData( context, FileHandlerFileId );
                                       } );

            JObject oneDriveResult = await Task.Run( async () =>  
                                       {
                                          string result = string.Empty;
                                          using ( var request = new WebClient() )
                                          {
                                             request.Headers.Add( "Authorization", SharepointAdalAuthResult.CreateAuthorizationHeader() );
                                             result = await request.DownloadStringTaskAsync( webRequestUrl );
                                          }
                                          return JObject.Parse( result );
                                       } );

            var driveId = oneDriveResult["parentReference"]["driveId"].ToString();
            var itemId = oneDriveResult["id"].ToString();

            return $"drives/{driveId}/items/{itemId}";

         }
      }
      public static async Task<string> GetDrivesApiCallForSelectedFile( this SharePointOnlineUri fileHandlerFileGetOrPutUri, AuthenticationResult SharepointAdalAuthResult )
      {
         Guid fileHandlerFileId;
         System.Text.RegularExpressions.Regex findGuid = new System.Text.RegularExpressions.Regex( ".+/files/(?<fileGuid>[A-Fa-f0-9]+)/.*" );
         var match = findGuid.Match( fileHandlerFileGetOrPutUri.PathAndQuery ).Groups["fileGuid"].Value;
         if ( Guid.TryParse( match, out fileHandlerFileId ) )
         {
            return await GetDrivesApiCallForSelectedFile( fileHandlerFileGetOrPutUri, fileHandlerFileId, SharepointAdalAuthResult );
         }
         else
         {
            throw new ArgumentException( "Could not locate a GUID in the fileGetOrPutUri" );
         }
      }
      private static string GetSharePointMetaData( ClientContext ctx, Guid fileGuid )
      {
         var web = ctx.Web;
         var file = web.GetFileById( fileGuid );
         var list = file.ListItemAllFields.ParentList;
         var rootFolder = list.RootFolder;
         ctx.Load( file, f => f.ServerRelativeUrl );
         ctx.Load( rootFolder, rf => rf.ServerRelativeUrl );
         ctx.ExecuteQuery();
         var webUrl = new Uri( ctx.Url );

         var listRelativeUrl = file.ServerRelativeUrl.Replace( rootFolder.ServerRelativeUrl, "" );
         var apiFilePath = "drive/root:/" + listRelativeUrl.Trim( '/' );
         var apiEndpoint = webUrl.AbsoluteUri.TrimEnd( '/' ) + "/_api/v2.0";

         return apiEndpoint + "/" + apiFilePath + "?$select=id,parentReference";
      }
      private static SharePointOnlineUri GetSharePointWebUrlFromFileHandlerGetPutUri( this SharePointOnlineUri fileHandlerGetOrPutUri )
      {
         string absoluteUri = fileHandlerGetOrPutUri.AbsoluteUri;
         return new SharePointOnlineUri( absoluteUri.Substring( 0, absoluteUri.IndexOf( "/_vti_bin" ) ) );
      }

   }
}
