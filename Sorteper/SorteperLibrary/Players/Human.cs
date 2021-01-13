using SorteperLibrary.Cards.Interfaces;
using SorteperLibrary.Players.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SorteperLibrary.Players
{
    /// <summary>
    /// Class for human players.
    /// </summary>
    public class Human : Player, IPlayer
    {
        // Constructor for a human player
        public Human(string name, int number, List<ICard> cards)
        {
            _playerName = name;
            _playerNumber = number;
            _cards = cards;
        }

        // Method to add a card to the player
        public void AddCard(ICard card)
        {
            _cards.Add(card);
        }

        public void AddCards(List<ICard> cards)
        {
            _cards = cards;
        }

        // Method to return the number off cards a player have
        public int GetCardAmount()
        {
            return _cards.Count;
        }

        public List<ICard> GetCards()
        {
            return _cards;
        }

        // Method to get the players name
        public string GetName()
        {
            return _playerName;
        }

        // Method to get the players number
        public int GetNumber()
        {
            return _playerNumber;
        }

        // Method to remove and return the removed card
        public ICard RemoveCard(int index)
        {
            ICard result = _cards[index];
            _cards.RemoveAt(index);
            return result;
        }

        public void RemoveCard(ICard card)
        {
            _cards.Remove(card);
        }
    }
}
