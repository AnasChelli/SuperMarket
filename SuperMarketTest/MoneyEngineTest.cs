using NFluent;
using NUnit.Framework;

namespace SuperMarketTest
{
    public class MoneyEngineTest
    {

        [Test]
        public void Should_return_null_when_no_available_pieces()
        {
            MoneyEngine moneyEngine = new MoneyEngine();
            Monnaie actual = moneyEngine.MonnaieOptimale(1);
            Check.That(actual).IsNull();
        }

        [Test]
        public void Should_return_3_pieces_of_two_euro()
        {
            MoneyEngine moneyEngine = new MoneyEngine();
            Monnaie actual = moneyEngine.MonnaieOptimale(6);
            Check.That(actual.Piece2).Equals(3);
            Check.That(actual.Billet5).Equals(0);
            Check.That(actual.Billet10).Equals(0);
        }

        [Test]
        public void Should_return_1_billet_of_ten_euro()
        {
            MoneyEngine moneyEngine = new MoneyEngine();
            Monnaie actual = moneyEngine.MonnaieOptimale(10);
            Check.That(actual.Piece2).Equals(0);
            Check.That(actual.Billet5).Equals(0);
            Check.That(actual.Billet10).Equals(1);
        }

        [Test]
        public void Should_return_1_billet_of_ten_euro_and_1_billet_of_five_euro()
        {
            MoneyEngine moneyEngine = new MoneyEngine();
            Monnaie actual = moneyEngine.MonnaieOptimale(15);
            Check.That(actual.Piece2).Equals(0);
            Check.That(actual.Billet5).Equals(1);
            Check.That(actual.Billet10).Equals(1);
        }

        [Test]
        public void Should_return_922337203685477580_billet_of_ten_and_1_billet_of_five_euro_and_1_piece_of_2_euro()
        {
            MoneyEngine moneyEngine = new MoneyEngine();
            Monnaie actual = moneyEngine.MonnaieOptimale(9223372036854775807);
            Check.That(actual.Piece2).Equals(1);
            Check.That(actual.Billet5).Equals(1);
            Check.That(actual.Billet10).Equals(922337203685477580);
        }
    }
}