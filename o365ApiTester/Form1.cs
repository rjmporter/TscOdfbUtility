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
      private List<KeyValuePair<string, CapabilityDiscoveryResult>> discoveryResults;
      private AuthenticationResult graphApiResult;
      private AuthenticationResult oneDriveApiResult;
      private static readonly AuthenticationContext authContext =
            new AuthenticationContext( SiteSettings.Authority );
      private CapabilityDiscoveryResult selectedService;

      public Form1()
      {
         InitializeComponent();
         discoveryResults = new List<KeyValuePair<string, CapabilityDiscoveryResult>>();
      }

      private async void Form1_Load( object sender, EventArgs e )
      {
         
         DiscoveryClient discoveryClient = new DiscoveryClient(() =>    {
                                                                           var result = authContext.AcquireToken( "https://api.office.com/discovery/", SiteSettings.ClientId, new Uri(SiteSettings.RedirectUrl));
                                                                           return result.AccessToken;
                                                                        });
         var capabilities =  await discoveryClient.DiscoverCapabilitiesAsync();

         foreach ( var capability in capabilities )
         {
            if ( capability.Key == "RootSite" )
            {
               var sharePointItem = new KeyValuePair<string, CapabilityDiscoveryResult>( "SharePoint", capability.Value );
               discoveryResults.Add( sharePointItem );
            }
            else
            discoveryResults.Add( capability );
         }
         comboBox1.DisplayMember = "Key";
         comboBox1.ValueMember = "Value";
         comboBox1.DataSource = discoveryResults;

      }
      private void comboBox1_SelectedIndexChanged( object sender, EventArgs e )
      {
         selectedService = (CapabilityDiscoveryResult) comboBox1.SelectedValue;
         if ( comboBox1.SelectedText == "RootSite" )
         {
            var selectSharePointSite = new SelectSharePointSite();
            var result = selectSharePointSite.DialogResult;
            if ( result == DialogResult.OK )
            {

            }
         }
      }
   }
}
