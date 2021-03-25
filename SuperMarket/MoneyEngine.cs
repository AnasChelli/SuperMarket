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

            var filtredAvailablePieces = _availablePieces.Where(x => x <= moneyToBeReturned);
            var optimalNumberOfPiecesByAvailablePieces = GetOptimal(moneyToBeReturned, filtredAvailablePieces);

            return optimalNumberOfPiecesByAvailablePieces.Any() ? new Money
            {
                Piece2 = optimalNumberOfPiecesByAvailablePieces.ContainsKey(2) ? optimalNumberOfPiecesByAvailablePieces[2] : 0,
                Billet5 = optimalNumberOfPiecesByAvailablePieces.ContainsKey(5) ? optimalNumberOfPiecesByAvailablePieces[5] : 0,
                Billet10 = optimalNumberOfPiecesByAvailablePieces.ContainsKey(10) ? optimalNumberOfPiecesByAvailablePieces[10] : 0
            } : null;
        }

        private static IDictionary<long, long> GetOptimal(long moneyToBeReturned, IEnumerable<long> availablePieces)
        {
            long nbPieces = -1;
            var optimalNumberOfPiecesByAvailablePieces = new Dictionary<long, long>();

            foreach (var availablePiece in availablePieces)
            {
                while (nbPieces != 0)
                {
                    nbPieces = moneyToBeReturned % availablePiece;
                    if (nbPieces == 1)
                    {
                        break;
                    }

                    optimalNumberOfPiecesByAvailablePieces.Add(availablePiece, moneyToBeReturned / availablePiece);
                    moneyToBeReturned = nbPieces;
                    break;
                }
            }

            return optimalNumberOfPiecesByAvailablePieces;
        }
    }
}