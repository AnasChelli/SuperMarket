using System.Collections.Generic;
using System.Linq;
using static SuperMarket.Constants.Constant;

namespace SuperMarket
{
    public class MoneyEngine
    {
        private readonly List<long> _availablePieces = new()
        {
            TenEuro,
            FiveEuro,
            TwoEuro
        };

        public Money MonnaieOptimale(long moneyToBeReturned)
        {
            var optimalNumberByPieces = GetOptimalNumberByPieces(moneyToBeReturned);

            return optimalNumberByPieces.Any() ? new Money
            {
                Piece2 = optimalNumberByPieces.ContainsKey(TwoEuro) ? optimalNumberByPieces[TwoEuro] : 0,
                Billet5 = optimalNumberByPieces.ContainsKey(FiveEuro) ? optimalNumberByPieces[FiveEuro] : 0,
                Billet10 = optimalNumberByPieces.ContainsKey(TenEuro) ? optimalNumberByPieces[TenEuro] : 0
            } : null;
        }

        private IDictionary<long, long> GetOptimalNumberByPieces(long money)
        {
            var giveBackChange = money;
            var optimalNumberByPieces = new Dictionary<long, long>();

            foreach (var availablePiece in _availablePieces.Where(x => x <= giveBackChange))
            {
                if (!IsPossibleToGiveBackChange(giveBackChange, availablePiece))
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