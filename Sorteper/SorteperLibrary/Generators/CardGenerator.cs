using SorteperLibrary.Cards.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SorteperLibrary.Generators
{
    /// <summary>
    /// Class to generate the cards
    /// </summary>
    public class CardGenerator
    {
        private List<ICard> _cards = new List<ICard>();

        // Method to generate cards
        public List<ICard> GenerateCards()
        {
            // needs to generate 51 cards. 13 for each suit, tho not 11 for suit clubs
            // needs to handle name of generated cards instead of empty string

            // ex. list for value = name?

            // suit = color and value = value
            // 1 = red 2 = black
            for (int i = 1; i < 5; i++)
            {
                switch (i)
                {
                    case 1:
                        for (int s = 1; s < 14; s++)
                        {
                            // hearts
                            ICard card = new Card(1, s, "", "H" + s + ".png");
                            _cards.Add(card);
                        }
                        break;
                    case 2:
                        for (int s = 1; s < 14; s++)
                        {
                            // diamonds
                            ICard card = new Card(1, s, "", "D" + s + ".png");
                            _cards.Add(card);
                        }
                        break;
                    case 3:
                        for (int s = 1; s < 14; s++)
                        {
                            // clubs
                            if (s == 11)
                            {
                                continue;
                            }
                            ICard card = new Card(2, s, "", "C" + s + ".png");
                            _cards.Add(card);
                        }
                        break;
                    case 4:
                        for (int s = 1; s < 14; s++)
                        {
                            // spades                            
                            ICard card = new Card(2, s, "", "S" + s + ".png");
                            _cards.Add(card);
                        }
                        break;
                }
            }
            return _cards;
        }
    }
}
