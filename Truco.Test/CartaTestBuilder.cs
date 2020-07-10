using Truco.Test.Domain;

namespace Truco.Test
{
    public static class CartaTestBuilder
    {
        public static Carta Create(int numero) => 
            new Carta(PaloDeCartaEnum.Copa, numero, 1);
        public static Carta Create(int numero, int weight) => 
            new Carta(PaloDeCartaEnum.Copa, numero, weight);
        public static Carta Create() => new Carta(PaloDeCartaEnum.Copa, 1, 1);
    }
}