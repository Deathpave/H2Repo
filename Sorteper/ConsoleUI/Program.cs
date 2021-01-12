using SorteperLibrary;
using SorteperLibrary.Cards.Interfaces;
using SorteperLibrary.Generators;
using SorteperLibrary.Players;
using SorteperLibrary.Players.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Net.NetworkInformation;

namespace ConsoleUI
{
    // UI class for the console version
    class Program
    {
        static void Main(string[] args)
        {
            // creates a game manager to handle the game
            GameManager manager = new GameManager();

            // create players
            Console.WriteLine("Enter number of players");
            int playerCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < playerCount; i++)
            {
                Console.Clear();
                Console.WriteLine("Write name of player");
                manager.CreatePlayer(Console.ReadLine());
            }
            Console.WriteLine("Press enter to begin");
            Console.ReadLine();
            Console.Clear();

            // deals cards to the players
            manager.DealCards();

            // while there is active players the game goes on
            while (manager.ActivePlayers() > 1)
            {
                // tells which players turn it is
                Console.WriteLine(manager.GetPlayerName() + "'s turn");

                // get card options
                int cardOptions = manager.PlayerSelectCard();
                Console.WriteLine("Select a card from {0} to {1}", 1, cardOptions);

                // write card taken
                Console.WriteLine(manager.PlayerTakeCard(int.Parse(Console.ReadLine())));

                // match cards
                manager.PlayerMatchCards();
                Console.WriteLine("All cards have been matched");

                // checks if any player have 0 cards left
                manager.CheckVictory();

                // end turn
                if (manager.ActivePlayers() > 1)
                {
                    manager.EndTurn();
                    Console.WriteLine("Press enter to end turn");
                    Console.Clear();
                }
            }

            Console.WriteLine(manager.GetPlayerName() + " is the knave");

            Console.ReadLine();
        }
    }
}
