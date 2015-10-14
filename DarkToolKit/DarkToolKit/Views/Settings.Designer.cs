namespace DarkToolKit.Views
{
    partial class Settings
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.groupBox1 = new DevExpress.XtraEditors.GroupControl();
            this.txtHaloOnlineDir = new DevExpress.XtraEditors.TextEdit();
            this.btnBrowse = new DevExpress.XtraEditors.SimpleButton();
            this.fbdHaloOnline = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox2 = new DevExpress.XtraEditors.GroupControl();
            this.chkNoLauncher = new DevExpress.XtraEditors.CheckEdit();
            this.groupBox4 = new DevExpress.XtraEditors.GroupControl();
            this.spinAdapter = new DevExpress.XtraEditors.SpinEdit();
            this.chkD3d9 = new DevExpress.XtraEditors.CheckEdit();
            this.label5 = new DevExpress.XtraEditors.LabelControl();
            this.label4 = new DevExpress.XtraEditors.LabelControl();
            this.txtHeight = new DevExpress.XtraEditors.TextEdit();
            this.txtWidth = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new DevExpress.XtraEditors.LabelControl();
            this.chkNod3d9 = new DevExpress.XtraEditors.CheckEdit();
            this.chkVsync = new DevExpress.XtraEditors.CheckEdit();
            this.chkWindowed = new DevExpress.XtraEditors.CheckEdit();
            this.chkShowFps = new DevExpress.XtraEditors.CheckEdit();
            this.chkFullscreen = new DevExpress.XtraEditors.CheckEdit();
            this.groupBox3 = new DevExpress.XtraEditors.GroupControl();
            this.label6 = new DevExpress.XtraEditors.LabelControl();
            this.cbEnvironment = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.txtSignInCode = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.txtAccount = new DevExpress.XtraEditors.TextEdit();
            this.txtLaunchArguments = new DevExpress.XtraEditors.TextEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnLaunchHalo = new DevExpress.XtraEditors.SimpleButton();
            this.btnReset = new DevExpress.XtraEditors.SimpleButton();
            this.chkBranch = new DevExpress.XtraEditors.CheckEdit();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHaloOnlineDir.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkNoLauncher.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox4)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinAdapter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkD3d9.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWidth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNod3d9.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkVsync.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkWindowed.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowFps.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFullscreen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox3)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbEnvironment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSignInCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLaunchArguments.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBranch.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtHaloOnlineDir);
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(491, 56);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.Text = "Halo Online Folder";
            // 
            // txtHaloOnlineDir
            // 
            this.txtHaloOnlineDir.Location = new System.Drawing.Point(15, 22);
            this.txtHaloOnlineDir.Name = "txtHaloOnlineDir";
            this.txtHaloOnlineDir.Size = new System.Drawing.Size(389, 20);
            this.txtHaloOnlineDir.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(410, 20);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // fbdHaloOnline
            // 
            this.fbdHaloOnline.Description = "Halo Online Installation Directory";
            this.fbdHaloOnline.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.fbdHaloOnline.ShowNewFolderButton = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkNoLauncher);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.txtLaunchArguments);
            this.groupBox2.Location = new System.Drawing.Point(12, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(491, 231);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.Text = "Halo Online Options";
            // 
            // chkNoLauncher
            // 
            this.chkNoLauncher.Location = new System.Drawing.Point(335, 168);
            this.chkNoLauncher.Name = "chkNoLauncher";
            this.chkNoLauncher.Properties.Caption = "No Launcher (eldewrito)";
            this.chkNoLauncher.Properties.LookAndFeel.TouchUIMode = DevExpress.LookAndFeel.TouchUIMode.False;
            this.chkNoLauncher.Size = new System.Drawing.Size(141, 19);
            this.chkNoLauncher.TabIndex = 7;
            this.chkNoLauncher.CheckedChanged += new System.EventHandler(this.ProcessLaunchArguments);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.spinAdapter);
            this.groupBox4.Controls.Add(this.chkD3d9);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.txtHeight);
            this.groupBox4.Controls.Add(this.txtWidth);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.chkNod3d9);
            this.groupBox4.Controls.Add(this.chkVsync);
            this.groupBox4.Controls.Add(this.chkWindowed);
            this.groupBox4.Controls.Add(this.chkShowFps);
            this.groupBox4.Controls.Add(this.chkFullscreen);
            this.groupBox4.Location = new System.Drawing.Point(219, 31);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(257, 116);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.Text = "Graphics";
            // 
            // spinAdapter
            // 
            this.spinAdapter.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinAdapter.Location = new System.Drawing.Point(172, 40);
            this.spinAdapter.Name = "spinAdapter";
            this.spinAdapter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinAdapter.Properties.IsFloatValue = false;
            this.spinAdapter.Properties.LookAndFeel.TouchUIMode = DevExpress.LookAndFeel.TouchUIMode.False;
            this.spinAdapter.Properties.Mask.EditMask = "N00";
            this.spinAdapter.Size = new System.Drawing.Size(69, 20);
            this.spinAdapter.TabIndex = 14;
            this.spinAdapter.ValueChanged += new System.EventHandler(this.spinAdapter_ValueChanged);
            // 
            // chkD3d9
            // 
            this.chkD3d9.Location = new System.Drawing.Point(175, 90);
            this.chkD3d9.Name = "chkD3d9";
            this.chkD3d9.Properties.Caption = "d3d9";
            this.chkD3d9.Size = new System.Drawing.Size(50, 19);
            this.chkD3d9.TabIndex = 13;
            this.chkD3d9.CheckedChanged += new System.EventHandler(this.ProcessLaunchArguments);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(93, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Height";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Width";
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(96, 40);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(71, 20);
            this.txtHeight.TabIndex = 10;
            this.txtHeight.ToolTip = "Height of the game window";
            this.txtHeight.TextChanged += new System.EventHandler(this.txtHeight_TextChanged);
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(16, 40);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(71, 20);
            this.txtWidth.TabIndex = 9;
            this.txtWidth.ToolTip = "Width of the Game Window";
            this.txtWidth.TextChanged += new System.EventHandler(this.txtWidth_TextChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(198, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Adapter";
            // 
            // chkNod3d9
            // 
            this.chkNod3d9.Location = new System.Drawing.Point(175, 66);
            this.chkNod3d9.Name = "chkNod3d9";
            this.chkNod3d9.Properties.Caption = "No d3d9";
            this.chkNod3d9.Size = new System.Drawing.Size(66, 19);
            this.chkNod3d9.TabIndex = 6;
            this.chkNod3d9.CheckedChanged += new System.EventHandler(this.ProcessLaunchArguments);
            // 
            // chkVsync
            // 
            this.chkVsync.Location = new System.Drawing.Point(16, 90);
            this.chkVsync.Name = "chkVsync";
            this.chkVsync.Properties.Caption = "No vSync";
            this.chkVsync.Size = new System.Drawing.Size(71, 19);
            this.chkVsync.TabIndex = 5;
            this.chkVsync.CheckedChanged += new System.EventHandler(this.ProcessLaunchArguments);
            // 
            // chkWindowed
            // 
            this.chkWindowed.Location = new System.Drawing.Point(96, 67);
            this.chkWindowed.Name = "chkWindowed";
            this.chkWindowed.Properties.Caption = "Window";
            this.chkWindowed.Size = new System.Drawing.Size(64, 19);
            this.chkWindowed.TabIndex = 1;
            this.chkWindowed.CheckedChanged += new System.EventHandler(this.ProcessLaunchArguments);
            // 
            // chkShowFps
            // 
            this.chkShowFps.Location = new System.Drawing.Point(96, 90);
            this.chkShowFps.Name = "chkShowFps";
            this.chkShowFps.Properties.Caption = "Show FPS";
            this.chkShowFps.Size = new System.Drawing.Size(73, 19);
            this.chkShowFps.TabIndex = 4;
            this.chkShowFps.CheckedChanged += new System.EventHandler(this.ProcessLaunchArguments);
            // 
            // chkFullscreen
            // 
            this.chkFullscreen.Location = new System.Drawing.Point(16, 66);
            this.chkFullscreen.Name = "chkFullscreen";
            this.chkFullscreen.Properties.Caption = "Fullscreen";
            this.chkFullscreen.Size = new System.Drawing.Size(74, 19);
            this.chkFullscreen.TabIndex = 2;
            this.chkFullscreen.CheckedChanged += new System.EventHandler(this.ProcessLaunchArguments);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.cbEnvironment);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtSignInCode);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtAccount);
            this.groupBox3.Location = new System.Drawing.Point(15, 31);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(164, 156);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.Text = "Account Info";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(17, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Environment";
            // 
            // cbEnvironment
            // 
            this.cbEnvironment.Location = new System.Drawing.Point(17, 120);
            this.cbEnvironment.Name = "cbEnvironment";
            this.cbEnvironment.Properties.Items.AddRange(new object[] {
            "",
            "LIVE",
            "PTS",
            "PTS2",
            "PTS3",
            "QA"});
            this.cbEnvironment.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbEnvironment.Size = new System.Drawing.Size(129, 20);
            this.cbEnvironment.TabIndex = 14;
            this.cbEnvironment.SelectedIndexChanged += new System.EventHandler(this.ProcessLaunchArguments);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(17, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Sign In Code";
            // 
            // txtSignInCode
            // 
            this.txtSignInCode.EditValue = "123";
            this.txtSignInCode.Location = new System.Drawing.Point(17, 76);
            this.txtSignInCode.Name = "txtSignInCode";
            this.txtSignInCode.Size = new System.Drawing.Size(129, 20);
            this.txtSignInCode.TabIndex = 2;
            this.txtSignInCode.TextChanged += new System.EventHandler(this.ProcessLaunchArguments);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(17, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Account";
            // 
            // txtAccount
            // 
            this.txtAccount.EditValue = "123";
            this.txtAccount.Location = new System.Drawing.Point(17, 38);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(129, 20);
            this.txtAccount.TabIndex = 0;
            this.txtAccount.TextChanged += new System.EventHandler(this.ProcessLaunchArguments);
            // 
            // txtLaunchArguments
            // 
            this.txtLaunchArguments.Location = new System.Drawing.Point(15, 197);
            this.txtLaunchArguments.Name = "txtLaunchArguments";
            this.txtLaunchArguments.Size = new System.Drawing.Size(461, 20);
            this.txtLaunchArguments.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(266, 313);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save Settings";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLaunchHalo
            // 
            this.btnLaunchHalo.Location = new System.Drawing.Point(371, 313);
            this.btnLaunchHalo.Name = "btnLaunchHalo";
            this.btnLaunchHalo.Size = new System.Drawing.Size(117, 23);
            this.btnLaunchHalo.TabIndex = 7;
            this.btnLaunchHalo.Text = "Launch Halo Online";
            this.btnLaunchHalo.Click += new System.EventHandler(this.btnLaunchHalo_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(185, 313);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // chkBranch
            // 
            this.chkBranch.Location = new System.Drawing.Point(27, 317);
            this.chkBranch.Name = "chkBranch";
            this.chkBranch.Properties.Caption = "Download Beta Updates";
            this.chkBranch.Size = new System.Drawing.Size(141, 19);
            this.chkBranch.TabIndex = 9;
            this.chkBranch.CheckedChanged += new System.EventHandler(this.chkBranch_CheckedChanged);
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.defaultLookAndFeel1.LookAndFeel.TouchUIMode = DevExpress.LookAndFeel.TouchUIMode.False;
            // 
            // Settings
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 346);
            this.Controls.Add(this.chkBranch);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnLaunchHalo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsWindowClosing);
            this.Load += new System.EventHandler(this.Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtHaloOnlineDir.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkNoLauncher.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox4)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinAdapter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkD3d9.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWidth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNod3d9.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkVsync.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkWindowed.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowFps.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFullscreen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox3)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbEnvironment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSignInCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLaunchArguments.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBranch.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupBox1;
        private DevExpress.XtraEditors.TextEdit txtHaloOnlineDir;
        private DevExpress.XtraEditors.SimpleButton btnBrowse;
        private System.Windows.Forms.FolderBrowserDialog fbdHaloOnline;
        private DevExpress.XtraEditors.GroupControl groupBox2;
        private DevExpress.XtraEditors.GroupControl groupBox3;
        private DevExpress.XtraEditors.LabelControl label2;
        private DevExpress.XtraEditors.TextEdit txtSignInCode;
        private DevExpress.XtraEditors.LabelControl label1;
        private DevExpress.XtraEditors.TextEdit txtAccount;
        private DevExpress.XtraEditors.CheckEdit chkFullscreen;
        private DevExpress.XtraEditors.CheckEdit chkWindowed;
        private DevExpress.XtraEditors.TextEdit txtLaunchArguments;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.GroupControl groupBox4;
        private DevExpress.XtraEditors.CheckEdit chkD3d9;
        private DevExpress.XtraEditors.LabelControl label5;
        private DevExpress.XtraEditors.LabelControl label4;
        private DevExpress.XtraEditors.TextEdit txtHeight;
        private DevExpress.XtraEditors.TextEdit txtWidth;
        private DevExpress.XtraEditors.LabelControl label3;
        private DevExpress.XtraEditors.CheckEdit chkNod3d9;
        private DevExpress.XtraEditors.CheckEdit chkVsync;
        private DevExpress.XtraEditors.CheckEdit chkShowFps;
        private DevExpress.XtraEditors.LabelControl label6;
        private DevExpress.XtraEditors.ComboBoxEdit cbEnvironment;
        private DevExpress.XtraEditors.SimpleButton btnLaunchHalo;
        private DevExpress.XtraEditors.SimpleButton btnReset;
        private DevExpress.XtraEditors.CheckEdit chkBranch;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraEditors.SpinEdit spinAdapter;
        private DevExpress.XtraEditors.CheckEdit chkNoLauncher;
    }
}