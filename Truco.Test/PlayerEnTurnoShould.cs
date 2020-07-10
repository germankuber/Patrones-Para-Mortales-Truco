using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Moq;
using Truco.Test.Domain;
using Truco.Test.Domain.Jugadores;
using Xunit;

namespace Truco.Test
{
    public class PlayerEnTurnoShould
    {
        [Fact]
        public void Call_Tirar_Carta_From_Player()
        {
            var listOfCartas = new List<Carta>();
            var mockPlayer = new Mock<IPlayer>();
            mockPlayer.Setup(x => x.ElegirCarta(listOfCartas));
            var playerEnTurno = new PlayerEnTurno(mockPlayer.Object, listOfCartas);
            playerEnTurno.TirarCarta();
            mockPlayer.Verify(x => x.ElegirCarta(listOfCartas), Times.Once);
        }

        [Fact]
        public void Remove_Carta_From_List_Of_Cartas()
        {
            var selectedCarta = CartaTestBuilder.Create(1);
            var listOfCartas = new List<Carta>
            {
                selectedCarta,
                CartaTestBuilder.Create(2),
                CartaTestBuilder.Create(3)
            };
            var mockPlayer = new Mock<IPlayer>();
            mockPlayer.Setup(x => x.ElegirCarta(listOfCartas))
                .Returns(selectedCarta);
            var playerEnTurno = new PlayerEnTurno(mockPlayer.Object, listOfCartas);
            playerEnTurno.TirarCarta();

            playerEnTurno.Cartas.Any(x => x == selectedCarta).Should().BeFalse();
        }
    }
}