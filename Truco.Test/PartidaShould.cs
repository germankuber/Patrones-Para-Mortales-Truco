using System.Collections.Generic;

using FluentAssertions;

using Moq;

using Truco.Test.Domain;
using Truco.Test.Domain.Jugadores;

using Xunit;

namespace Truco.Test
{
    public class PartidaShould
    {
        [Fact]
        public void Gana_Player_Two()
        {
            var playerOne = PlayerTestBuilder.Create("Player 1");
            var playerTwo = PlayerTestBuilder.Create("Player 2");

            IPlayers players = new Players(playerOne, playerTwo);

            var mazoRepartir = new Mock<IMazo>();

            mazoRepartir.Setup(x => x.Mezclar()).Returns(() =>
            {
                var mazo = new Mock<IMazo>();

                mazo.SetupSequence(x => x.Repartir())

                    .Returns(new List<Carta>
                    {
                        CartaTestBuilder.Create(7, 2),
                        CartaTestBuilder.Create(7, 3),
                        CartaTestBuilder.Create(7, 4),
                    })
                    .Returns(new List<Carta>
                    {
                        CartaTestBuilder.Create(7, 7),
                        CartaTestBuilder.Create(7, 8),
                        CartaTestBuilder.Create(7, 9),
                    });
                return mazo.Object;
            });

            var partida = new Partida(players, mazoRepartir.Object);

            partida.Play().Should().Be(CartaCompareResultEnum.Pierde);
        }

        [Fact]
        public void Gana_Player_One()
        {
            var playerOne = PlayerTestBuilder.Create("Player 1");
            var playerTwo = PlayerTestBuilder.Create("Player 2");

            var mazoRepartir = new Mock<IMazo>();

            mazoRepartir.Setup(x => x.Mezclar()).Returns(() =>
            {
                var mazo = new Mock<IMazo>();

                mazo.SetupSequence(x => x.Repartir())
                    .Returns(new List<Carta>
                    {
                        CartaTestBuilder.Create(7, 7),
                        CartaTestBuilder.Create(7, 8),
                        CartaTestBuilder.Create(7, 9),
                    })
                    .Returns(new List<Carta>
                    {
                        CartaTestBuilder.Create(7, 2),
                        CartaTestBuilder.Create(7, 3),
                        CartaTestBuilder.Create(7, 4),
                    });
                return mazo.Object;
            });

            IPlayers players = new Players(playerOne, playerTwo);
            var partida = new Partida(players, mazoRepartir.Object);

            partida.Play().Should().Be(CartaCompareResultEnum.Gana);
        }
    }
}