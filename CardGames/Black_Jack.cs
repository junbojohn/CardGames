using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class Black_Jack : Form
    {
        // used to determine if the game is being played or not
        bool gameStart = false;

        // used to keep a track of player's hand and its values
        int[] playerHand = new int[11];
        int playerHandValue = 0;
        bool[] playerAceTrack = new bool[11];

        // used to keep a track of dealer's hand and its values
        int[] dealerHand = new int[11];
        int dealerHandValue = 0;
        bool[] dealerAceTrack = new bool[11];

        // used to keep a track of card's value inside the deck and its availability during the game
        int[,] cardDecks = new int[4,13];
        bool[,] cardDeckTrack = new bool[4,13];

        // use random number generator to choose number from 1 to 52
        //https://stackoverflow.com/questions/2706500/how-do-i-generate-a-random-integer-in-c
        Random rand = new Random();
        //rand.Next(1, 14);

        String[,] cardimages = new String[4,13];

        public Black_Jack()
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

            //PlayerCard1.Image = Image.FromFile(@"card images\spade A.png");
        }

        private void Play_and_Hit_Click(object sender, EventArgs e)
        {
            // if the 'gameStart' is false(no game is being played), start the game and draw first card
            if (!gameStart)
            {
                gameStart = true;

                Play_and_Hit.Text = "Hit";
                Exit_and_Stop.Text = "Stop";

                //reset the card deck

                // this for loop will correctly insert card values from ace to king
                // with each of them having 4 cards. In total, there should be 52 cards.
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 13; j++)
                    {
                        cardDecks[i, j] = (j + 1);
                        cardDeckTrack[i, j] = true;
                    }
                }

                // reset both player and dealer's hands' values for every new game started
                playerHandValue = 0;
                dealerHandValue = 0;



                // this for loop will reset all the hands of the player and the dealer
                // it also resets the ace card tracking which will be used for ace card calculation
                for (int i = 0; i < 11; i++)
                {
                    playerHand[i] = 0;
                    playerAceTrack[i] = false;

                    dealerHand[i] = 0;
                    dealerAceTrack[i] = false;
                }

                // erase the cards that were drawn from both player and the dealer to reset for new game
                PlayerCard1.Image = null;
                PlayerCard2.Image = null;
                PlayerCard3.Image = null;
                PlayerCard4.Image = null;
                PlayerCard5.Image = null;
                PlayerCard6.Image = null;
                PlayerCard7.Image = null;
                PlayerCard8.Image = null;
                PlayerCard9.Image = null;
                PlayerCard10.Image = null;
                PlayerCard11.Image = null;

                DealerCard1.Image = null;
                DealerCard2.Image = null;
                DealerCard3.Image = null;
                DealerCard4.Image = null;
                DealerCard5.Image = null;
                DealerCard6.Image = null;
                DealerCard7.Image = null;
                DealerCard8.Image = null;
                DealerCard9.Image = null;
                DealerCard10.Image = null;
                DealerCard11.Image = null;

                Player_Hand.Text = "";
                Dealer_Hand.Text = "";
                Result_msg.Text = "";


                //draw first card and display

                // add the first card that the player hit from starting the game
                if (playerHand[0] == 0)
                {
                    // randomly choose between ace, heart, club, or diamond
                    int whichIcon = rand.Next(0, 4);

                    // randomly choose the value between ace to king
                    int whichValue = rand.Next(0, 13);

                    // hold the card based on the results of two variables above
                    int hittedCard = cardDecks[whichIcon, whichValue];

                    // take out the drawn card from the deck so that it won't reappear
                    cardDeckTrack[whichIcon, whichValue] = false;

                    // insert the 'hittedCard' that the player hit
                    playerHand[0] = hittedCard;



                    // sum up the value of the card that the player hit

                    // check if the first card is an ace. If yes, calculate that as value 14
                    if (playerHand[0] == 1)
                    {
                        playerHandValue = playerHandValue + 14;
                    }

                    // if it's not an ace, just simply sum it up as it is
                    else
                    {
                        playerHandValue = playerHandValue + hittedCard;
                    }

                    // display the image of the card that was drawn here
                    PlayerCard1.Image = Image.FromFile(cardimages[whichIcon, whichValue]);

                }

                // display the sum of player's hand's value
                Player_Hand.Text = "Your hand: " + playerHandValue;

            }

            // if the 'gameStart' is true(game is being played), draw the card
            else if (gameStart)
            {
                //draw the card and display

                // Iterate through player's hand until it runs into empty slot.
                for (int i = 0; i < playerHand.Length; i++)
                {
                    // Once the empty slot is found, add the card that the player drew from hitting
                    if (playerHand[i] == 0)
                    {
                        // randomly choose between ace, heart, club, or diamond
                        int whichIcon = rand.Next(0, 4);

                        // randomly choose the value between ace to king
                        int whichValue = rand.Next(0, 13);


                        // check if that card was already drawn out of the deck
                        // if that card is already drawn out, re-roll and try draw new card
                        while (!cardDeckTrack[whichIcon, whichValue])
                        {
                            // randomly choose between ace, heart, club, or diamond
                            whichIcon = rand.Next(0, 4);

                            // randomly choose the value between ace to king
                            whichValue = rand.Next(0, 13);

                            // if the newly drawn card is within the deck,
                            // break out of the while loop and draw as it is
                            if (cardDeckTrack[whichIcon, whichValue])
                            {
                                cardDeckTrack[whichIcon, whichValue] = false;
                                break;
                            }
                        }

                        // hold the card based on the results of two variables above
                        int hittedCard = cardDecks[whichIcon, whichValue];

                        // take out the drawn card from the deck so that it won't reappear
                        cardDeckTrack[whichIcon, whichValue] = false;

                        // insert the 'hittedCard' that the player hit
                        playerHand[i] = hittedCard;



                        // sum up the value of the card that the player hit

                        // check if drawn card is an ace. If yes, calculate as 14
                        if (playerHand[i] == 1)
                        {
                            playerHandValue = playerHandValue + 14;
                        }

                        // if it's not an ace, just simply sum it up as it is
                        else
                        {
                            playerHandValue = playerHandValue + hittedCard;
                        }

                        // update the display of the sum of player's hand's value
                        Player_Hand.Text = "Your hand: " + playerHandValue;

                        // display the image of the card that was drawn here
                        if (i == 1)
                        {
                            PlayerCard2.Image = Image.FromFile(cardimages[whichIcon, whichValue]);
                            break;
                        }

                        else if (i == 2)
                        {
                            PlayerCard3.Image = Image.FromFile(cardimages[whichIcon, whichValue]);
                            break;
                        }

                        else if (i == 3)
                        {
                            PlayerCard4.Image = Image.FromFile(cardimages[whichIcon, whichValue]);
                            break;
                        }

                        else if (i == 4)
                        {
                            PlayerCard5.Image = Image.FromFile(cardimages[whichIcon, whichValue]);
                            break;
                        }

                        else if (i == 5)
                        {
                            PlayerCard6.Image = Image.FromFile(cardimages[whichIcon, whichValue]);
                            break;
                        }

                        else if (i == 6)
                        {
                            PlayerCard7.Image = Image.FromFile(cardimages[whichIcon, whichValue]);
                            break;
                        }

                        else if (i == 7)
                        {
                            PlayerCard8.Image = Image.FromFile(cardimages[whichIcon, whichValue]);
                            break;
                        }

                        else if (i == 8)
                        {
                            PlayerCard9.Image = Image.FromFile(cardimages[whichIcon, whichValue]);
                            break;
                        }

                        else if (i == 9)
                        {
                            PlayerCard10.Image = Image.FromFile(cardimages[whichIcon, whichValue]);
                            break;
                        }

                        else if (i == 10)
                        {
                            PlayerCard11.Image = Image.FromFile(cardimages[whichIcon, whichValue]);
                            break;
                        }
                    }
                }

                // check if player is busted or not. If yes, check if the player has any ace card(s).
                // If not, then the player is busted and the dealer wins
                // If yes, calculate the player's hand's value so that it is less than 21
                // and give a player a choice to hit again or stop
                if (playerHandValue > 21)
                {
                    bool areThereAce = false;

                    // iterate through player's hand and check if there's any ace card(s)
                    for (int i = 0; i < playerHand.Length; i++)
                    {
                        // if there'a an ace within player's hand, re-calculate that as 1 instead of 14
                        // that way, the player won't get busted thanks to how ace cards are being calculated
                        if (playerHand[i] == 1)
                        {
                            
                            // check if the current ace card was checked its existence before.
                            // If not, then just simply re-calculate the player's hand's value
                            // If yes however, re-calculation will be ignored.
                            if (playerAceTrack[i] == false)
                            {
                                playerAceTrack[i] = true;

                                areThereAce = true;
                                playerHandValue = playerHandValue - 13;
                            }

                            // update the display of the sum of player's hand's value
                            Player_Hand.Text = "Your hand: " + playerHandValue;
                        }
                    }

                    // use 'areThereAce' variable to check if player had ace card.
                    // if yes, player's hand's value should be re-calculated to prevent them
                    // from being busted. Otherwise, their hand's value should exceed 21 and get busted
                    if (!areThereAce)
                    {
                        Player_Hand.Text = "Busted";
                        Result_msg.Text = "You lost";
                        gameStart = false;

                        Play_and_Hit.Text = "Play";
                        Exit_and_Stop.Text = "Exit";
                    } 
                }
            }
        }






        private void Exit_and_Stop_Click(object sender, EventArgs e)
        {
            // if 'gameStart' is false(no game is being played), exit back to the welcome screen
            if (!gameStart)
            {
                var welcome = new welcome_screen();
                welcome.Show();

                this.Hide();
            }

            // if 'gameStart' is true(game is being played), stop drawing and let dealer start drawing on its own
            else if (gameStart)
            {
                //draw first card and display

                // add the first card that the dealer hit
                if (dealerHand[0] == 0)
                {
                    // randomly choose between ace, heart, club, or diamond
                    int whichIcon = rand.Next(0, 4);

                    // randomly choose the value between ace to king
                    int whichValue = rand.Next(0, 13);


                    // check if that card was already drawn out of the deck
                    // if that card is already drawn out, re-roll and try draw new card
                    while (!cardDeckTrack[whichIcon, whichValue])
                    {
                        // randomly choose between ace, heart, club, or diamond
                        whichIcon = rand.Next(0, 4);

                        // randomly choose the value between ace to king
                        whichValue = rand.Next(0, 13);

                        // if the newly drawn card is within the deck,
                        // break out of the while loop and draw as it is
                        if (cardDeckTrack[whichIcon, whichValue])
                        {
                            cardDeckTrack[whichIcon, whichValue] = false;
                            break;
                        }
                    }

                    // hold the card based on the results of two variables above
                    int hittedCard = cardDecks[whichIcon, whichValue];

                    // insert the 'hittedCard' that the dealer hit
                    dealerHand[0] = hittedCard;

                    // sum up the value of the card that the dealer hit

                    // check if the first card is an ace. If yes, calculate that as value 14
                    if (dealerHand[0] == 1)
                    {
                        dealerHandValue = dealerHandValue + 14;
                    }

                    // if it's not an ace, just simply sum it up as it is
                    else
                    {
                        dealerHandValue = dealerHandValue + hittedCard;
                    }

                    // display the image of the card that was drawn here
                    DealerCard1.Image = Image.FromFile(cardimages[whichIcon, whichValue]);

                }

                Dealer_Hand.Text = "Dealer's hand: " + dealerHandValue;
            }



            // after drawing a first card for dealer, draw another card and so forth
            // based on dealer's hand's value

            // set the probability of whether the dealer should hit again or stop
            // based on the its hand's current value
            while (dealerHandValue < 21)
            {
                double hitChance = ((21.0 - dealerHandValue) / 21.0);

                // ERROR: something's wrong with probability calculation algorithm

                // determine whether to hit or not based on 'hitChance' variable's probability
                if (rand.NextDouble() < hitChance)
                {
                    // Iterate through dealer's hand until it runs into empty slot.
                    for (int i = 0; i < dealerHand.Length; i++)
                    {
                        // Once the empty slot is found, add the card that the dealer drew from hitting
                        if (dealerHand[i] == 0)
                        {
                            // randomly choose between ace, heart, club, or diamond
                            int whichIcon = rand.Next(0, 4);

                            // randomly choose the value between ace to king
                            int whichValue = rand.Next(0, 13);


                            // check if that card was already drawn out of the deck
                            // if that card is already drawn out, re-roll and try draw new card
                            while (!cardDeckTrack[whichIcon, whichValue])
                            {
                                // randomly choose between ace, heart, club, or diamond
                                whichIcon = rand.Next(0, 4);

                                // randomly choose the value between ace to king
                                whichValue = rand.Next(0, 13);

                                // if the newly drawn card is within the deck,
                                // break out of the while loop and draw as it is
                                if (cardDeckTrack[whichIcon, whichValue])
                                {
                                    cardDeckTrack[whichIcon, whichValue] = false;
                                    break;
                                }
                            }

                            // hold the card based on the results of two variables above
                            int hittedCard = cardDecks[whichIcon, whichValue];

                            // take out the drawn card from the deck so that it won't reappear
                            cardDeckTrack[whichIcon, whichValue] = false;

                            // insert the 'hittedCard' that the dealer hit
                            dealerHand[i] = hittedCard;



                            // sum up the value of the card that the dealer hit

                            // check if drawn card is an ace. If yes, calculate as 14
                            if (dealerHand[i] == 1)
                            {
                                dealerHandValue = dealerHandValue + 14;
                            }

                            // if it's not an ace, just simply sum it up as it is
                            else
                            {
                                dealerHandValue = dealerHandValue + hittedCard;
                            }

                            // update the display of the sum of dealer's hand's value
                            Dealer_Hand.Text = "Dealer hand: " + dealerHandValue;

                            // display the image of the card that was drawn here
                            if (i == 1)
                            {
                                DealerCard2.Image = Image.FromFile(cardimages[whichIcon, whichValue]);
                                break;
                            }

                            else if (i == 2)
                            {
                                DealerCard3.Image = Image.FromFile(cardimages[whichIcon, whichValue]);
                                break;
                            }

                            else if (i == 3)
                            {
                                DealerCard4.Image = Image.FromFile(cardimages[whichIcon, whichValue]);
                                break;
                            }

                            else if (i == 4)
                            {
                                DealerCard5.Image = Image.FromFile(cardimages[whichIcon, whichValue]);
                                break;
                            }

                            else if (i == 5)
                            {
                                DealerCard6.Image = Image.FromFile(cardimages[whichIcon, whichValue]);
                                break;
                            }

                            else if (i == 6)
                            {
                                DealerCard7.Image = Image.FromFile(cardimages[whichIcon, whichValue]);
                                break;
                            }

                            else if (i == 7)
                            {
                                DealerCard8.Image = Image.FromFile(cardimages[whichIcon, whichValue]);
                                break;
                            }

                            else if (i == 8)
                            {
                                DealerCard9.Image = Image.FromFile(cardimages[whichIcon, whichValue]);
                                break;
                            }

                            else if (i == 9)
                            {
                                DealerCard10.Image = Image.FromFile(cardimages[whichIcon, whichValue]);
                                break;
                            }

                            else if (i == 10)
                            {
                                DealerCard11.Image = Image.FromFile(cardimages[whichIcon, whichValue]);
                                break;
                            }
                        }
                    }

                    // check if dealer is busted or not. If yes, check if the dealer has any ace card(s).
                    // If not, then the dealer is busted and the player wins
                    // If yes, calculate the dealer's hand's value so that it is less than 21
                    // and give a dealer a choice to hit again or stop
                    if (dealerHandValue > 21)
                    {
                        bool areThereAce = false;

                        // iterate through dealer's hand and check if there's any ace card(s)
                        for (int i = 0; i < dealerHand.Length; i++)
                        {
                            // if there'a an ace within dealer's hand, re-calculate that as 1 instead of 14
                            // that way, the dealer won't get busted thanks to how ace cards are being calculated
                            if (dealerHand[i] == 1)
                            {

                                // check if the current ace card was checked its existence before.
                                // If not, then just simply re-calculate the dealer's hand's value
                                // If yes however, re-calculation will be ignored.
                                if (dealerAceTrack[i] == false)
                                {
                                    dealerAceTrack[i] = true;

                                    areThereAce = true;
                                    dealerHandValue = dealerHandValue - 13;
                                }

                                // update the display of the sum of dealer's hand's value
                                Dealer_Hand.Text = "Dealer hand: " + dealerHandValue;
                            }
                        }

                        // use 'areThereAce' variable to check if dealer had ace card.
                        // if yes, dealer's hand's value should be re-calculated to prevent them
                        // from being busted. Otherwise, their hand's value should exceed 21 and get busted
                        if (!areThereAce)
                        {
                            Dealer_Hand.Text = "Dealer Busted";
                            Result_msg.Text = "You won!";
                            gameStart = false;

                            Play_and_Hit.Text = "Play";
                            Exit_and_Stop.Text = "Exit";
                        }
                    }
                }

                // if 'hitChance' probability is missed out, stop hitting cards for dealer
                else
                {
                    // update the display of the sum of both player's and dealer's hand's value
                    Dealer_Hand.Text = "Dealer hand: " + dealerHandValue;
                    Player_Hand.Text = "Player hand: " + playerHandValue;

                    gameStart = false;

                    Play_and_Hit.Text = "Play";
                    Exit_and_Stop.Text = "Exit";

                    if (playerHandValue > dealerHandValue)
                    {
                        Result_msg.Text = "You won!";
                    }

                    else if (playerHandValue < dealerHandValue)
                    {
                        Result_msg.Text = "You lost";
                    }

                    else
                    {
                        Result_msg.Text = "Draw";
                    }

                    break;
                }

                
            }

            if (dealerHandValue == 21)
            {
                Dealer_Hand.Text = "Dealer hand: " + dealerHandValue;
                Player_Hand.Text = "Player hand: " + playerHandValue;

                gameStart = false;

                Play_and_Hit.Text = "Play";
                Exit_and_Stop.Text = "Exit";

                Result_msg.Text = "You lost";
            }
        }

        // How to add code to control picture viewer
        //https://learn.microsoft.com/en-us/visualstudio/get-started/csharp/tutorial-windows-forms-picture-viewer-code?view=vs-2022&tabs=csharp
    }
}
