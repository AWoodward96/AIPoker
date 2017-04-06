using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerTournament
{
    // allows a human player to participate
    class Player2 : Player
    {
        // setup your basic human player
        public Player2(int idNum, string nm, int mny) : base(idNum, nm, mny)
        {
        }

        // first round of betting - see project instructions
        public override PlayerAction BettingRound1(List<PlayerAction> actions, Card[] hand)
        {
            Random rand = new Random();
            PlayerAction pa = null;
            // evaluate the hand
            Card highCard = null;
            int rank = Evaluate.RateAHand(hand, out highCard);

            //bets the ammount based on hand rank
            int amount = 10 * rank + rand.Next(0, 10);

            //if isn't the dealer, and is going first
            if (this.Dealer == false)
            {
                if (rank == 1) //if rank is 1, no point in playing
                    pa = new PlayerAction(Name, "Bet1", "fold", amount);
                else if (rank >=4 )
                    pa = new PlayerAction(Name, "Bet1", "bet", amount);
                else // check cause the hand you ahve isn't that great
                    pa = new PlayerAction(Name, "Bet1", "check", amount);
            }
            else
            {
                if (rank == 1) //if rank is 1, no point in playing
                    pa = new PlayerAction(Name, "Bet1", "fold", amount);
                else if (rank < 5) //match the bet if hand rank is 6 or less
                    pa = new PlayerAction(Name, "Bet1", "call", amount);
                else // else raise the bet cause your hand is probably the best
                    pa = new PlayerAction(Name, "Bet1", "raise", amount);
            }

            return pa;
        }

        // draw 0 - 5 cards - see project instructions
        public override PlayerAction Draw(Card[] hand)
        {

            return null;

        }


        // second round of betting - see project instructions
        public override PlayerAction BettingRound2(List<PlayerAction> actions, Card[] hand)
        {

            return null;

        }
    }
}
