using FluentAssertions;
using Moq;
using Truco.Test.Domain;
using Truco.Test.Domain.Jugadores;
using Xunit;

namespace Truco.Test
{
    public class TurnoShould
    {
        [Fact]
        public void Gano_Player_One()
        {
            var playerOne = new Mock<IPlayerEnTurno>();
            var playerTwo = new Mock<IPlayerEnTurno>();

            playerOne.Setup(x => x.TirarCarta())
                .Returns(CartaTestBuilder.Create(1, 2));

            playerTwo.Setup(x => x.TirarCarta())
                .Returns(CartaTestBuilder.Create(1, 1));

            var turno = new Turno(playerOne.Object, playerTwo.Object);

            turno.Jugar().Should().Be(turno);

        }

        [Fact]
        public void Gano_Player_Two()
        {
            var playerOne = new Mock<IPlayerEnTurno>();
            var playerTwo = new Mock<IPlayerEnTurno>();

            playerOne.Setup(x => x.TirarCarta())
                .Returns(CartaTestBuilder.Create(1, 1));

            playerTwo.Setup(x => x.TirarCarta())
                .Returns(CartaTestBuilder.Create(1, 2));

            var turno = new Turno(playerOne.Object, playerTwo.Object);

            turno.Jugar().Should().NotBe(turno);

        }

        [Fact]
        public void Empardaron()
        {
            var playerOne = new Mock<IPlayerEnTurno>();
            var playerTwo = new Mock<IPlayerEnTurno>();

            playerOne.Setup(x => x.TirarCarta())
                .Returns(CartaTestBuilder.Create(1, 1));

            playerTwo.Setup(x => x.TirarCarta())
                .Returns(CartaTestBuilder.Create(1, 1));

            var turno = new Turno(playerOne.Object, playerTwo.Object);

            turno.Jugar().Should().Be(turno);

        }
    }
}