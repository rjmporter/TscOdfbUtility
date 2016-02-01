using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace o365ApiTester
{
   internal static class Program
   {
      internal static readonly AuthenticationContext authContext =
         new AuthenticationContext( SiteSettings.Authority );
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
