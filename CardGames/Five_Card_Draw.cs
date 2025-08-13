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
        (int, int)[] playerHand = new (int, int)[5];
        String[] playerHandImage = new String[5];
        bool[] playerHandExchange = new bool[5];

        // used to keep a track of dealer's hand
        (int, int)[] dealerHand = new (int, int)[5];
        String[] dealerHandImage = new String[5];
        bool[] dealerHandExchange = new bool[5];

        // used to keep a track of card's value inside the deck and its availability during the game
        //int[,] cardDecks = new int[4, 13];
        //bool[,] cardDeckTrack = new bool[4, 13];
        (int, int)[] cardDecks = new (int, int)[52];
        (int, bool)[] cardDeckTrack = new (int, bool)[52];

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
                gameStart = true;

                // reset the hands of both player and dealer
                for (int i = 0; i < 5; i++)
                {
                    playerHand[i] = (0, 0);
                    dealerHand[i] = (0, 0);
                }


                /* resets the card deck but NOT USED
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 13; j++)
                    {
                        //cardDecks[i, j] = (j + 1);
                        //cardDeckTrack[i, j] = true;
                        cardDecks[j] = (i, (j + 1));
                    }
                }
                */

                // reset the card deck
                // card suit order: Ace, Heart, Club, Diamond
                int cardSuit = 0;
                int cardValue = 0;

                for (int i = 0; i < 52; i++)
                {
                    cardDecks[i] = (cardSuit, cardValue);
                    cardDeckTrack[i] = (cardSuit, true);

                    cardValue = cardValue + 1;

                    if (cardValue > 12)
                    {
                        cardValue = 0;
                        cardSuit = cardSuit + 1;
                    }
                }


                //randomly distribute the cards to both player and the dealer
                for (int i = 0; i < 5; i++)
                {
                    //draw a card out of deck (52 cards in total)
                    int playerDraw = rand.Next(0, 52);

                    //check if the drawn card is already drawn out before
                    //if yes, keep drawing until it draws a new one that hasn't been drawn before
                    while (cardDeckTrack[playerDraw].Item2 == false)
                    {
                        playerDraw = rand.Next(0, 52);
                    }

                    //give drawn card to player's hand
                    playerHand[i] = cardDecks[playerDraw];

                    //set the image of the drawn card that was given to the player
                    playerHandImage[i] = cardimages[playerHand[i].Item1, playerHand[i].Item2];

                    //set the value as false for whether if the player will exchange this hand
                    playerHandExchange[i] = false;

                    //set false to the position of the drawn card so that card doesn't re-appear when drawing again
                    cardDeckTrack[i] = (playerDraw, false);



                    //do the same as above for the dealer

                    //draw a card out of deck (52 cards in total)
                    int dealerDraw = rand.Next(0, 52);

                    //check if the drawn card is already drawn out before
                    //if yes, keep drawing until it draws a new one that hasn't been drawn before
                    while (cardDeckTrack[dealerDraw].Item2 == false)
                    {
                        dealerDraw = rand.Next(0, 52);
                    }

                    //give drawn card to dealer's hand
                    dealerHand[i] = cardDecks[dealerDraw];

                    //set the image of the drawn card that was given to the dealer
                    dealerHandImage[i] = cardimages[dealerHand[i].Item1, dealerHand[i].Item2];

                    //set the value as false of whether if the dealer will exchange this hand for now
                    dealerHandExchange[i] = false;

                    //set false to the position of the drawn card so that card doesn't re-appear when drawing again
                    cardDeckTrack[i] = (dealerDraw, false);
                }

                //flip the player's hands to front so they can see it
                PlayerCard1.Image = Image.FromFile(playerHandImage[0]);
                playerHandExchange[0] = false;

                PlayerCard2.Image = Image.FromFile(playerHandImage[1]);
                playerHandExchange[0] = false;

                PlayerCard3.Image = Image.FromFile(playerHandImage[2]);
                playerHandExchange[0] = false;

                PlayerCard4.Image = Image.FromFile(playerHandImage[3]);
                playerHandExchange[0] = false;

                PlayerCard5.Image = Image.FromFile(playerHandImage[4]);
                playerHandExchange[0] = false;

                DealerCard1.Image = Image.FromFile(@"card images\card back.png");
                DealerCard2.Image = Image.FromFile(@"card images\card back.png");
                DealerCard3.Image = Image.FromFile(@"card images\card back.png");
                DealerCard4.Image = Image.FromFile(@"card images\card back.png");
                DealerCard5.Image = Image.FromFile(@"card images\card back.png");

                game_msg.Text = "";
                playerResult.Text = "";
                dealerResult.Text = "";

                Main_btn.Text = "Keep";

            }

            // if the game is currently being played, the button should either be 'Change' or 'Keep'
            // depends on whether if the player wants to trade some of their cards or not.
            else if (gameStart)
            {

                // check if there are cards to be exchanged. If yes, do so.
                if (playerHandExchange[0] || playerHandExchange[1] || playerHandExchange[2] || playerHandExchange[3] || playerHandExchange[4])
                {
                    //iterate through the player's hand
                    for (int i = 0; i < playerHand.Length; i++)
                    {
                        //if there's a card to be exchanged, put that card back into the deck and randomly draw new one
                        if (playerHandExchange[i])
                        {
                            // the following portion of the codes (3 variables and bunch of else ifs)
                            // are used to grab a correct index of the 'cardDeckTrack' variable
                            int playerHandSuit = playerHand[i].Item1;
                            int playerHandValue = playerHand[i].Item2;
                            int deckIndex = 0;

                            if (playerHandSuit == 0)
                            {
                                deckIndex = playerHandValue + 0;
                            }

                            else if (playerHandSuit == 1)
                            {
                                deckIndex = playerHandValue + 13;
                            }

                            else if (playerHandSuit == 2)
                            {
                                deckIndex = playerHandValue + 26;
                            }

                            else if (playerHandSuit == 3)
                            {
                                deckIndex = playerHandValue + 39;
                            }

                            // the card that was meant to be exchanged has gone inside the deck
                            cardDeckTrack[deckIndex].Item2 = true;

                            // Now, randomly re-draw the card to replace the exchanged card
                            int playerReDraw = rand.Next(0, 52);

                            // check if the drawn card is already drawn out before
                            // if yes, keep drawing until it draws a new one that hasn't been drawn before
                            while (cardDeckTrack[playerReDraw].Item2 == false)
                            {
                                playerReDraw = rand.Next(0, 52);
                            }

                            // give newly drawn card to player's hand
                            playerHand[i] = cardDecks[playerReDraw];

                            // set the image of the newly drawn card that was given to the player
                            playerHandImage[i] = cardimages[playerHand[i].Item1, playerHand[i].Item2];

                            // set the value as false for this position of the player's hand
                            playerHandExchange[i] = false;

                            //set false to the position of the newly drawn card so that card doesn't re-appear later
                            cardDeckTrack[i] = (playerReDraw, false);
                        }
                    }
                }

                /* probably pointless to change the card display since it'll do it below
                PlayerCard1.Image = Image.FromFile(playerHandImage[0]);
                PlayerCard2.Image = Image.FromFile(playerHandImage[1]);
                PlayerCard3.Image = Image.FromFile(playerHandImage[2]);
                PlayerCard4.Image = Image.FromFile(playerHandImage[3]);
                PlayerCard5.Image = Image.FromFile(playerHandImage[4]);
                */

                // iterate through player's hand to re-organize the cards based on their values
                for (int i = 0; i < playerHand.Length; i++)
                {
                    for (int j = i; j < playerHand.Length; j++)
                    {
                        // if the player's card that's at the front position has lower value than
                        // the card at the back position, switch them.
                        if (playerHand[i].Item2 < playerHand[j].Item2)
                        {
                            int hold1 = playerHand[i].Item1;
                            int hold2 = playerHand[i].Item2;
                            String holdImage = playerHandImage[i];

                            playerHand[i].Item1 = playerHand[j].Item1;
                            playerHand[i].Item2 = playerHand[j].Item2;
                            playerHandImage[i] = playerHandImage[j];
                            playerHand[j].Item1 = hold1;
                            playerHand[j].Item2 = hold2;
                            playerHandImage[j] = holdImage;
                        }

                        // if the player's card that's at the front position has same value as
                        // the card at the back position, compare their suits.
                        else if (playerHand[i].Item2 == playerHand[j].Item2)
                        {
                            if (playerHand[i].Item1 < playerHand[j].Item1)
                            {
                                int hold1 = playerHand[i].Item1;
                                int hold2 = playerHand[i].Item2;
                                String holdImage = playerHandImage[i];

                                playerHand[i].Item1 = playerHand[j].Item1;
                                playerHand[i].Item2 = playerHand[j].Item2;
                                playerHandImage[i] = playerHandImage[j];
                                playerHand[j].Item1 = hold1;
                                playerHand[j].Item2 = hold2;
                                playerHandImage[j] = holdImage;
                            }
                        }
                    }
                }


                PlayerCard1.Image = Image.FromFile(playerHandImage[0]);
                PlayerCard2.Image = Image.FromFile(playerHandImage[1]);
                PlayerCard3.Image = Image.FromFile(playerHandImage[2]);
                PlayerCard4.Image = Image.FromFile(playerHandImage[3]);
                PlayerCard5.Image = Image.FromFile(playerHandImage[4]);

                DealerCard1.Image = Image.FromFile(dealerHandImage[0]);
                DealerCard2.Image = Image.FromFile(dealerHandImage[1]);
                DealerCard3.Image = Image.FromFile(dealerHandImage[2]);
                DealerCard4.Image = Image.FromFile(dealerHandImage[3]);
                DealerCard5.Image = Image.FromFile(dealerHandImage[4]);

                //THIS PART SEEMS TO CAUSE SOME ISSUE WHERE THE CARDS THAT ARE MEANT TO BE KEPT CHANGES

                // Now, determine the value of player/dealer's hand
                int playerValue = cardJudge.judgeValue(playerHand);
                int dealerValue = cardJudge.judgeValue(dealerHand);



                //player hand message

                //royal flush
                if (playerValue == 10)
                {
                    playerResult.Text = "Royal Flush";
                }

                //straight flush
                else if (playerValue == 9)
                {
                    playerResult.Text = "Straight Flush";
                }

                //four of a kind
                else if (playerValue == 8)
                {
                    playerResult.Text = "Four of a kind";
                }

                //full house
                else if (playerValue == 7)
                {
                    playerResult.Text = "Full House";
                }

                //flush
                else if (playerValue == 6)
                {
                    playerResult.Text = "Flush";
                }

                //straight
                else if (playerValue == 5)
                {
                    playerResult.Text = "Straight";
                }

                //three of a kind
                else if (playerValue == 4)
                {
                    playerResult.Text = "Three of a kind";
                }

                //two pair
                else if (playerValue == 3)
                {
                    playerResult.Text = "Two Pair";
                }

                //one pair
                else if (playerValue == 2)
                {
                    playerResult.Text = "One Pair";
                }

                //no pair
                else if (playerValue == 1)
                {
                    playerResult.Text = "No Pair";
                }



                //dealer hand message

                //straight flush
                if (dealerValue == 9)
                {
                    dealerResult.Text = "Straight Flush";
                }

                //four of a kind
                else if (dealerValue == 8)
                {
                    dealerResult.Text = "Four of a kind";
                }

                //full house
                else if (dealerValue == 7)
                {
                    dealerResult.Text = "Full House";
                }

                //flush
                else if (dealerValue == 6)
                {
                    dealerResult.Text = "Flush";
                }

                //straight
                else if (dealerValue == 5)
                {
                    dealerResult.Text = "Straight";
                }

                //three of a kind
                else if (dealerValue == 4)
                {
                    dealerResult.Text = "Three of a kind";
                }

                //two pair
                else if (dealerValue == 3)
                {
                    dealerResult.Text = "Two Pair";
                }

                //one pair
                else if (dealerValue == 2)
                {
                    dealerResult.Text = "One Pair";
                }

                //no pair
                else if (dealerValue == 1)
                {
                    dealerResult.Text = "No Pair";
                }


                // if player has higher value, player wins
                if (playerValue > dealerValue)
                {
                    game_msg.Text = "Player Wins!";
                }

                // if dealer has higher value, player loses
                else if (playerValue < dealerValue)
                {
                    game_msg.Text = "Player Loses";
                }

                // if both player and dealer have same value, it's a draw
                else
                {
                    game_msg.Text = "Draw";
                }

                gameStart = false;
                Main_btn.Text = "Play";

                //comment end
            }
        }

        // make player's cards clickable so it can be set to whether to keep it or exchange it
        private void PlayerCard1_Click(object sender, EventArgs e)
        {
            // make the card only clickable while the game is being played
            if (gameStart)
            {

                // if the card is back side, flip it to its front
                // and set false to 'playerHandExchange[0]'
                if (playerHandExchange[0] == true)
                {
                    PlayerCard1.Image = Image.FromFile(playerHandImage[0]);
                    playerHandExchange[0] = false;

                    // if all the cards are flipped front side, make the button text 'keep'
                    if (!playerHandExchange[0] && !playerHandExchange[1] && !playerHandExchange[2] && !playerHandExchange[3] && !playerHandExchange[4])
                    {
                        Main_btn.Text = "Keep";
                    }
                }

                // if the card is front side, flip it to its back
                // and set true to 'playerHandExchange[0]'
                else if (playerHandExchange[0] == false)
                {
                    PlayerCard1.Image = Image.FromFile(@"card images\card back.png");
                    playerHandExchange[0] = true;
                    Main_btn.Text = "Change";
                }
            }
        }

        private void PlayerCard2_Click(object sender, EventArgs e)
        {
            // make the card only clickable while the game is being played
            if (gameStart)
            {

                // if the card is back side, flip it to its front
                // and set false to 'playerHandExchange[0]'
                if (playerHandExchange[1] == true)
                {
                    PlayerCard2.Image = Image.FromFile(playerHandImage[1]);
                    playerHandExchange[1] = false;

                    // if all the cards are flipped front side, make the button text 'keep'
                    if (!playerHandExchange[0] && !playerHandExchange[1] && !playerHandExchange[2] && !playerHandExchange[3] && !playerHandExchange[4])
                    {
                        Main_btn.Text = "Keep";
                    }
                }

                // if the card is front side, flip it to its back
                // and set true to 'playerHandExchange[0]'
                else if (playerHandExchange[1] == false)
                {
                    PlayerCard2.Image = Image.FromFile(@"card images\card back.png");
                    playerHandExchange[1] = true;
                    Main_btn.Text = "Change";
                }
            }
        }

        private void PlayerCard3_Click(object sender, EventArgs e)
        {
            // make the card only clickable while the game is being played
            if (gameStart)
            {

                // if the card is back side, flip it to its front
                // and set false to 'playerHandExchange[0]'
                if (playerHandExchange[2] == true)
                {
                    PlayerCard3.Image = Image.FromFile(playerHandImage[2]);
                    playerHandExchange[2] = false;

                    // if all the cards are flipped front side, make the button text 'keep'
                    if (!playerHandExchange[0] && !playerHandExchange[1] && !playerHandExchange[2] && !playerHandExchange[3] && !playerHandExchange[4])
                    {
                        Main_btn.Text = "Keep";
                    }
                }

                // if the card is front side, flip it to its back
                // and set true to 'playerHandExchange[0]'
                else if (playerHandExchange[2] == false)
                {
                    PlayerCard3.Image = Image.FromFile(@"card images\card back.png");
                    playerHandExchange[2] = true;
                    Main_btn.Text = "Change";
                }
            }
        }

        private void PlayerCard4_Click(object sender, EventArgs e)
        {
            // make the card only clickable while the game is being played
            if (gameStart)
            {

                // if the card is back side, flip it to its front
                // and set false to 'playerHandExchange[0]'
                if (playerHandExchange[3] == true)
                {
                    PlayerCard4.Image = Image.FromFile(playerHandImage[3]);
                    playerHandExchange[3] = false;

                    // if all the cards are flipped front side, make the button text 'keep'
                    if (!playerHandExchange[0] && !playerHandExchange[1] && !playerHandExchange[2] && !playerHandExchange[3] && !playerHandExchange[4])
                    {
                        Main_btn.Text = "Keep";
                    }
                }

                // if the card is front side, flip it to its back
                // and set true to 'playerHandExchange[0]'
                else if (playerHandExchange[3] == false)
                {
                    PlayerCard4.Image = Image.FromFile(@"card images\card back.png");
                    playerHandExchange[3] = true;
                    Main_btn.Text = "Change";
                }
            }
        }

        private void PlayerCard5_Click(object sender, EventArgs e)
        {
            // make the card only clickable while the game is being played
            if (gameStart)
            {

                // if the card is back side, flip it to its front
                // and set false to 'playerHandExchange[0]'
                if (playerHandExchange[4] == true)
                {
                    PlayerCard5.Image = Image.FromFile(playerHandImage[4]);
                    playerHandExchange[4] = false;

                    // if all the cards are flipped front side, make the button text 'keep'
                    if (!playerHandExchange[0] && !playerHandExchange[1] && !playerHandExchange[2] && !playerHandExchange[3] && !playerHandExchange[4])
                    {
                        Main_btn.Text = "Keep";
                    }
                }

                // if the card is front side, flip it to its back
                // and set true to 'playerHandExchange[0]'
                else if (playerHandExchange[4] == false)
                {
                    PlayerCard5.Image = Image.FromFile(@"card images\card back.png");
                    playerHandExchange[4] = true;
                    Main_btn.Text = "Change";
                }
            }
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            gameStart = false;

            var welcome = new welcome_screen();
            welcome.Show();

            this.Hide();
        }
    }
}
