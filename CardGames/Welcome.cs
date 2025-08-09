namespace CardGames
{
    public partial class welcome_screen : Form
    {
        public welcome_screen()
        {
            InitializeComponent();
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            // Closing application
            //https://www.c-sharpcorner.com/UploadFile/c713c3/how-to-exit-in-C-Sharp/

            //System.Windows.Forms.Application.Exit();
            //Application.ExitThread(); //not certain about this one
            Application.Exit();
        }

        private void Play_Black_Jack_Click(object sender, EventArgs e)
        {
            var blackJack = new Black_Jack();
            blackJack.Show();

            this.Hide();
        }

        private void Play_FCD_Click(object sender, EventArgs e)
        {
            var FCD = new Five_Card_Draw();
            FCD.Show();

            this.Hide();
        }
    }
}
