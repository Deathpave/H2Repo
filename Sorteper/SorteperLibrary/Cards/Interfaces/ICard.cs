using System;
using System.Collections.Generic;
using System.Text;

namespace SorteperLibrary.Cards.Interfaces
{
    /// <summary>
    /// Interface for handling card functions.
    /// </summary>
    public interface ICard
    {
        string GetName();
        int GetSuit();
        int GetValue();
        string GetImageName();
    }
}
