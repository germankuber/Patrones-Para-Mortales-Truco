using System.Linq;

using FluentAssertions;
using Truco.Test.Domain;

using Xunit;

namespace Truco.Test
{
    public class MazoShould
    {
        private readonly IMazo _sut = new Mazo().Mezclar();

        [Fact]
        public void Repartir_3_Cartas()
        {
            var cartas = _sut.Repartir();

            cartas.Count().Should().Be(3);
        }

        [Fact]
        public void Repartir_3_Cartas_Differents()
        {
            var cartas = _sut.Repartir();

            cartas.Distinct().Count().Should().Be(3);
        }

        [Fact]
        public void Repartir_6_Cartas_Differents()
        {
            var manoFirst = _sut.Repartir();
            var manoSecond = _sut.Repartir();

            manoFirst.Intersect(manoSecond).Count().Should().Be(0);
        }
    }
}