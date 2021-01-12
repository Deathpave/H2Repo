using SorteperLibrary.Cards.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SorteperLibrary
{
    /// <summary>
    /// Class for cards.
    /// </summary>
    public class Card : ICard
    {
        private string _name;
        private int _suit;
        private int _value;
        private string _image;

        // Constructor for card class
        public Card(int suit, int value, string name, string image)
        {
            _name = name;
            _suit = suit;
            _value = value;
            _image = image;
        }

        // Method to get the name of the card
        // Currently a placeholder
        public string GetName()
        {
            return _name;
        }

        // Method to get the suit of the card
        public int GetSuit()
        {
            return _suit;
        }

        // Method to get the value of the card
        public int GetValue()
        {
            return _value;
        }

        public string GetImageName()
        {
            return _image;
        }
    }
}
