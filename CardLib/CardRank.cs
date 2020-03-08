/*
 * Program:     Rank.cs
 * Desctiption: An enum that stores each possible card rank
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
    /// the possible ranks for the cards
    /// </summary>
    public enum CardRank : byte
    {
        Deuce = 2,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }
}