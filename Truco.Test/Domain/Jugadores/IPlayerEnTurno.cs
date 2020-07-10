using System.Collections.Generic;

namespace Truco.Test.Domain.Jugadores
{
    public interface IPlayerEnTurno
    {
        List<Carta> Cartas { get; }
        Carta TirarCarta();
    }
}