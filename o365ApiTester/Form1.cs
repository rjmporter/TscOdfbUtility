using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Office365.Discovery;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace o365ApiTester
{
   public partial class Form1 : Form
   {

      private readonly List<KeyValuePair<string, CapabilityDiscoveryResult>> _discoveryResults;
      private AuthenticationResult _selectedResourceAuthResult;
      private CapabilityDiscoveryResult _selectedService;
      private string _selectedApiEnpoint;
      private HttpMethod _method;
      private string _apiCall;
      private string _apiPayload = string.Empty;

      public Form1()
      {
         InitializeComponent();
         _discoveryResults = new List<KeyValuePair<string, CapabilityDiscoveryResult>>();
      }

      private async void Form1_Load( object sender, EventArgs e )
      {

         DiscoveryClient discoveryClient = new DiscoveryClient( () =>
         {
            var result = Program.authContext.AcquireToken( "https://api.office.com/discovery/", SiteSettings.ClientId, new Uri( SiteSettings.RedirectUrl ) );
            return result.AccessToken;
         } );
         var capabilities = await discoveryClient.DiscoverCapabilitiesAsync();
         var fileSources = new[]
                           {
                                 "MyFiles",
                                 "RootSite"
                           };
         DataTable dt = new DataTable( "Capabilites" );
         dt.Columns.Add( "Name", typeof( string ) );
         dt.Columns.Add( "CapabilityResult", typeof( CapabilityDiscoveryResult ) );

         dt.Rows.Add( "<Select a Resource>", null );
         dt.Rows.Add(
               "GraphApi",
               new CapabilityDiscoveryResult( new Uri( SiteSettings.GraphApiEndpoint.Trim( '/' ) ), SiteSettings.GraphResourceId ) );
         foreach ( var capability in capabilities.Where( c => fileSources.Contains( c.Key ) ) )
         {
            if ( capability.Key == "RootSite" )
            {
               var sharePointItem = new KeyValuePair<string, CapabilityDiscoveryResult>( "SharePoint", capability.Value );
               dt.Rows.Add( sharePointItem.Key, sharePointItem.Value );
            }
            else if ( capability.Key == "MyFiles" )
            {
               var oneDriveItem = new KeyValuePair<string, CapabilityDiscoveryResult>( "OneDrive", capability.Value );
               dt.Rows.Add( oneDriveItem.Key, oneDriveItem.Value );
            }
            else
               dt.Rows.Add( capability.Key, capability.Value );
         }
         comboBox1.DisplayMember = "Name";
         comboBox1.ValueMember = "CapabilityResult";

         comboBox1.DataSource = dt;

      }
      private void comboBox1_SelectedIndexChanged( object sender, EventArgs e )
      {

         _selectedService = comboBox1.SelectedValue as CapabilityDiscoveryResult;
         if ( _selectedService != null )
         {
            string resourceId = _selectedService.ServiceResourceId;
            _selectedApiEnpoint = _selectedService.ServiceEndpointUri.AbsoluteUri;

            if ( comboBox1.Text.Equals( "SharePoint", StringComparison.OrdinalIgnoreCase ) )
            {
               GetSharePointEnpoint( resourceId );
            }
            if ( comboBox1.Text.Equals( "OneDrive", StringComparison.OrdinalIgnoreCase ) )
            {
               _selectedApiEnpoint = _selectedApiEnpoint.Replace( "v1.0", "v2.0" ).Replace( "/me", "" );
            }
            _selectedResourceAuthResult = Program.authContext.AcquireToken(
                  resourceId,
                  SiteSettings.ClientId,
                  new Uri( SiteSettings.RedirectUrl ) );

            lblServiceInfoOutput.Text = $"Selected Resource:   {resourceId}\r\n"
                                          + $"Selected Endpoint:   {_selectedApiEnpoint}\r\n"
                                          + $"User:                {_selectedResourceAuthResult.UserInfo.DisplayableId}";

         }
      }

      private void GetSharePointEnpoint( string resourceId )
      {
         var selectSharePointSite = new SelectSharePointSite();
         string relativeApiEnpoint = _selectedApiEnpoint.Replace( resourceId, "" ).Trim( '/' );
         selectSharePointSite.SharePointRootSite = _selectedService.ServiceResourceId;
         var result = selectSharePointSite.ShowDialog();
         if ( result == DialogResult.OK )
         {
            _selectedApiEnpoint = selectSharePointSite.SelectedSite.Trim( '/' ) + "/" + relativeApiEnpoint + "/v2.0/";
            selectSharePointSite.Close();
         }
      }

      private void radioButton5_CheckedChanged( object sender, EventArgs e )
      {
         var rdoSender = sender as RadioButton;
         _method = new HttpMethod( rdoSender.Text );
      }

      private void button1_Click( object sender, EventArgs e )
      {
         if ( _method == null
              || string.IsNullOrWhiteSpace( _apiCall ) || _selectedResourceAuthResult == null )
         {
            MessageBox.Show( "Please first select an HTTP Method and typing an API call." );
            return;
         }
         var url = _selectedApiEnpoint.Trim( '/' ) + "/" + _apiCall.Trim( '/' );
         JObject jsonResponse = Program.JSONResponse( url, _method, _selectedResourceAuthResult, _apiPayload );
         txtResponse.Text = jsonResponse?.ToString( Formatting.Indented );
      }


      private void textBox1_TextChanged( object sender, EventArgs e )
      {
         _apiCall = txtApiCall.Text;
      }

      private void txtPayload_TextChanged( object sender, EventArgs e )
      {
         _apiPayload = txtPayload.Text;
      }

      private void label4_Click( object sender, EventArgs e )
      {

      }

      private void txtResponse_MouseDoubleClick( object sender, MouseEventArgs e )
      {
         var x = txtResponse.GetCharIndexFromPosition( e.Location );
         var lineStart = txtResponse.GetFirstCharIndexOfCurrentLine();
         var line = txtResponse.GetLineFromCharIndex( x );
         var lineText = txtResponse.Lines[line].Trim().TrimEnd( ',' );
         var parts = lineText.Split( ':' );
         if ( parts.Length > 1 )
         {
            var call = parts[1].Trim().Trim( '"' );

            Regex callMatch = new Regex( "drive(s)?/[^/]+/.*" );

            if ( callMatch.IsMatch( call ) )
            {
               txtApiCall.Text = call;
               var response = Program.JSONResponse( _selectedApiEnpoint.Trim( '/' ) + "/" + call, HttpMethod.Get, _selectedResourceAuthResult );
               if ( Regex.IsMatch( response.ToString(), "\"folder\":" ) )
                  txtApiCall.Text += "/children";

               btnExecute.PerformClick();
            }
         }
         else
         {
            MessageBox.Show( lineText );
         }
      }

      private async void btnFindByGuid_Click( object sender, EventArgs e )
      {
         var sharePointLocator = new GetBySharepointId();
         var result = sharePointLocator.ShowDialog();
         if ( result == DialogResult.OK )
         {
            var apiCall = await sharePointLocator.DrivesApiCall;
            txtApiCall.Text = apiCall;
         }
         

      }
   }
}
