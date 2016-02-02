namespace o365ApiTester
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
         this.panel1 = new System.Windows.Forms.Panel();
         this.lblServiceInfoOutput = new System.Windows.Forms.Label();
         this.lblServiceInfoPanel = new System.Windows.Forms.Label();
         this.panel2 = new System.Windows.Forms.Panel();
         this.label2 = new System.Windows.Forms.Label();
         this.txtApiCall = new System.Windows.Forms.TextBox();
         this.radioButton1 = new System.Windows.Forms.RadioButton();
         this.radioButton2 = new System.Windows.Forms.RadioButton();
         this.radioButton3 = new System.Windows.Forms.RadioButton();
         this.radioButton4 = new System.Windows.Forms.RadioButton();
         this.radioButton5 = new System.Windows.Forms.RadioButton();
         this.label3 = new System.Windows.Forms.Label();
         this.pnlResults = new System.Windows.Forms.Panel();
         this.txtResponse = new System.Windows.Forms.TextBox();
         this.label5 = new System.Windows.Forms.Label();
         this.txtPayload = new System.Windows.Forms.TextBox();
         this.label4 = new System.Windows.Forms.Label();
         this.btnExecute = new System.Windows.Forms.Button();
         this.panel3 = new System.Windows.Forms.Panel();
         this.btnFindByGuid = new System.Windows.Forms.Button();
         this.panel1.SuspendLayout();
         this.panel2.SuspendLayout();
         this.pnlResults.SuspendLayout();
         this.panel3.SuspendLayout();
         this.SuspendLayout();
         // 
         // comboBox1
         // 
         this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.comboBox1.FormattingEnabled = true;
         this.comboBox1.Location = new System.Drawing.Point(801, 3);
         this.comboBox1.Name = "comboBox1";
         this.comboBox1.Size = new System.Drawing.Size(197, 28);
         this.comboBox1.TabIndex = 0;
         this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
         // 
         // label1
         // 
         this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.Location = new System.Drawing.Point(583, 6);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(212, 20);
         this.label1.TabIndex = 1;
         this.label1.Text = "Select a Service to Query";
         // 
         // panel1
         // 
         this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
         this.panel1.Controls.Add(this.lblServiceInfoOutput);
         this.panel1.Controls.Add(this.lblServiceInfoPanel);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.panel1.Location = new System.Drawing.Point(0, 598);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(1001, 32);
         this.panel1.TabIndex = 2;
         // 
         // lblServiceInfoOutput
         // 
         this.lblServiceInfoOutput.AutoEllipsis = true;
         this.lblServiceInfoOutput.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.lblServiceInfoOutput.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblServiceInfoOutput.Location = new System.Drawing.Point(0, 13);
         this.lblServiceInfoOutput.Name = "lblServiceInfoOutput";
         this.lblServiceInfoOutput.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
         this.lblServiceInfoOutput.Size = new System.Drawing.Size(190, 19);
         this.lblServiceInfoOutput.TabIndex = 2;
         this.lblServiceInfoOutput.Text = "No Service Selected";
         // 
         // lblServiceInfoPanel
         // 
         this.lblServiceInfoPanel.Dock = System.Windows.Forms.DockStyle.Top;
         this.lblServiceInfoPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblServiceInfoPanel.Location = new System.Drawing.Point(0, 0);
         this.lblServiceInfoPanel.Name = "lblServiceInfoPanel";
         this.lblServiceInfoPanel.Size = new System.Drawing.Size(76, 13);
         this.lblServiceInfoPanel.TabIndex = 0;
         this.lblServiceInfoPanel.Text = "Service Info";
         // 
         // panel2
         // 
         this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
         this.panel2.Controls.Add(this.comboBox1);
         this.panel2.Controls.Add(this.label1);
         this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel2.Location = new System.Drawing.Point(0, 0);
         this.panel2.Name = "panel2";
         this.panel2.Size = new System.Drawing.Size(1001, 34);
         this.panel2.TabIndex = 3;
         // 
         // label2
         // 
         this.label2.Location = new System.Drawing.Point(5, 75);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(72, 13);
         this.label2.TabIndex = 4;
         this.label2.Text = "Enter API Call";
         // 
         // txtApiCall
         // 
         this.txtApiCall.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtApiCall.Location = new System.Drawing.Point(8, 91);
         this.txtApiCall.Name = "txtApiCall";
         this.txtApiCall.Size = new System.Drawing.Size(986, 20);
         this.txtApiCall.TabIndex = 5;
         this.txtApiCall.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
         // 
         // radioButton1
         // 
         this.radioButton1.Location = new System.Drawing.Point(8, 54);
         this.radioButton1.Name = "radioButton1";
         this.radioButton1.Size = new System.Drawing.Size(47, 17);
         this.radioButton1.TabIndex = 6;
         this.radioButton1.TabStop = true;
         this.radioButton1.Text = "GET";
         this.radioButton1.UseVisualStyleBackColor = true;
         this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
         // 
         // radioButton2
         // 
         this.radioButton2.Location = new System.Drawing.Point(61, 54);
         this.radioButton2.Name = "radioButton2";
         this.radioButton2.Size = new System.Drawing.Size(54, 17);
         this.radioButton2.TabIndex = 7;
         this.radioButton2.TabStop = true;
         this.radioButton2.Text = "POST";
         this.radioButton2.UseVisualStyleBackColor = true;
         this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
         // 
         // radioButton3
         // 
         this.radioButton3.Location = new System.Drawing.Point(121, 56);
         this.radioButton3.Name = "radioButton3";
         this.radioButton3.Size = new System.Drawing.Size(47, 17);
         this.radioButton3.TabIndex = 8;
         this.radioButton3.TabStop = true;
         this.radioButton3.Text = "PUT";
         this.radioButton3.UseVisualStyleBackColor = true;
         this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
         // 
         // radioButton4
         // 
         this.radioButton4.Location = new System.Drawing.Point(174, 56);
         this.radioButton4.Name = "radioButton4";
         this.radioButton4.Size = new System.Drawing.Size(61, 17);
         this.radioButton4.TabIndex = 9;
         this.radioButton4.TabStop = true;
         this.radioButton4.Text = "PATCH";
         this.radioButton4.UseVisualStyleBackColor = true;
         this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
         // 
         // radioButton5
         // 
         this.radioButton5.Location = new System.Drawing.Point(241, 56);
         this.radioButton5.Name = "radioButton5";
         this.radioButton5.Size = new System.Drawing.Size(67, 17);
         this.radioButton5.TabIndex = 10;
         this.radioButton5.TabStop = true;
         this.radioButton5.Text = "DELETE";
         this.radioButton5.UseVisualStyleBackColor = true;
         this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
         // 
         // label3
         // 
         this.label3.Location = new System.Drawing.Point(5, 37);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(108, 13);
         this.label3.TabIndex = 11;
         this.label3.Text = "Select HTTP Method";
         // 
         // pnlResults
         // 
         this.pnlResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.pnlResults.AutoScroll = true;
         this.pnlResults.Controls.Add(this.txtResponse);
         this.pnlResults.Controls.Add(this.label5);
         this.pnlResults.Location = new System.Drawing.Point(0, 249);
         this.pnlResults.Name = "pnlResults";
         this.pnlResults.Size = new System.Drawing.Size(1001, 277);
         this.pnlResults.TabIndex = 12;
         // 
         // txtResponse
         // 
         this.txtResponse.Dock = System.Windows.Forms.DockStyle.Fill;
         this.txtResponse.Location = new System.Drawing.Point(0, 13);
         this.txtResponse.Multiline = true;
         this.txtResponse.Name = "txtResponse";
         this.txtResponse.ReadOnly = true;
         this.txtResponse.ScrollBars = System.Windows.Forms.ScrollBars.Both;
         this.txtResponse.Size = new System.Drawing.Size(1001, 264);
         this.txtResponse.TabIndex = 1;
         this.txtResponse.WordWrap = false;
         this.txtResponse.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtResponse_MouseDoubleClick);
         // 
         // label5
         //// 
