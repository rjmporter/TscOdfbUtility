namespace o365ApiTester
{
   partial class GetBySharepointId
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
         this.txtFileGetUrl = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // btnOk
         // 
         this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.btnOk.Enabled = false;
         this.btnOk.Location = new System.Drawing.Point(547, 2);
         this.btnOk.Name = "btnOk";
         this.btnOk.Size = new System.Drawing.Size(75, 23);
         this.btnOk.TabIndex = 2;
         this.btnOk.Text = "&OK";
         this.btnOk.UseVisualStyleBackColor = true;
         this.btnOk.Click += new System.EventHandler(this.button1_Click);
         // 
         // txtFileGetUrl
         // 
         this.txtFileGetUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtFileGetUrl.Location = new System.Drawing.Point(132, 4);
         this.txtFileGetUrl.Name = "txtFileGetUrl";
         this.txtFileGetUrl.Size = new System.Drawing.Size(412, 20);
         this.txtFileGetUrl.TabIndex = 4;
         this.txtFileGetUrl.TextChanged += new System.EventHandler(this.txtFileGetUrl_TextChanged);
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(2, 9);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(124, 13);
         this.label2.TabIndex = 3;
         this.label2.Text = "FileHandler File Get URL";
         // 
         // GetBySharepointId
         // 
         this.AcceptButton = this.btnOk;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(624, 69);
         this.Controls.Add(this.txtFileGetUrl);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.btnOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "GetBySharepointId";
         this.Text = "Find API File Using Sharepoint GUID";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion
      private System.Windows.Forms.Button btnOk;
      private System.Windows.Forms.TextBox txtFileGetUrl;
      private System.Windows.Forms.Label label2;
   }
}