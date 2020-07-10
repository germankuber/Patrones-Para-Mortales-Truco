using System.Collections.Generic;

namespace Truco.Test.Domain.Jugadores
{
    public interface IPlayer
    {
        public bool IsMano { get;  }
        void SetMano();
        void SetNoMano();
        Carta ElegirCarta(IReadOnlyCollection<Carta> cartas);
    }
}