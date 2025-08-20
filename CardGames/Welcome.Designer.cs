namespace CardGames
{
    partial class welcome_screen
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Welcome_msg = new Label();
            Play_Black_Jack = new Button();
            Play_FCD = new Button();
            Black_Jack_desc = new Label();
            FCD_desc = new Label();
            Exit_btn = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // Welcome_msg
            // 
            Welcome_msg.AutoSize = true;
            Welcome_msg.Font = new Font("Malgun Gothic", 36F, FontStyle.Bold, GraphicsUnit.Point, 129);
            Welcome_msg.Location = new Point(99, 40);
            Welcome_msg.Name = "Welcome_msg";
            Welcome_msg.Size = new Size(599, 65);
            Welcome_msg.TabIndex = 0;
            Welcome_msg.Text = "Welcome to card games!";
            // 
            // Play_Black_Jack
            // 
            Play_Black_Jack.Font = new Font("Malgun Gothic", 12F);
            Play_Black_Jack.Location = new Point(74, 176);
            Play_Black_Jack.Name = "Play_Black_Jack";
            Play_Black_Jack.Size = new Size(111, 46);
            Play_Black_Jack.TabIndex = 1;
            Play_Black_Jack.Text = "Black Jack";
            Play_Black_Jack.UseVisualStyleBackColor = true;
            Play_Black_Jack.Click += Play_Black_Jack_Click;
            // 
            // Play_FCD
            // 
            Play_FCD.Font = new Font("Malgun Gothic", 12F);
            Play_FCD.Location = new Point(74, 292);
            Play_FCD.Name = "Play_FCD";
            Play_FCD.Size = new Size(111, 58);
            Play_FCD.TabIndex = 2;
            Play_FCD.Text = "Five Card Draw";
            Play_FCD.UseVisualStyleBackColor = true;
            Play_FCD.Click += Play_FCD_Click;
            // 
            // Black_Jack_desc
            // 
            Black_Jack_desc.AutoSize = true;
            Black_Jack_desc.Font = new Font("Malgun Gothic", 12F);
            Black_Jack_desc.Location = new Point(285, 189);
            Black_Jack_desc.Name = "Black_Jack_desc";
            Black_Jack_desc.Size = new Size(314, 21);
            Black_Jack_desc.TabIndex = 4;
            Black_Jack_desc.Text = "Play a game of Black Jack against dealer.";
            // 
            // FCD_desc
            // 
            FCD_desc.AutoSize = true;
            FCD_desc.Font = new Font("Malgun Gothic", 12F);
            FCD_desc.Location = new Point(285, 311);
            FCD_desc.Name = "FCD_desc";
            FCD_desc.Size = new Size(353, 21);
            FCD_desc.TabIndex = 5;
            FCD_desc.Text = "Play a game of Five Card Draw against dealer.";
            // 
            // Exit_btn
            // 
            Exit_btn.Font = new Font("Malgun Gothic", 12F);
            Exit_btn.Location = new Point(12, 436);
            Exit_btn.Name = "Exit_btn";
            Exit_btn.Size = new Size(111, 46);
            Exit_btn.TabIndex = 7;
            Exit_btn.Text = "Exit";
            Exit_btn.UseVisualStyleBackColor = true;
            Exit_btn.Click += Exit_btn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Malgun Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 129);
            label1.Location = new Point(460, 413);
            label1.Name = "label1";
            label1.Size = new Size(251, 25);
            label1.TabIndex = 8;
            label1.Text = "Developed by: Junbo Park";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Malgun Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 129);
            label2.Location = new Point(630, 457);
            label2.Name = "label2";
            label2.Size = new Size(81, 25);
            label2.TabIndex = 9;
            label2.Text = "Ver. 1.0";
            // 
            // welcome_screen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(723, 495);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Exit_btn);
            Controls.Add(FCD_desc);
            Controls.Add(Black_Jack_desc);
            Controls.Add(Play_FCD);
            Controls.Add(Play_Black_Jack);
            Controls.Add(Welcome_msg);
            Name = "welcome_screen";
            Text = "Card games";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Welcome_msg;
        private Button Play_Black_Jack;
        private Button Play_FCD;
        private Label Black_Jack_desc;
        private Label FCD_desc;
        private Button Exit_btn;
        private Label label1;
        private Label label2;
    }
}
