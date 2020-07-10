using System.Collections.Generic;
using System.Linq;

namespace Truco.Test.Domain.Jugadores
{
    public class PlayerEnTurno : IPlayerEnTurno
    {
        public IPlayer Player { get; }
        public List<Carta> Cartas { get; }

        public PlayerEnTurno(IPlayer player, IEnumerable<Carta> cartas)
        {
            Player = player;
            Cartas = cartas.ToList();
        }

        public Carta TirarCarta()
        {
            var carta = Player.ElegirCarta(Cartas);
            Cartas.Remove(carta);
            return carta;
        }
    }
}