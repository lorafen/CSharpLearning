using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleCards;

namespace Lab14b
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            List<Card> list = new List<Card>();
            
            deck.Shuffle();

            for (int i = 0; i < 5; i++)
            {
                list.Add(deck.TakeTopCard());
            }

            for (int i = 0; i < list.Count; i++)
            {
                list[i].FlipOver();
            }

            foreach (Card list_item in list)
            {
                list_item.Print();
            }
        }
    }
}
