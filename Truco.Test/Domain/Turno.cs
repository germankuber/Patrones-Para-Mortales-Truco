using Truco.Test.Domain.Jugadores;

namespace Truco.Test.Domain
{
    public class Turno
    {
        private readonly IPlayerEnTurno _playerOne;
        private readonly IPlayerEnTurno _playerTwo;

        public Turno(IPlayerEnTurno playerOne, IPlayerEnTurno playerTwo)
        {
            _playerOne = playerOne;
            _playerTwo = playerTwo;
        }

        public Turno Jugar()
        {
            var cartaPlayer1 = _playerOne.TirarCarta();
            var cartaPlayer2 = _playerTwo.TirarCarta();

            return (cartaPlayer1.Compare(cartaPlayer2)) switch
            {
                CartaCompareResultEnum.Pierde => new Turno(_playerTwo, _playerOne),
                _ => this
            };
        }
    }
}