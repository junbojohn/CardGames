using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardGames
{
    public partial class Five_Card_Draw : Form
    {
        // used to determine if the game is being played or not
        bool gameStart = false;

        // used to keep a track of player's hand
        int[] playerHand = new int[5];
        String[] playerHandImage = new String[5];
        bool[] playerHandExchange = new bool[5];

        // used to keep a track of dealer's hand
        int[] dealerHand = new int[5];
        String[] dealerHandImage = new String[5];
        bool[] dealerHandExchange = new bool[5];

        // used to keep a track of card's value inside the deck and its availability during the game
        int[,] cardDecks = new int[4, 13];
        bool[,] cardDeckTrack = new bool[4, 13];

        // used to determine the value of the player and dealer's hand
        FCD_Value_Checker cardJudge = new FCD_Value_Checker();

        // use random number generator to choose number from 1 to 52
        //https://stackoverflow.com/questions/2706500/how-do-i-generate-a-random-integer-in-c
        Random rand = new Random();
        //rand.Next(1, 14);

        String[,] cardimages = new String[4, 13];



        public Five_Card_Draw()
        {
            InitializeComponent();

            // these lines of codes will insert the image location of each cards in the deck

            // Spades
            cardimages[0, 0] = @"card images\spade A.png";
            cardimages[0, 1] = @"card images\spade 2.png";
            cardimages[0, 2] = @"card images\spade 3.png";
            cardimages[0, 3] = @"card images\spade 4.png";
            cardimages[0, 4] = @"card images\spade 5.png";
            cardimages[0, 5] = @"card images\spade 6.png";
            cardimages[0, 6] = @"card images\spade 7.png";
            cardimages[0, 7] = @"card images\spade 8.png";
            cardimages[0, 8] = @"card images\spade 9.png";
            cardimages[0, 9] = @"card images\spade 10.png";
            cardimages[0, 10] = @"card images\spade J.png";
            cardimages[0, 11] = @"card images\spade Q.png";
            cardimages[0, 12] = @"card images\spade K.png";

            // Hearts
            cardimages[1, 0] = @"card images\heart A.png";
            cardimages[1, 1] = @"card images\heart 2.png";
            cardimages[1, 2] = @"card images\heart 3.png";
            cardimages[1, 3] = @"card images\heart 4.png";
            cardimages[1, 4] = @"card images\heart 5.png";
            cardimages[1, 5] = @"card images\heart 6.png";
            cardimages[1, 6] = @"card images\heart 7.png";
            cardimages[1, 7] = @"card images\heart 8.png";
            cardimages[1, 8] = @"card images\heart 9.png";
            cardimages[1, 9] = @"card images\heart 10.png";
            cardimages[1, 10] = @"card images\heart J.png";
            cardimages[1, 11] = @"card images\heart Q.png";
            cardimages[1, 12] = @"card images\heart K.png";

            // Clubs
            cardimages[2, 0] = @"card images\club A.png";
            cardimages[2, 1] = @"card images\club 2.png";
            cardimages[2, 2] = @"card images\club 3.png";
            cardimages[2, 3] = @"card images\club 4.png";
            cardimages[2, 4] = @"card images\club 5.png";
            cardimages[2, 5] = @"card images\club 6.png";
            cardimages[2, 6] = @"card images\club 7.png";
            cardimages[2, 7] = @"card images\club 8.png";
            cardimages[2, 8] = @"card images\club 9.png";
            cardimages[2, 9] = @"card images\club 10.png";
            cardimages[2, 10] = @"card images\club J.png";
            cardimages[2, 11] = @"card images\club Q.png";
            cardimages[2, 12] = @"card images\club K.png";

            // Diamonds
            cardimages[3, 0] = @"card images\diamond A.png";
            cardimages[3, 1] = @"card images\diamond 2.png";
            cardimages[3, 2] = @"card images\diamond 3.png";
            cardimages[3, 3] = @"card images\diamond 4.png";
            cardimages[3, 4] = @"card images\diamond 5.png";
            cardimages[3, 5] = @"card images\diamond 6.png";
            cardimages[3, 6] = @"card images\diamond 7.png";
            cardimages[3, 7] = @"card images\diamond 8.png";
            cardimages[3, 8] = @"card images\diamond 9.png";
            cardimages[3, 9] = @"card images\diamond 10.png";
            cardimages[3, 10] = @"card images\diamond J.png";
            cardimages[3, 11] = @"card images\diamond Q.png";
            cardimages[3, 12] = @"card images\diamond K.png";

            //string imagePath = @"C:\Path\To\Your\Image.jpg"; 
            //pictureBox1.Image = Image.FromFile(imagePath);
        }

        private void Main_btn_Click(object sender, EventArgs e)
        {
            // if the game is currently not being played, start new game and reset the settings.
            if (!gameStart)
            {

                // reset the hands of both player and dealer
                for (int i = 0; i < 5; i++)
                {
                    playerHand[i] = 0;
                    dealerHand[i] = 0;
                }

                // reset the card deck
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 13; j++)
                    {
                        cardDecks[i, j] = (j + 1);
                        cardDeckTrack[i, j] = true;
                    }
                }


                for (int i = 0; i < playerHand.Length; i++)
                {
                    if (playerHandExchange[i])
                    {
                        Main_btn.Text = "Change";
                    }

                    else
                    {
                        Main_btn.Text = "Keep";
                    }
                }
                
            }

            // if the game is currently being played, the button should either be 'trade' or 'keep'
            // depends on whether if the player wants to trade some of their cards or not.
            else if (gameStart)
            {

                //inside here, I can check if the cards are clicked (make card click function outside of course)
                //and based on that, change the button text to 'change' so that card can be exchanged.

            }
        }

        // make player's card 1 clickable so it can be set to whether to keep it or exchange it
        private void PlayerCard1_Click(object sender, EventArgs e)
        {
            // make the card only clickable while the game is being played
            if (gameStart)
            {

                // if the card is back side, flip it to its front
                if (PlayerCard1.Image == Image.FromFile(@"card images\card back.png"))
                {
                    PlayerCard1.Image = Image.FromFile(playerHandImage[0]);
                }

                // if the card is front side, flip it to its back
                else if (PlayerCard1.Image == Image.FromFile(playerHandImage[0])) 
                {
                    PlayerCard1.Image = Image.FromFile(@"card images\card back.png");
                }

            }
        }
    }
}
