using System.Collections.Generic;
using System.Linq;

using Truco.Test.Domain.Jugadores;

namespace Truco.Test.Domain
{
    public class Ronda
    {
        private readonly List<PlayerEnTurno> _cartasDeJugador
            = new List<PlayerEnTurno>();

        public Ronda(IPlayers players, IMazo mazo)
        {
            _cartasDeJugador.Add(new PlayerEnTurno(players.PlayerOne, mazo.Repartir()));
            _cartasDeJugador.Add(new PlayerEnTurno(players.PlayerTwo, mazo.Repartir()));
        }

        public CartaCompareResultEnum Jugar()
        {
            var mano = _cartasDeJugador.First(x => x.Player.IsMano);
            var noMano = _cartasDeJugador.First(x => !x.Player.IsMano);

            //Flor
            var cartaPlayer1 = mano.TirarCarta();
            //envido
            //Flor
            var cartaPlayer2 = noMano.TirarCarta();
            //Envido

            if (cartaPlayer1.Compare(cartaPlayer2) == CartaCompareResultEnum.Gana)
            {
                cartaPlayer1 = mano.TirarCarta();
                cartaPlayer2 = noMano.TirarCarta();

                if (cartaPlayer1.Compare(cartaPlayer2) == CartaCompareResultEnum.Gana)
                {
                    //Gana Jugador 1
                    return CartaCompareResultEnum.Gana;
                }
                else if (cartaPlayer1.Compare(cartaPlayer2) == CartaCompareResultEnum.Parda)
                {
                    //Gana Jugador 1
                    return CartaCompareResultEnum.Gana;
                }
                else if (cartaPlayer1.Compare(cartaPlayer2) == CartaCompareResultEnum.Pierde)
                {
                    cartaPlayer1 = mano.TirarCarta();
                    cartaPlayer2 = noMano.TirarCarta();

                    if (cartaPlayer1.Compare(cartaPlayer2) == CartaCompareResultEnum.Gana)
                    {
                        //Gana Jugador 1
                        return CartaCompareResultEnum.Gana;
                    }
                    else if (cartaPlayer1.Compare(cartaPlayer2) == CartaCompareResultEnum.Pierde)
                    {
                        //Gana Jugador 2
                        return CartaCompareResultEnum.Pierde;
                    }
                    else if (cartaPlayer1.Compare(cartaPlayer2) == CartaCompareResultEnum.Parda)
                    {
                        //Gana Jugador 1
                        return CartaCompareResultEnum.Gana;
                    }
                }
            }
            else if (cartaPlayer1.Compare(cartaPlayer2) == CartaCompareResultEnum.Pierde)
            {
                cartaPlayer1 = mano.TirarCarta();
                cartaPlayer2 = noMano.TirarCarta();

                if (cartaPlayer1.Compare(cartaPlayer2) == CartaCompareResultEnum.Pierde)
                {
                    //Gana Jugador 1
                    return CartaCompareResultEnum.Pierde;
                }
                else if (cartaPlayer1.Compare(cartaPlayer2) == CartaCompareResultEnum.Parda)
                {
                    //Gana Jugador 1
                    return CartaCompareResultEnum.Pierde;
                }
                else if (cartaPlayer1.Compare(cartaPlayer2) == CartaCompareResultEnum.Gana)
                {
                    cartaPlayer1 = mano.TirarCarta();
                    cartaPlayer2 = noMano.TirarCarta();

                    if (cartaPlayer1.Compare(cartaPlayer2) == CartaCompareResultEnum.Pierde)
                    {
                        //Gana Jugador 1
                        return CartaCompareResultEnum.Pierde;
                    }
                    else if (cartaPlayer1.Compare(cartaPlayer2) == CartaCompareResultEnum.Gana)
                    {
                        //Gana Jugador 2
                        return CartaCompareResultEnum.Gana;
                    }
                    else if (cartaPlayer1.Compare(cartaPlayer2) == CartaCompareResultEnum.Parda)
                    {
                        //Gana Jugador 1
                        return CartaCompareResultEnum.Pierde;
                    }
                }
            }
            else if (cartaPlayer1.Compare(cartaPlayer2) == CartaCompareResultEnum.Parda)
            {
                cartaPlayer1 = mano.TirarCarta();
                cartaPlayer2 = noMano.TirarCarta();
                if (cartaPlayer1.Compare(cartaPlayer2) == CartaCompareResultEnum.Parda)
                {
                    cartaPlayer1 = mano.TirarCarta();
                    cartaPlayer2 = noMano.TirarCarta();
                    if (cartaPlayer1.Compare(cartaPlayer2) == CartaCompareResultEnum.Parda)
                    {
                        return CartaCompareResultEnum.Gana;
                    }
                    else if (cartaPlayer1.Compare(cartaPlayer2) == CartaCompareResultEnum.Gana)
                    {
                        return CartaCompareResultEnum.Gana;
                    }
                    else if (cartaPlayer1.Compare(cartaPlayer2) == CartaCompareResultEnum.Pierde)
                    {
                        return CartaCompareResultEnum.Pierde;
                    }

                }
                else if (cartaPlayer1.Compare(cartaPlayer2) == CartaCompareResultEnum.Gana)
                {
                    return CartaCompareResultEnum.Gana;
                }
                else if (cartaPlayer1.Compare(cartaPlayer2) == CartaCompareResultEnum.Pierde)
                {
                    return CartaCompareResultEnum.Pierde;
                }
            }


            return CartaCompareResultEnum.Parda;
            //new Turno(new PlayerEnTurno(mano, _cartasDeJugador[mano]),
            //    new PlayerEnTurno(noMano, _cartasDeJugador[noMano]))
            //    .Jugar();
        }
    }
}