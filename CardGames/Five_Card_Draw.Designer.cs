namespace CardGames
{
    partial class Five_Card_Draw
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Five_Card_Draw));
            PlayerCard1 = new PictureBox();
            PlayerCard2 = new PictureBox();
            PlayerCard3 = new PictureBox();
            PlayerCard4 = new PictureBox();
            PlayerCard5 = new PictureBox();
            DealerCard5 = new PictureBox();
            DealerCard4 = new PictureBox();
            DealerCard3 = new PictureBox();
            DealerCard2 = new PictureBox();
            DealerCard1 = new PictureBox();
            Main_btn = new Button();
            Exit_btn = new Button();
            game_msg = new Label();
            playerResult = new Label();
            dealerResult = new Label();
            ((System.ComponentModel.ISupportInitialize)PlayerCard1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PlayerCard2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PlayerCard3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PlayerCard4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PlayerCard5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DealerCard5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DealerCard4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DealerCard3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DealerCard2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DealerCard1).BeginInit();
            SuspendLayout();
            // 
            // PlayerCard1
            // 
            PlayerCard1.Image = (Image)resources.GetObject("PlayerCard1.Image");
            PlayerCard1.Location = new Point(250, 341);
            PlayerCard1.Name = "PlayerCard1";
            PlayerCard1.Size = new Size(117, 160);
            PlayerCard1.TabIndex = 4;
            PlayerCard1.TabStop = false;
            PlayerCard1.Click += PlayerCard1_Click;
            // 
            // PlayerCard2
            // 
            PlayerCard2.Image = (Image)resources.GetObject("PlayerCard2.Image");
            PlayerCard2.Location = new Point(373, 341);
            PlayerCard2.Name = "PlayerCard2";
            PlayerCard2.Size = new Size(117, 160);
            PlayerCard2.TabIndex = 5;
            PlayerCard2.TabStop = false;
            PlayerCard2.Click += PlayerCard2_Click;
            // 
            // PlayerCard3
            // 
            PlayerCard3.Image = (Image)resources.GetObject("PlayerCard3.Image");
            PlayerCard3.Location = new Point(496, 341);
            PlayerCard3.Name = "PlayerCard3";
            PlayerCard3.Size = new Size(117, 160);
            PlayerCard3.TabIndex = 6;
            PlayerCard3.TabStop = false;
            PlayerCard3.Click += PlayerCard3_Click;
            // 
            // PlayerCard4
            // 
            PlayerCard4.Image = (Image)resources.GetObject("PlayerCard4.Image");
            PlayerCard4.Location = new Point(619, 341);
            PlayerCard4.Name = "PlayerCard4";
            PlayerCard4.Size = new Size(117, 160);
            PlayerCard4.TabIndex = 7;
            PlayerCard4.TabStop = false;
            PlayerCard4.Click += PlayerCard4_Click;
            // 
            // PlayerCard5
            // 
            PlayerCard5.Image = (Image)resources.GetObject("PlayerCard5.Image");
            PlayerCard5.Location = new Point(742, 341);
            PlayerCard5.Name = "PlayerCard5";
            PlayerCard5.Size = new Size(117, 160);
            PlayerCard5.TabIndex = 8;
            PlayerCard5.TabStop = false;
            PlayerCard5.Click += PlayerCard5_Click;
            // 
            // DealerCard5
            // 
            DealerCard5.Image = (Image)resources.GetObject("DealerCard5.Image");
            DealerCard5.Location = new Point(742, 21);
            DealerCard5.Name = "DealerCard5";
            DealerCard5.Size = new Size(117, 160);
            DealerCard5.TabIndex = 13;
            DealerCard5.TabStop = false;
            // 
            // DealerCard4
            // 
            DealerCard4.Image = (Image)resources.GetObject("DealerCard4.Image");
            DealerCard4.Location = new Point(619, 21);
            DealerCard4.Name = "DealerCard4";
            DealerCard4.Size = new Size(117, 160);
            DealerCard4.TabIndex = 12;
            DealerCard4.TabStop = false;
            // 
            // DealerCard3
            // 
            DealerCard3.Image = (Image)resources.GetObject("DealerCard3.Image");
            DealerCard3.Location = new Point(496, 21);
            DealerCard3.Name = "DealerCard3";
            DealerCard3.Size = new Size(117, 160);
            DealerCard3.TabIndex = 11;
            DealerCard3.TabStop = false;
            // 
            // DealerCard2
            // 
            DealerCard2.Image = (Image)resources.GetObject("DealerCard2.Image");
            DealerCard2.Location = new Point(373, 21);
            DealerCard2.Name = "DealerCard2";
            DealerCard2.Size = new Size(117, 160);
            DealerCard2.TabIndex = 10;
            DealerCard2.TabStop = false;
            // 
            // DealerCard1
            // 
            DealerCard1.Image = (Image)resources.GetObject("DealerCard1.Image");
            DealerCard1.Location = new Point(250, 21);
            DealerCard1.Name = "DealerCard1";
            DealerCard1.Size = new Size(117, 160);
            DealerCard1.TabIndex = 9;
            DealerCard1.TabStop = false;
            // 
            // Main_btn
            // 
            Main_btn.Font = new Font("Malgun Gothic", 12F);
            Main_btn.Location = new Point(496, 526);
            Main_btn.Name = "Main_btn";
            Main_btn.Size = new Size(117, 53);
            Main_btn.TabIndex = 14;
            Main_btn.Text = "Play";
            Main_btn.UseVisualStyleBackColor = true;
            Main_btn.Click += Main_btn_Click;
            // 
            // Exit_btn
            // 
            Exit_btn.Font = new Font("Malgun Gothic", 12F);
            Exit_btn.Location = new Point(12, 543);
            Exit_btn.Name = "Exit_btn";
            Exit_btn.Size = new Size(117, 53);
            Exit_btn.TabIndex = 15;
            Exit_btn.Text = "Exit";
            Exit_btn.UseVisualStyleBackColor = true;
            Exit_btn.Click += Exit_btn_Click;
            // 
            // game_msg
            // 
            game_msg.AutoSize = true;
            game_msg.Font = new Font("Malgun Gothic", 15F, FontStyle.Regular, GraphicsUnit.Point, 129);
            game_msg.ImageAlign = ContentAlignment.TopLeft;
            game_msg.Location = new Point(483, 246);
            game_msg.Name = "game_msg";
            game_msg.Size = new Size(150, 28);
            game_msg.TabIndex = 16;
            game_msg.Text = "Five Card Draw";
            // 
            // playerResult
            // 
            playerResult.AutoSize = true;
            playerResult.Font = new Font("Malgun Gothic", 15F, FontStyle.Regular, GraphicsUnit.Point, 129);
            playerResult.ImageAlign = ContentAlignment.TopLeft;
            playerResult.Location = new Point(483, 291);
            playerResult.Name = "playerResult";
            playerResult.Size = new Size(0, 28);
            playerResult.TabIndex = 17;
            // 
            // dealerResult
            // 
            dealerResult.AutoSize = true;
            dealerResult.Font = new Font("Malgun Gothic", 15F, FontStyle.Regular, GraphicsUnit.Point, 129);
            dealerResult.ImageAlign = ContentAlignment.TopLeft;
            dealerResult.Location = new Point(483, 208);
            dealerResult.Name = "dealerResult";
            dealerResult.Size = new Size(0, 28);
            dealerResult.TabIndex = 18;
            // 
            // Five_Card_Draw
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1160, 608);
            Controls.Add(dealerResult);
            Controls.Add(playerResult);
            Controls.Add(game_msg);
            Controls.Add(Exit_btn);
            Controls.Add(Main_btn);
            Controls.Add(DealerCard5);
            Controls.Add(DealerCard4);
            Controls.Add(DealerCard3);
            Controls.Add(DealerCard2);
            Controls.Add(DealerCard1);
            Controls.Add(PlayerCard5);
            Controls.Add(PlayerCard4);
            Controls.Add(PlayerCard3);
            Controls.Add(PlayerCard2);
            Controls.Add(PlayerCard1);
            Name = "Five_Card_Draw";
            Text = "Five_Card_Draw";
            ((System.ComponentModel.ISupportInitialize)PlayerCard1).EndInit();
            ((System.ComponentModel.ISupportInitialize)PlayerCard2).EndInit();
            ((System.ComponentModel.ISupportInitialize)PlayerCard3).EndInit();
            ((System.ComponentModel.ISupportInitialize)PlayerCard4).EndInit();
            ((System.ComponentModel.ISupportInitialize)PlayerCard5).EndInit();
            ((System.ComponentModel.ISupportInitialize)DealerCard5).EndInit();
            ((System.ComponentModel.ISupportInitialize)DealerCard4).EndInit();
            ((System.ComponentModel.ISupportInitialize)DealerCard3).EndInit();
            ((System.ComponentModel.ISupportInitialize)DealerCard2).EndInit();
            ((System.ComponentModel.ISupportInitialize)DealerCard1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox PlayerCard1;
        private PictureBox PlayerCard2;
        private PictureBox PlayerCard3;
        private PictureBox PlayerCard4;
        private PictureBox PlayerCard5;
        private PictureBox DealerCard5;
        private PictureBox DealerCard4;
        private PictureBox DealerCard3;
        private PictureBox DealerCard2;
        private PictureBox DealerCard1;
        private Button Main_btn;
        private Button Exit_btn;
        private Label game_msg;
        private Label playerResult;
        private Label dealerResult;
    }
}