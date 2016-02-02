using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;
using o365.FileHandler.OneDriveApi.Helper;
using Form = System.Windows.Forms.Form;

namespace o365ApiTester
{
   public partial class GetBySharepointId : Form
   {

      private string _orginalFileGetUrl;
      private Guid _fileGuid;
      
      public Task<string> DrivesApiCall
      {
         get;
         private set;
      }
      public GetBySharepointId()
      {
         InitializeComponent();
      }

      private void GetBySharepointId_Load( object sender, EventArgs e )
      {
      }

      private void button1_Click( object sender, EventArgs e )
      {
         var spFileGetUri = new SharePointOnlineUri( _orginalFileGetUrl );
         var authResult = Program.authContext.AcquireToken( spFileGetUri.GetSharePointResourceIdFromFileHandlerGetPutUri(), SiteSettings.ClientId, new Uri( SiteSettings.RedirectUrl ) );
         DrivesApiCall = spFileGetUri.GetDrivesApiCallForSelectedFile( authResult );
      }

      private void txtFileGetUrl_TextChanged( object sender, EventArgs e )
      {
         _orginalFileGetUrl = txtFileGetUrl.Text;
         btnOk.Enabled = Uri.IsWellFormedUriString( _orginalFileGetUrl, UriKind.Absolute );
      }
   }
}