//         this.label5.AutoSize = true;
         this.label5.Dock = System.Windows.Forms.DockStyle.Top;
         this.label5.Location = new System.Drawing.Point(0, 0);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(55, 13);
         this.label5.TabIndex = 0;
         this.label5.Text = "Response";
         // 
         // txtPayload
         // 
         this.txtPayload.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtPayload.Location = new System.Drawing.Point(8, 130);
         this.txtPayload.Multiline = true;
         this.txtPayload.Name = "txtPayload";
         this.txtPayload.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
         this.txtPayload.Size = new System.Drawing.Size(990, 90);
         this.txtPayload.TabIndex = 13;
         this.txtPayload.TextChanged += new System.EventHandler(this.txtPayload_TextChanged);
         // 
         // label4
         // 
//         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(5, 114);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(45, 13);
         this.label4.TabIndex = 14;
         this.label4.Text = "Payload";
         this.label4.Click += new System.EventHandler(this.label4_Click);
         // 
         // btnExecute
         // 
         this.btnExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.btnExecute.Location = new System.Drawing.Point(884, 40);
         this.btnExecute.Name = "btnExecute";
         this.btnExecute.Size = new System.Drawing.Size(105, 23);
         this.btnExecute.TabIndex = 15;
         this.btnExecute.Text = "Execute";
         this.btnExecute.UseVisualStyleBackColor = true;
         this.btnExecute.Click += new System.EventHandler(this.button1_Click);
         // 
         // panel3
         // 
         this.panel3.Controls.Add(this.btnFindByGuid);
         this.panel3.Controls.Add(this.txtPayload);
         this.panel3.Controls.Add(this.btnExecute);
         this.panel3.Controls.Add(this.panel2);
         this.panel3.Controls.Add(this.label4);
         this.panel3.Controls.Add(this.label3);
         this.panel3.Controls.Add(this.txtApiCall);
         this.panel3.Controls.Add(this.radioButton5);
         this.panel3.Controls.Add(this.label2);
         this.panel3.Controls.Add(this.radioButton4);
         this.panel3.Controls.Add(this.radioButton1);
         this.panel3.Controls.Add(this.radioButton3);
         this.panel3.Controls.Add(this.radioButton2);
         this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel3.Location = new System.Drawing.Point(0, 0);
         this.panel3.Name = "panel3";
         this.panel3.Size = new System.Drawing.Size(1001, 243);
         this.panel3.TabIndex = 16;
         // 
         // btnFindByGuid
         // 
         this.btnFindByGuid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.btnFindByGuid.Location = new System.Drawing.Point(717, 41);
         this.btnFindByGuid.Name = "btnFindByGuid";
         this.btnFindByGuid.Size = new System.Drawing.Size(161, 23);
         this.btnFindByGuid.TabIndex = 16;
         this.btnFindByGuid.Text = "Find by SharePoint GUID";
         this.btnFindByGuid.UseVisualStyleBackColor = true;
         this.btnFindByGuid.Click += new System.EventHandler(this.btnFindByGuid_Click);
         // 
         // Form1
         // 
         this.AcceptButton = this.btnExecute;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//         this.AutoSize = true;
         this.ClientSize = new System.Drawing.Size(1001, 630);
         this.Controls.Add(this.panel3);
         this.Controls.Add(this.pnlResults);
         this.Controls.Add(this.panel1);
         this.Name = "Form1";
         this.Text = "Form1";
         this.Load += new System.EventHandler(this.Form1_Load);
         this.panel1.ResumeLayout(false);
         this.panel1.PerformLayout();
         this.panel2.ResumeLayout(false);
         this.panel2.PerformLayout();
         this.pnlResults.ResumeLayout(false);
         this.pnlResults.PerformLayout();
         this.panel3.ResumeLayout(false);
         this.panel3.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ComboBox comboBox1;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Label lblServiceInfoOutput;
      private System.Windows.Forms.Label lblServiceInfoPanel;
      private System.Windows.Forms.Panel panel2;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.TextBox txtApiCall;
      private System.Windows.Forms.RadioButton radioButton1;
      private System.Windows.Forms.RadioButton radioButton2;
      private System.Windows.Forms.RadioButton radioButton3;
      private System.Windows.Forms.RadioButton radioButton4;
      private System.Windows.Forms.RadioButton radioButton5;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Panel pnlResults;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.TextBox txtPayload;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Button btnExecute;
      private System.Windows.Forms.Panel panel3;
      private System.Windows.Forms.TextBox txtResponse;
      private System.Windows.Forms.Button btnFindByGuid;
   }
}

