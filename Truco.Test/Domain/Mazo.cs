using System.Collections.Generic;

namespace Truco.Test.Domain
{
    public class Mazo : IMazo
    {
        private readonly Stack<Carta> _cartas = new Stack<Carta>();

        public Mazo()
        {
        }

        public IMazo Mezclar()
        {
            var mazo = new Mazo();
            for (int i = 1; i <= 6; i++)
                mazo._cartas.Push(new Carta(PaloDeCartaEnum.Oro, i, i));
            return mazo;
        }

        public IEnumerable<Carta> Repartir()
        {
            yield return _cartas.Pop();
            yield return _cartas.Pop();
            yield return _cartas.Pop();
        }
    }
}