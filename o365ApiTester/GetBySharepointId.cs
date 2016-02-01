using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;
using Form = System.Windows.Forms.Form;

namespace o365ApiTester
{
   public partial class GetBySharepointId : Form
   {
      private ClientContext _ctx;
      public string SharePointSiteUrl{
         get
         {
            return _ctx.Url;
         }
         set
         {
            _ctx = this.GetSharePointContext( value );
         }
      }
      public GetBySharepointId()
      {
         InitializeComponent();
      }

      private void GetBySharepointId_Load( object sender, EventArgs e )
      {
         
      }
   }
}
