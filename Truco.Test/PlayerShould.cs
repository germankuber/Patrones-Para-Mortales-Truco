using System.Collections.Generic;
using System.Linq;

using FluentAssertions;

using Truco.Test.Domain;
using Truco.Test.Domain.Jugadores;

using Xunit;

namespace Truco.Test
{
    public class PlayerShould
    {
        [Fact]
        public void Accept_Two_Players()
        {
            var selectedCard = CartaTestBuilder.Create(1);
            var playerOne = new Player("Player 1", x => x.First());

            playerOne.ElegirCarta(new List<Carta> { selectedCard }).Should().Be(selectedCard);

        }
    }
}