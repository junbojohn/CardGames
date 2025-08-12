using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CardGames
{
    internal class FCD_Value_Checker
    {
        /*
         * Idea:
         * card's value will be determined here
         */

        //setup a list of hands variables and use them to compare the player/dealer's hand right away

        public FCD_Value_Checker()
        {

        }

        public int judgeValue((int, int)[] hand)
        {
            // royal flush: result = 10
            // first, check if all cards have same suit
            if ((hand[0].Item1 == 0 && hand[1].Item1 == 0 && hand[2].Item1 == 0 && hand[3].Item1 == 0 && hand[5].Item1 == 0) ||
                (hand[0].Item1 == 1 && hand[1].Item1 == 1 && hand[2].Item1 == 1 && hand[3].Item1 == 1 && hand[5].Item1 == 1) ||
                (hand[0].Item1 == 2 && hand[1].Item1 == 2 && hand[2].Item1 == 2 && hand[3].Item1 == 2 && hand[5].Item1 == 2) ||
                (hand[0].Item1 == 3 && hand[1].Item1 == 3 && hand[2].Item1 == 3 && hand[3].Item1 == 3 && hand[5].Item1 == 3))
            {
                // then, check if the cards are sets of ace, king, queen, jack, and 10
                bool aceCheck = false;
                bool kingCheck = false;
                bool queenCheck = false;
                bool jackCheck = false;
                bool tenCheck = false;

                for (int i = 0; i < hand.Length; i++) {
                    if (hand[i].Item2 == 0)
                    {
                        aceCheck = true;
                    }

                    else if (hand[i].Item2 == 12)
                    {
                        kingCheck = true;
                    }

                    else if (hand[i].Item2 == 11)
                    {
                        queenCheck = true;
                    }

                    else if (hand[i].Item2 == 10)
                    {
                        jackCheck = true;
                    }

                    else if (hand[i].Item2 == 9)
                    {
                        tenCheck = true;
                    }
                }

                if (aceCheck && kingCheck && queenCheck && jackCheck && tenCheck) {
                    return 10;
                }
            }

            // straight flush: result = 9
            // first, check if all cards have same suit
            else if ((hand[0].Item1 == 0 && hand[1].Item1 == 0 && hand[2].Item1 == 0 && hand[3].Item1 == 0 && hand[5].Item1 == 0) ||
                (hand[0].Item1 == 1 && hand[1].Item1 == 1 && hand[2].Item1 == 1 && hand[3].Item1 == 1 && hand[5].Item1 == 1) ||
                (hand[0].Item1 == 2 && hand[1].Item1 == 2 && hand[2].Item1 == 2 && hand[3].Item1 == 2 && hand[5].Item1 == 2) ||
                (hand[0].Item1 == 3 && hand[1].Item1 == 3 && hand[2].Item1 == 3 && hand[3].Item1 == 3 && hand[5].Item1 == 3))
            {
                // then go through a sequence of if statements to see if the hands are indeed straight
                if (hand[0].Item2 > hand[1].Item2)
                {
                    if (hand[1].Item2 > hand[2].Item2)
                    {
                        if (hand[2].Item2 > hand[3].Item2)
                        {
                            if (hand[3].Item2 > hand[4].Item2)
                            {
                                return 9;
                            }
                        }
                    }
                }
            }

            // four of a kind: result = 8
            // check if there are 4 cards that are the same value
            else if (hand[0].Item2 == hand[1].Item2 && hand[0].Item2 == hand[2].Item2 && hand[0].Item2 == hand[3].Item2)
            {
                return 8;
            }

            // full house: result = 7
            // check if there are three of a kind and a pair
            else if ((hand[0].Item2 == hand[1].Item2 && hand[2].Item2 == hand[3].Item2 && hand[2].Item2 == hand[4].Item2) ||
                hand[0].Item2 == hand[1].Item2 && hand[0].Item2 == hand[2].Item2 && hand[3].Item2 == hand[4].Item2)
            {
                return 7;
            }

            // flush: result = 6
            // check if all 5 cards have same suit
            else if (hand[0].Item1 == hand[1].Item1 && hand[0].Item1 == hand[2].Item1 && hand[0].Item1 == hand[3].Item1 && hand[0].Item1 == hand[4].Item1)
            {
                return 6;
            }


            // straight: result = 5
            // check if all 5 cards are in sequence(there are 2 else ifs for this one)

            // check if the first card is an ace
            else if (hand[0].Item2 == 0)
            {
                // then, check if the cards are sets of ace, king, queen, jack, and 10
                bool aceCheck = false;
                bool kingCheck = false;
                bool queenCheck = false;
                bool jackCheck = false;
                bool tenCheck = false;

                // or check if the cards are sets of ace, 2, 3, 4, and 5
                bool twoCheck = false;
                bool threeCheck = false;
                bool fourCheck = false;
                bool fiveCheck = false;

                for (int i = 0; i < hand.Length; i++)
                {
                    if (hand[i].Item2 == 0)
                    {
                        aceCheck = true;
                    }

                    else if (hand[i].Item2 == 12)
                    {
                        kingCheck = true;
                    }

                    else if (hand[i].Item2 == 11)
                    {
                        queenCheck = true;
                    }

                    else if (hand[i].Item2 == 10)
                    {
                        jackCheck = true;
                    }

                    else if (hand[i].Item2 == 9)
                    {
                        tenCheck = true;
                    }

                    else if (hand[i].Item2 == 2)
                    {
                        twoCheck = true;
                    }

                    else if (hand[i].Item2 == 3)
                    {
                        threeCheck = true;
                    }

                    else if (hand[i].Item2 == 4)
                    {
                        fourCheck = true;
                    }

                    else if (hand[i].Item2 == 5)
                    {
                        fiveCheck = true;
                    }
                }

                if (aceCheck && kingCheck && queenCheck && jackCheck && tenCheck)
                {
                    return 5;
                }

                else if (aceCheck && twoCheck && threeCheck && fourCheck && fiveCheck)
                {
                    return 5;
                }
            }

            // check if the first card isn't ace
            else if (hand[0].Item2 != 0)
            {
                if ((hand[0].Item2 - 1) == hand[1].Item2)
                {
                    if ((hand[1].Item2 - 1) == hand[2].Item2)
                    {
                        if ((hand[2].Item2 - 1) == hand[3].Item2)
                        {
                            if ((hand[3].Item2 - 1) == hand[4].Item2)
                            {
                                return 5;
                            }
                        }
                    }
                }
            }


            // three of a kind: result = 4
            // check if there are 3 cards with value sequence
            else if ((hand[0].Item2 - 1) == hand[1].Item2)
            {
                if ((hand[1].Item2 - 1) == hand[2].Item2)
                {
                    return 4;
                }
            }

            // two pair: result = 3
            // check if there are pair of twos
            else if (hand[0].Item2 == hand[1].Item2)
            {
                if (hand[2].Item2 == hand[3].Item2)
                {
                    return 3;
                }
            }

            // one pair: result = 2
            // check if there are pair
            else if (hand[0].Item2 == hand[1].Item2)
            {
                return 2;
            }

            // no pair: result = 1
            return 1;
        }
    }
}
