using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Office365.Discovery;
namespace o365ApiTester
{
   public partial class Form1 : Form
   {
      private AuthenticationResult discoveryResult;
      private AuthenticationResult graphApiResult;
      private AuthenticationResult oneDriveApiResult;
      private static readonly AuthenticationContext authContext =
            new AuthenticationContext( ConfigurationManager.AppSettings[ "ida:AADInstance" ] );
      
      public Form1()
      {
         InitializeComponent();
      }

      private void Form1_Load( object sender, EventArgs e )
      {
         
         DiscoveryClient discoveryClient = new DiscoveryClient(async() =>
                                                                           {
                                                                             authContext.AcquireToken( "https://api.office.com/discovery/",  )
                                                                           });
      }
   }
}
