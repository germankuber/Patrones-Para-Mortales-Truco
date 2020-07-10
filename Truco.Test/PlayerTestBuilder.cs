using System;
using System.Collections.Generic;
using System.Linq;
using Truco.Test.Domain;
using Truco.Test.Domain.Jugadores;

namespace Truco.Test
{
    public static class PlayerTestBuilder
    {
        public static Player Create(string name) => new Player(name, x => x.First());
        public static Player Create(string name, Func<IReadOnlyCollection<Carta>, Carta> elegirCartaCallback) =>
            new Player(name, elegirCartaCallback);
    }
}