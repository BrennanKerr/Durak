/*
 * Program:     Suit.cs
 * Desctiption: An enum that stores each type of card suit
 * 
 * Author:      Group 1
 * Since:       8 March 2020
 * Reference:   Watson, K. et al. (2013). Beginning Visual C# 2022 Programming. 
 *                  Wrox Press.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardLib
{
    /// <summary>
    /// the possible suits for the cards
    /// </summary>
    public enum CardSuit : byte
    {
        Spades,
        Hearts,
        Diamonds,
        Clubs
    }
}