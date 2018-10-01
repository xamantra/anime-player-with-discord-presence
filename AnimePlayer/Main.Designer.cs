namespace AnimePlayer
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.hideOnTray = new System.Windows.Forms.Button();
            this.epsList = new System.Windows.Forms.ComboBox();
            this.nextEp = new System.Windows.Forms.Button();
            this.prevEp = new System.Windows.Forms.Button();
            this.browseDirectory = new System.Windows.Forms.Button();
            this.animeList = new System.Windows.Forms.ComboBox();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.quit = new System.Windows.Forms.Button();
            this.startWatch = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.wallpaper = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.wallpaper)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Anime";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(9, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Episode:";
            // 
            // hideOnTray
            // 
            this.hideOnTray.Location = new System.Drawing.Point(179, 156);
            this.hideOnTray.Name = "hideOnTray";
            this.hideOnTray.Size = new System.Drawing.Size(135, 36);
            this.hideOnTray.TabIndex = 6;
            this.hideOnTray.Text = "Minimize";
            this.hideOnTray.UseVisualStyleBackColor = true;
            this.hideOnTray.Click += new System.EventHandler(this.hideOnTray_Click);
            // 
            // epsList
            // 
            this.epsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.epsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.epsList.FormattingEnabled = true;
            this.epsList.Location = new System.Drawing.Point(123, 90);
            this.epsList.Name = "epsList";
            this.epsList.Size = new System.Drawing.Size(300, 28);
            this.epsList.TabIndex = 7;
            this.epsList.SelectedIndexChanged += new System.EventHandler(this.episode_Changed);
            // 
            // nextEp
            // 
            this.nextEp.Location = new System.Drawing.Point(429, 89);
            this.nextEp.Name = "nextEp";
            this.nextEp.Size = new System.Drawing.Size(51, 29);
            this.nextEp.TabIndex = 8;
            this.nextEp.Text = ">>";
            this.nextEp.UseVisualStyleBackColor = true;
            this.nextEp.Click += new System.EventHandler(this.nextEp_Click);
            // 
            // prevEp
            // 
            this.prevEp.Location = new System.Drawing.Point(66, 89);
            this.prevEp.Name = "prevEp";
            this.prevEp.Size = new System.Drawing.Size(51, 29);
            this.prevEp.TabIndex = 9;
            this.prevEp.Text = "<<";
            this.prevEp.UseVisualStyleBackColor = true;
            this.prevEp.Click += new System.EventHandler(this.prevEp_Click);
            // 
            // browseDirectory
            // 
            this.browseDirectory.Location = new System.Drawing.Point(372, 42);
            this.browseDirectory.Name = "browseDirectory";
            this.browseDirectory.Size = new System.Drawing.Size(51, 30);
            this.browseDirectory.TabIndex = 10;
            this.browseDirectory.Text = "...";
            this.browseDirectory.UseVisualStyleBackColor = true;
            this.browseDirectory.Click += new System.EventHandler(this.browseDirectory_Click);
            // 
            // animeList
            // 
            this.animeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.animeList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.animeList.FormattingEnabled = true;
            this.animeList.IntegralHeight = false;
            this.animeList.ItemHeight = 20;
            this.animeList.Location = new System.Drawing.Point(67, 44);
            this.animeList.MaxDropDownItems = 9;
            this.animeList.Name = "animeList";
            this.animeList.Size = new System.Drawing.Size(299, 28);
            this.animeList.TabIndex = 11;
            this.animeList.SelectedIndexChanged += new System.EventHandler(this.animeName_TextChanged);
            // 
            // quit
            // 
            this.quit.Location = new System.Drawing.Point(345, 156);
            this.quit.Name = "quit";
            this.quit.Size = new System.Drawing.Size(135, 36);
            this.quit.TabIndex = 12;
            this.quit.Text = "Quit";
            this.quit.UseVisualStyleBackColor = true;
            this.quit.Click += new System.EventHandler(this.quit_Click);
            // 
            // startWatch
            // 
            this.startWatch.Location = new System.Drawing.Point(12, 156);
            this.startWatch.Name = "startWatch";
            this.startWatch.Size = new System.Drawing.Size(135, 36);
            this.startWatch.TabIndex = 13;
            this.startWatch.Text = "Start Watching";
            this.startWatch.UseVisualStyleBackColor = true;
            this.startWatch.Click += new System.EventHandler(this.startWatch_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(429, 42);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(51, 30);
            this.deleteButton.TabIndex = 14;
            this.deleteButton.Text = "X";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // wallpaper
            // 
            this.wallpaper.Image = global::AnimePlayer.Properties.Resources.emilia1;
            this.wallpaper.Location = new System.Drawing.Point(-1, -1);
            this.wallpaper.Name = "wallpaper";
            this.wallpaper.Size = new System.Drawing.Size(495, 226);
            this.wallpaper.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.wallpaper.TabIndex = 15;
            this.wallpaper.TabStop = false;
            this.wallpaper.Click += new System.EventHandler(this.wallpaper_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(492, 224);
            this.ControlBox = false;
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.startWatch);
            this.Controls.Add(this.quit);
            this.Controls.Add(this.animeList);
            this.Controls.Add(this.browseDirectory);
            this.Controls.Add(this.prevEp);
            this.Controls.Add(this.nextEp);
            this.Controls.Add(this.epsList);
            this.Controls.Add(this.hideOnTray);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.wallpaper);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AnimePlayer with Discord Presence";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wallpaper)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button hideOnTray;
        private System.Windows.Forms.Button nextEp;
        private System.Windows.Forms.Button prevEp;
        private System.Windows.Forms.Button browseDirectory;
        private System.Windows.Forms.ComboBox animeList;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.Button quit;
        private System.Windows.Forms.Button startWatch;
        public System.Windows.Forms.ComboBox epsList;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.PictureBox wallpaper;
        private System.Windows.Forms.Timer timer;
    }
}

