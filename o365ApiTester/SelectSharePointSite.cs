using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.Search.Query;
using Form = System.Windows.Forms.Form;

namespace o365ApiTester
{
   public partial class SelectSharePointSite : System.Windows.Forms.Form
   {
      private ClientContext _ctx;
      public string SharePointRootSite
      {
         get
         {
            return _ctx?.Url??"";
         }
         set
         {
            _ctx = this.GetSharePointContext( value );
         }
      }
      public string SelectedSite{get;set;}
      public SelectSharePointSite()
      {
         InitializeComponent();

      }

      private void SelectSharePointSite_Load( object sender, EventArgs e )
      {
         if ( _ctx == null )
         {
            throw new ArgumentException( "You must set the SharePoint RootSite Url before opening this form." );
         }
         KeywordQuery kwq = new KeywordQuery( _ctx )
         {
            QueryText = "contentclass =\"STS_Web\" OR contentclass=\"STS_Site\""
         };
         SearchExecutor seExecute = new SearchExecutor( _ctx );
         var results = seExecute.ExecuteQuery( kwq );
         _ctx.ExecuteQuery();
         lstSharePointSites.DisplayMember = "SiteName";
         lstSharePointSites.ValueMember = "Path";
         lstSharePointSites.DataSource = ( from r in results.Value[ 0 ].ResultRows
                                           where
                                                 !r[ "Author" ].ToString().Equals( "System Account" )
                                                 && !string.IsNullOrEmpty( r[ "Author" ].ToString() )
                                                 && !r[ "Path" ].ToString().Contains( "-my" )
                                           select new
                                           {
                                              SiteName = r[ "Title" ] + " -|- " + r[ "Author" ],
                                              Path = r[ "Path" ]
                                           } ).ToArray();
         this.Closed += ( s, args ) =>
         {
            _ctx.Dispose();
         };

      }

      private void lstSharePointSites_SelectedIndexChanged( object sender, EventArgs e )
      {
         SelectedSite = lstSharePointSites.SelectedValue.ToString();
      }
   }

   public static class SharePointExtentions
   {
      private static ClientContext _ctx;
      public static ClientContext GetSharePointContext( this Form form, string value )
      {
         if ( value.Equals( _ctx?.Url, StringComparison.OrdinalIgnoreCase ) )
            return _ctx;
         _ctx = new ClientContext( value );
         _ctx.ExecutingWebRequest += ( sender, args ) =>
         {
            var result = Program.authContext.AcquireToken( value, SiteSettings.ClientId, new Uri( SiteSettings.RedirectUrl ) );
            args.WebRequestExecutor.RequestHeaders.Add( "Authorization", result.CreateAuthorizationHeader() );
         };
         return _ctx;
      }
   }
}
