namespace Server
{
    partial class ServerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerForm));
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.MainPage = new System.Windows.Forms.TabPage();
            this.StartButton = new System.Windows.Forms.Button();
            this.PortTextBox = new System.Windows.Forms.TextBox();
            this.AddressTextBox = new System.Windows.Forms.TextBox();
            this.GamePage = new System.Windows.Forms.TabPage();
            this.platform4 = new System.Windows.Forms.PictureBox();
            this.platform3 = new System.Windows.Forms.PictureBox();
            this.platform2 = new System.Windows.Forms.PictureBox();
            this.platform1 = new System.Windows.Forms.PictureBox();
            this.player4 = new System.Windows.Forms.PictureBox();
            this.player3 = new System.Windows.Forms.PictureBox();
            this.player2 = new System.Windows.Forms.PictureBox();
            this.player1 = new System.Windows.Forms.PictureBox();
            this.background = new System.Windows.Forms.PictureBox();
            this.PlayerCountTextBox = new System.Windows.Forms.TextBox();
            this.IpLabel = new System.Windows.Forms.Label();
            this.PlayerCountLabel = new System.Windows.Forms.Label();
            this.PortLabel = new System.Windows.Forms.Label();
            this.MainTabControl.SuspendLayout();
            this.MainPage.SuspendLayout();
            this.GamePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.platform4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.platform3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.platform2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.platform1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.background)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTabControl
            // 
            this.MainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.MainTabControl.Controls.Add(this.MainPage);
            this.MainTabControl.Controls.Add(this.GamePage);
            this.MainTabControl.ItemSize = new System.Drawing.Size(0, 1);
            this.MainTabControl.Location = new System.Drawing.Point(0, 0);
            this.MainTabControl.Margin = new System.Windows.Forms.Padding(4);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(1358, 625);
            this.MainTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.MainTabControl.TabIndex = 7;
            this.MainTabControl.TabStop = false;
            // 
            // MainPage
            // 
            this.MainPage.Controls.Add(this.IpLabel);
            this.MainPage.Controls.Add(this.PlayerCountLabel);
            this.MainPage.Controls.Add(this.PortLabel);
            this.MainPage.Controls.Add(this.PlayerCountTextBox);
            this.MainPage.Controls.Add(this.StartButton);
            this.MainPage.Controls.Add(this.PortTextBox);
            this.MainPage.Controls.Add(this.AddressTextBox);
            this.MainPage.Location = new System.Drawing.Point(4, 5);
            this.MainPage.Margin = new System.Windows.Forms.Padding(4);
            this.MainPage.Name = "MainPage";
            this.MainPage.Padding = new System.Windows.Forms.Padding(4);
            this.MainPage.Size = new System.Drawing.Size(1350, 616);
            this.MainPage.TabIndex = 1;
            this.MainPage.Text = "tabPage2";
            this.MainPage.UseVisualStyleBackColor = true;
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(609, 409);
            this.StartButton.Margin = new System.Windows.Forms.Padding(4);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(133, 28);
            this.StartButton.TabIndex = 2;
            this.StartButton.TabStop = false;
            this.StartButton.Text = "Запустить сервер";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // PortTextBox
            // 
            this.PortTextBox.Location = new System.Drawing.Point(609, 310);
            this.PortTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.PortTextBox.Name = "PortTextBox";
            this.PortTextBox.Size = new System.Drawing.Size(132, 20);
            this.PortTextBox.TabIndex = 1;
            this.PortTextBox.Text = "8080";
            // 
            // AddressTextBox
            // 
            this.AddressTextBox.Location = new System.Drawing.Point(609, 248);
            this.AddressTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.AddressTextBox.Name = "AddressTextBox";
            this.AddressTextBox.Size = new System.Drawing.Size(132, 20);
            this.AddressTextBox.TabIndex = 0;
            this.AddressTextBox.Text = "127.0.0.1";
            // 
            // GamePage
            // 
            this.GamePage.Controls.Add(this.platform4);
            this.GamePage.Controls.Add(this.platform3);
            this.GamePage.Controls.Add(this.platform2);
            this.GamePage.Controls.Add(this.platform1);
            this.GamePage.Controls.Add(this.player4);
            this.GamePage.Controls.Add(this.player3);
            this.GamePage.Controls.Add(this.player2);
            this.GamePage.Controls.Add(this.player1);
            this.GamePage.Controls.Add(this.background);
            this.GamePage.Location = new System.Drawing.Point(4, 5);
            this.GamePage.Margin = new System.Windows.Forms.Padding(4);
            this.GamePage.Name = "GamePage";
            this.GamePage.Padding = new System.Windows.Forms.Padding(4);
            this.GamePage.Size = new System.Drawing.Size(1350, 616);
            this.GamePage.TabIndex = 0;
            this.GamePage.Text = "tabPage1";
            this.GamePage.UseVisualStyleBackColor = true;
            // 
            // platform4
            // 
            this.platform4.Image = ((System.Drawing.Image)(resources.GetObject("platform4.Image")));
            this.platform4.Location = new System.Drawing.Point(1276, 382);
            this.platform4.Name = "platform4";
            this.platform4.Size = new System.Drawing.Size(256, 41);
            this.platform4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.platform4.TabIndex = 11;
            this.platform4.TabStop = false;
            this.platform4.Tag = "platform";
            // 
            // platform3
            // 
            this.platform3.Image = ((System.Drawing.Image)(resources.GetObject("platform3.Image")));
            this.platform3.Location = new System.Drawing.Point(877, 469);
            this.platform3.Name = "platform3";
            this.platform3.Size = new System.Drawing.Size(256, 41);
            this.platform3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.platform3.TabIndex = 10;
            this.platform3.TabStop = false;
            this.platform3.Tag = "platform";
            // 
            // platform2
            // 
            this.platform2.Image = ((System.Drawing.Image)(resources.GetObject("platform2.Image")));
            this.platform2.Location = new System.Drawing.Point(457, 529);
            this.platform2.Name = "platform2";
            this.platform2.Size = new System.Drawing.Size(256, 41);
            this.platform2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.platform2.TabIndex = 9;
            this.platform2.TabStop = false;
            this.platform2.Tag = "platform";
            // 
            // platform1
            // 
            this.platform1.Image = ((System.Drawing.Image)(resources.GetObject("platform1.Image")));
            this.platform1.Location = new System.Drawing.Point(110, 575);
            this.platform1.Name = "platform1";
            this.platform1.Size = new System.Drawing.Size(256, 41);
            this.platform1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.platform1.TabIndex = 7;
            this.platform1.TabStop = false;
            this.platform1.Tag = "platform";
            // 
            // player4
            // 
            this.player4.Image = global::Server.Properties.Resources.slime4;
            this.player4.Location = new System.Drawing.Point(-100, -100);
            this.player4.Name = "player4";
            this.player4.Size = new System.Drawing.Size(50, 50);
            this.player4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player4.TabIndex = 14;
            this.player4.TabStop = false;
            // 
            // player3
            // 
            this.player3.Image = global::Server.Properties.Resources.slime3;
            this.player3.Location = new System.Drawing.Point(-100, -100);
            this.player3.Name = "player3";
            this.player3.Size = new System.Drawing.Size(50, 50);
            this.player3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player3.TabIndex = 13;
            this.player3.TabStop = false;
            // 
            // player2
            // 
            this.player2.Image = global::Server.Properties.Resources.slime2;
            this.player2.Location = new System.Drawing.Point(-100, -100);
            this.player2.Name = "player2";
            this.player2.Size = new System.Drawing.Size(50, 50);
            this.player2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player2.TabIndex = 12;
            this.player2.TabStop = false;
            // 
            // player1
            // 
            this.player1.Image = global::Server.Properties.Resources.slime1;
            this.player1.Location = new System.Drawing.Point(-100, -100);
            this.player1.Name = "player1";
            this.player1.Size = new System.Drawing.Size(50, 50);
            this.player1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player1.TabIndex = 8;
            this.player1.TabStop = false;
            // 
            // background
            // 
            this.background.Image = global::Server.Properties.Resources.layer_1;
            this.background.Location = new System.Drawing.Point(0, 0);
            this.background.Name = "background";
            this.background.Size = new System.Drawing.Size(1350, 616);
            this.background.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.background.TabIndex = 6;
            this.background.TabStop = false;
            // 
            // PlayerCountTextBox
            // 
            this.PlayerCountTextBox.Location = new System.Drawing.Point(610, 373);
            this.PlayerCountTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.PlayerCountTextBox.Name = "PlayerCountTextBox";
            this.PlayerCountTextBox.Size = new System.Drawing.Size(132, 20);
            this.PlayerCountTextBox.TabIndex = 4;
            this.PlayerCountTextBox.Text = "2";
            // 
            // IpLabel
            // 
            this.IpLabel.AutoSize = true;
            this.IpLabel.Location = new System.Drawing.Point(662, 231);
            this.IpLabel.Name = "IpLabel";
            this.IpLabel.Size = new System.Drawing.Size(17, 13);
            this.IpLabel.TabIndex = 10;
            this.IpLabel.Text = "IP";
            // 
            // PlayerCountLabel
            // 
            this.PlayerCountLabel.AutoSize = true;
            this.PlayerCountLabel.Location = new System.Drawing.Point(620, 356);
            this.PlayerCountLabel.Name = "PlayerCountLabel";
            this.PlayerCountLabel.Size = new System.Drawing.Size(110, 13);
            this.PlayerCountLabel.TabIndex = 9;
            this.PlayerCountLabel.Text = "Количество игроков";
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Location = new System.Drawing.Point(662, 293);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(32, 13);
            this.PortLabel.TabIndex = 8;
            this.PortLabel.Text = "Порт";
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1359, 625);
            this.Controls.Add(this.MainTabControl);
            this.Name = "ServerForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ServerForm_Load);
            this.MainTabControl.ResumeLayout(false);
            this.MainPage.ResumeLayout(false);
            this.MainPage.PerformLayout();
            this.GamePage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.platform4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.platform3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.platform2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.platform1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.background)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage GamePage;
        private System.Windows.Forms.PictureBox platform4;
        private System.Windows.Forms.PictureBox platform3;
        private System.Windows.Forms.PictureBox platform2;
        private System.Windows.Forms.PictureBox platform1;
        private System.Windows.Forms.PictureBox player1;
        private System.Windows.Forms.PictureBox background;
        private System.Windows.Forms.TabPage MainPage;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.TextBox PortTextBox;
        private System.Windows.Forms.TextBox AddressTextBox;
        private System.Windows.Forms.PictureBox player4;
        private System.Windows.Forms.PictureBox player3;
        private System.Windows.Forms.PictureBox player2;
        private System.Windows.Forms.TextBox PlayerCountTextBox;
        private System.Windows.Forms.Label IpLabel;
        private System.Windows.Forms.Label PlayerCountLabel;
        private System.Windows.Forms.Label PortLabel;
    }
}

