using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Microsoft.VisualBasic.CompilerServices;

namespace Truco.Test.Domain
{
    public readonly struct Carta
    {
        public PaloDeCartaEnum Palo { get; }
        public int Numero { get; }
        private readonly int _weight;

        public Carta(PaloDeCartaEnum palo, int numero, int weight)
        {
            Palo = palo;
            Numero = numero;
            _weight = weight;
        }

        private bool Equal(Carta other) =>
            (Palo, Numero) == (other.Palo, other.Numero);

        public static bool operator ==(Carta card, Carta other) =>
            card.Equal(other);
        public static bool operator !=(Carta card, Carta other) =>
            !card.Equal(other);

        public CartaCompareResultEnum Compare(Carta other)
        {
            if (_weight == other._weight)
                return CartaCompareResultEnum.Parda;
            if (_weight > other._weight)
                return CartaCompareResultEnum.Gana;
            return CartaCompareResultEnum.Pierde;
        }
    }
}
