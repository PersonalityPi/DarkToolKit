namespace PluginExample
{
    partial class HelloForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtMessage = new DevExpress.XtraEditors.TextEdit();
            this.btnGo = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.lblHaloOnlineFolder = new DevExpress.XtraEditors.LabelControl();
            this.lblDebugMode = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtMessage.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.EditValue = "Hello World!";
            this.txtMessage.Location = new System.Drawing.Point(12, 86);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(425, 20);
            this.txtMessage.TabIndex = 1;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(444, 81);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(92, 29);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Go!";
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label1
            // 
            this.label1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(522, 48);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hello!\r\n\r\nThis is an example plugin for DarkToolKit. This main form gets loaded b" +
    "y DarkPluginMain();";
            // 
            // lblHaloOnlineFolder
            // 
            this.lblHaloOnlineFolder.Location = new System.Drawing.Point(12, 126);
            this.lblHaloOnlineFolder.Name = "lblHaloOnlineFolder";
            this.lblHaloOnlineFolder.Size = new System.Drawing.Size(91, 13);
            this.lblHaloOnlineFolder.TabIndex = 4;
            this.lblHaloOnlineFolder.Text = "lblHaloOnlineFolder";
            // 
            // lblDebugMode
            // 
            this.lblDebugMode.Location = new System.Drawing.Point(12, 150);
            this.lblDebugMode.Name = "lblDebugMode";
            this.lblDebugMode.Size = new System.Drawing.Size(67, 13);
            this.lblDebugMode.TabIndex = 5;
            this.lblDebugMode.Text = "lblDebugMode";
            // 
            // HelloForm
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 182);
            this.Controls.Add(this.lblDebugMode);
            this.Controls.Add(this.lblHaloOnlineFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtMessage);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "HelloForm";
            this.Text = "HelloForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HelloForm_FormClosing);
            this.Load += new System.EventHandler(this.HelloForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtMessage.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtMessage;
        private DevExpress.XtraEditors.SimpleButton btnGo;
        private DevExpress.XtraEditors.LabelControl label1;
        private DevExpress.XtraEditors.LabelControl lblHaloOnlineFolder;
        private DevExpress.XtraEditors.LabelControl lblDebugMode;
    }
}