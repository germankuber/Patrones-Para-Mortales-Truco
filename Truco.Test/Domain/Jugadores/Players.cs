namespace Truco.Test.Domain.Jugadores
{
    public class Players : IPlayers
    {
        public Player PlayerOne { get; }
        public Player PlayerTwo { get; }

        public Players(Player playerOne, Player playerTwo)
        {
            PlayerOne = playerOne;
            PlayerOne.SetMano();
            PlayerTwo = playerTwo;
        }
    }
}