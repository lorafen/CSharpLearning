using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleCards;

namespace Lab13
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();

            Card[] cardArray = new Card[5];

            deck.Shuffle();
            cardArray[0] = deck.TakeTopCard();
            cardArray[0].FlipOver();
            //cardArray[0].Print();

            cardArray[1] = deck.TakeTopCard();
            cardArray[1].FlipOver();

            for (int i = 0; i < 2; i++)
            {
                cardArray[i].Print();
            }
            
        }
    }
}
