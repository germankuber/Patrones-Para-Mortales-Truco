using System.Collections.Generic;
using System.Linq;

using FluentAssertions;

using Moq;

using Truco.Test.Domain;
using Truco.Test.Domain.Jugadores;

using Xunit;

namespace Truco.Test
{
    public class RondaShould
    {
        [Fact]
        public void Define_Mano()
        {
            Mock<IMazo> mazoMock = new Mock<IMazo>();
            var playerOne = PlayerTestBuilder.Create("Player 1");
            var playerTwo = PlayerTestBuilder.Create("Player 2");

            var players = new Players(playerOne, playerTwo);
            mazoMock.Setup(x => x.Repartir());

            new Ronda(players, mazoMock.Object);

            mazoMock.Verify(x => x.Repartir(), Times.Exactly(2));
        }

        [Theory]
        [InlineData(5, 6, 7, 1, 2, 3, CartaCompareResultEnum.Gana)]
        [InlineData(5, 6, 7, 1, 6, 3, CartaCompareResultEnum.Gana)]
        [InlineData(5, 1, 7, 1, 2, 3, CartaCompareResultEnum.Gana)]
        [InlineData(5, 1, 3, 1, 2, 3, CartaCompareResultEnum.Gana)]
        [InlineData(5, 1, 2, 1, 3, 4, CartaCompareResultEnum.Pierde)]
        [InlineData(1, 2, 3, 5, 6, 7, CartaCompareResultEnum.Pierde)]
        [InlineData(1, 6, 3, 5, 6, 7, CartaCompareResultEnum.Pierde)]
        [InlineData(1, 2, 3, 5, 1, 7, CartaCompareResultEnum.Pierde)]
        [InlineData(1, 2, 3, 5, 1, 3, CartaCompareResultEnum.Pierde)]
        [InlineData(1, 3, 4, 5, 1, 2, CartaCompareResultEnum.Gana)]
        [InlineData(1, 1, 1, 1, 1, 1, CartaCompareResultEnum.Gana)]
        [InlineData(1, 1, 3, 1, 1, 1, CartaCompareResultEnum.Gana)]
        [InlineData(1, 1, 1, 1, 1, 3, CartaCompareResultEnum.Pierde)]
        [InlineData(1, 2, 3, 1, 1, 1, CartaCompareResultEnum.Gana)]
        [InlineData(1, 2, 3, 1, 5, 1, CartaCompareResultEnum.Pierde)]
        public void Juega_Mano_PlayerOne_Gana_Gana(int a, int b, int c, int d, int e, int f, CartaCompareResultEnum result)
        {
            Mock<IMazo> mazoMock = new Mock<IMazo>();
            var playerOne = new Player("Player 1", x => x.First());
            playerOne.SetMano();
            var playerTwo = new Player("Player 2", x => x.First());

            var players = new Players(playerOne, playerTwo);

            mazoMock.SetupSequence(x => x.Repartir())
                .Returns(new List<Carta>
                {
                    CartaTestBuilder.Create(1, a),
                    CartaTestBuilder.Create(1, b),
                    CartaTestBuilder.Create(1, c)
                })
                .Returns(new List<Carta>
                {
                    CartaTestBuilder.Create(1, d),
                    CartaTestBuilder.Create(1, e),
                    CartaTestBuilder.Create(1, f)
                });


            new Ronda(players, mazoMock.Object).Jugar()
                .Should()
                .Be(result);

        }



    }
}