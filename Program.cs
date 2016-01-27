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
      [STAThread]
      static void Main(string[] args)
      {

         var oneDriveResourceId = ConfigurationManager.AppSettings["oneDriveResourceId"];
         var oneDriveApiEndpoint = ConfigurationManager.AppSettings["oneDriveApiEndpoint"];
         var graphResourceId = ConfigurationManager.AppSettings["graphResourceId"];
         var graphApiEndpoint = ConfigurationManager.AppSettings["graphApiEndpoint"];

         adalAuthContext authctx = new adalAuthContext("https://login.microsoftonline.com/common", false);
         var result1 = authctx.AcquireToken(oneDriveResourceId, "17f3b8e2-7365-4f52-bae7-a2dd70310cdf", new Uri("http://localhost/eb2c041088c22f67fecaffda29528308"));
         var token1 = result1.AccessToken;

         var result2 = authctx.AcquireToken(graphResourceId, "17f3b8e2-7365-4f52-bae7-a2dd70310cdf", new Uri("http://localhost/eb2c041088c22f67fecaffda29528308"));
         var token2 = result2.AccessToken;

         do {
            Console.WriteLine();
            Console.WriteLine("Enter API call");
            var call = Console.ReadLine();

            Console.WriteLine("Choose an Option");
            Console.WriteLine("1. Call with OneDrive api");
            Console.WriteLine("2. Call with Graph api");

            string apiCall = "";
            string authHeader = "";


            var api = int.Parse(Console.ReadLine());
            switch (api)
            {
               case 1:
                  apiCall = oneDriveApiEndpoint + call.Trim('/');
                  authHeader = result1.CreateAuthorizationHeader();
                  break;
               case 2:
               default:

                  authHeader = result2.CreateAuthorizationHeader();
                  apiCall = graphApiEndpoint + call.Trim('/');

                  break;
            }
            try
            {
               using (WebClient wc = new WebClient())
               {

                  wc.Headers.Add("Authorization", authHeader);
                  var response = wc.DownloadString(apiCall);
                  var jobj = JObject.Parse(response);
                  Console.WriteLine(jobj.ToString(Formatting.Indented));

               }
            } 
            catch (Exception ex) {
               Console.WriteLine(ex.ToString());
            }
            Console.Write("Try again? (Y/N)");
         } while (Console.ReadKey().Key == ConsoleKey.Y);
            //DesktopSharePointContextFactory factory = new DesktopSharePointContextFactory();
            //var ctx = factory.GetContext("https://tscdev-my.sharepoint.com/personal/test_o365_tsc-dev_co/");
            //var guid = "21ba344da9274a04bc8093d891f6974e";
            //var info = GetInfo(ctx, guid);

            //Console.WriteLine("user: {0}\n\nfilename:{1}", info.UserName, info.ListRelativeUrl);
         }
            
         

      private struct FilesApiInfo
      {
         public string UserName;
         public string ListRelativeUrl;
      }
      private static FilesApiInfo GetInfo(ClientContext ctx, string guid)
      {
         FilesApiInfo retVal;

         var file = ctx.Web.GetFileById(Guid.Parse(guid));
         var listFolder = file.ListItemAllFields.ParentList.RootFolder;
         var query = new CamlQuery();
         var userResult = ctx.LoadQuery(ctx.Web.SiteUserInfoList.GetItems(query)).Where(u => (bool)u.FieldValues["IsSiteAdmin"]);
         ctx.Load(file);
         ctx.Load(listFolder);
         ctx.ExecuteQuery();

         retVal.UserName = userResult.FirstOrDefault().FieldValues["UserName"].ToString();
         retVal.ListRelativeUrl = file.ServerRelativeUrl.Replace(listFolder.ServerRelativeUrl, "").TrimStart('/');

         return retVal;

      }

   }
}
