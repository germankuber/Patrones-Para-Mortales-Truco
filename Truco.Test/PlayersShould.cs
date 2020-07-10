using FluentAssertions;

using Truco.Test.Domain;
using Truco.Test.Domain.Jugadores;
using Xunit;

namespace Truco.Test
{
    public class PlayersShould
    {
        [Fact]
        public void Accept_Two_Players()
        {
            var playerOne = PlayerTestBuilder.Create("Player 1");
            var playerTwo = PlayerTestBuilder.Create("Player 2");

            var players = new Players(playerOne, playerTwo);

            players.PlayerOne.Should().Be(playerOne);
            players.PlayerTwo.Should().Be(playerTwo);
        }
    }
}