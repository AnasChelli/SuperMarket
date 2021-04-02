using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperMarketTest
{
    public class MoneyEngine
    {
        private readonly List<long> _availablePieces = new List<long>
        {
            10,
            5,
            2
        };

        public Money MonnaieOptimale(long moneyToBeReturned)
        {
            var optimalNumberByPieces = GetOptimalNumberByPieces(moneyToBeReturned);

            return optimalNumberByPieces.Any() ? new Money
            {
                Piece2 = optimalNumberByPieces.ContainsKey(2) ? optimalNumberByPieces[2] : 0,
                Billet5 = optimalNumberByPieces.ContainsKey(5) ? optimalNumberByPieces[5] : 0,
                Billet10 = optimalNumberByPieces.ContainsKey(10) ? optimalNumberByPieces[10] : 0
            } : null;
        }

        private IDictionary<long, long> GetOptimalNumberByPieces(long money)
        {
            var giveBackChange = money;
            var optimalNumberByPieces = new Dictionary<long, long>();

            foreach (var availablePiece in _availablePieces.Where(x => x <= giveBackChange))
            {
                if(!IsPossibleToGiveBackChange(giveBackChange, availablePiece))
                {
                    continue;
                }

                optimalNumberByPieces.Add(availablePiece, giveBackChange / availablePiece);
                giveBackChange %= availablePiece;
            }

            return optimalNumberByPieces;
        }

        private static bool IsPossibleToGiveBackChange(long giveBackChange, long availablePiece)
        {
            return giveBackChange % availablePiece != 1 && giveBackChange % availablePiece != 3;
        }
    }
}