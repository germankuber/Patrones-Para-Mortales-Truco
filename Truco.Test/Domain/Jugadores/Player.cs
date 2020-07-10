using System;
using System.Collections.Generic;

namespace Truco.Test.Domain.Jugadores
{
    public class Player : IPlayer
    {
        private string _name;
        private readonly Func<IReadOnlyCollection<Carta>, Carta> _elegirCartaCallback;
        public bool IsMano { get; private set; }
        public int Puntos { get; private set; }

        public Player(string name, Func<IReadOnlyCollection<Carta>, Carta> elegirCartaCallback)
        {
            _name = name;
            _elegirCartaCallback = elegirCartaCallback;
        }

        public void SetMano()
        {
            IsMano = true;
        }
        public void SetNoMano()
        {
            IsMano = false;
        }

        public Carta ElegirCarta(IReadOnlyCollection<Carta> cartas) =>
            _elegirCartaCallback(cartas);

        public void AddPuntos(int puntos)
        {
            Puntos += puntos;
        }
    }
}