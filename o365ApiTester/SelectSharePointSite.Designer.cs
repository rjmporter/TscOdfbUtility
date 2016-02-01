namespace o365ApiTester
{
   partial class SelectSharePointSite
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose( bool disposing )
      {
         if ( disposing && ( components != null ) )
         {
            components.Dispose();
         }
         base.Dispose( disposing );
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.btnOk = new System.Windows.Forms.Button();
         this.btnCancel = new System.Windows.Forms.Button();
         this.lstSharePointSites = new System.Windows.Forms.ListBox();
         this.SuspendLayout();
         // 
         // btnOk
         // 
         this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.btnOk.Location = new System.Drawing.Point(99, 163);
         this.btnOk.Name = "btnOk";
         this.btnOk.Size = new System.Drawing.Size(75, 23);
         this.btnOk.TabIndex = 0;
         this.btnOk.Text = "&OK";
         this.btnOk.UseVisualStyleBackColor = true;
         // 
         // btnCancel
         // 
         this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnCancel.CausesValidation = false;
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point(180, 163);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(75, 23);
         this.btnCancel.TabIndex = 1;
         this.btnCancel.Text = "&Cancel";
         this.btnCancel.UseVisualStyleBackColor = true;
         // 
         // lstSharePointSites
         // 
         this.lstSharePointSites.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.lstSharePointSites.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lstSharePointSites.FormattingEnabled = true;
         this.lstSharePointSites.ItemHeight = 20;
         this.lstSharePointSites.Location = new System.Drawing.Point(12, 12);
         this.lstSharePointSites.Name = "lstSharePointSites";
         this.lstSharePointSites.Size = new System.Drawing.Size(243, 124);
         this.lstSharePointSites.TabIndex = 2;
         this.lstSharePointSites.SelectedIndexChanged += new System.EventHandler(this.lstSharePointSites_SelectedIndexChanged);
         // 
         // SelectSharePointSite
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(267, 198);
         this.Controls.Add(this.lstSharePointSites);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.btnOk);
         this.Name = "SelectSharePointSite";
         this.Text = "Select SharePoint Site";
         this.Load += new System.EventHandler(this.SelectSharePointSite_Load);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button btnOk;
      private System.Windows.Forms.Button btnCancel;
      internal System.Windows.Forms.ListBox lstSharePointSites;
   }
}