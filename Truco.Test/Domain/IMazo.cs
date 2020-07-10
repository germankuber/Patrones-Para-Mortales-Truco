using System.Collections.Generic;

namespace Truco.Test.Domain
{
    public interface IMazo
    {
        IEnumerable<Carta> Repartir();
        IMazo Mezclar();
    }
}