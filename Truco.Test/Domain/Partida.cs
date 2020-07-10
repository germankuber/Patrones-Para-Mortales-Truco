using Truco.Test.Domain;
using Truco.Test.Domain.Jugadores;

namespace Truco.Test
{
    public class Partida
    {
        private readonly IPlayers _players;
        private readonly IMazo _mazo;

        public Partida(IPlayers players, IMazo mazo)
        {
            _players = players;
            _mazo = mazo;

        }

        public CartaCompareResultEnum Play()
        {

            while (_players.PlayerOne.Puntos < 15 && _players.PlayerTwo.Puntos < 15)
            {
                if (new Ronda(_players, _mazo.Mezclar()).Jugar() == CartaCompareResultEnum.Gana)
                    _players.PlayerOne.AddPuntos(1);
                else
                    _players.PlayerTwo.AddPuntos(1);
            }

            if (_players.PlayerOne.Puntos >= 15)
                return CartaCompareResultEnum.Gana;
            return CartaCompareResultEnum.Pierde;
        }
    }
}