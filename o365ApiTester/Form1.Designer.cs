﻿namespace o365ApiTester
{
   partial class Form1
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
         this.comboBox1 = new System.Windows.Forms.ComboBox();
         this.label1 = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // comboBox1
         // 
         this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.comboBox1.FormattingEnabled = true;
         this.comboBox1.Location = new System.Drawing.Point(146, 6);
         this.comboBox1.Name = "comboBox1";
         this.comboBox1.Size = new System.Drawing.Size(275, 21);
         this.comboBox1.TabIndex = 0;
         this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(12, 9);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(128, 13);
         this.label1.TabIndex = 1;
         this.label1.Text = "Select a Service to Query";
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(433, 261);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.comboBox1);
         this.Name = "Form1";
         this.Text = "Form1";
         this.Load += new System.EventHandler(this.Form1_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ComboBox comboBox1;
      private System.Windows.Forms.Label label1;
   }
}

