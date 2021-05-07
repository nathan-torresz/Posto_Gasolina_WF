using System;
using System.Collections.Generic;
using System.Text;

namespace Posto_Combustivel_WF
{
    public enum TipoCombustivel
    {
        Gasolina,
        Etanol,
    }
    class BombaCombustivel
    {
        private int _numBomba;
        private TipoCombustivel _tipo;
        private float _capacidade;
        public int NumBomba { get => _numBomba; private set => _numBomba = value; }
        public TipoCombustivel Tipo { get => _tipo; private set => _tipo = value; }
        public float Capacidade { get => _capacidade; set => _capacidade = value; }

        public BombaCombustivel(int numBomba, TipoCombustivel tipo, float capacidade)
        {
            NumBomba = numBomba;
            Tipo = tipo;
            Capacidade = capacidade;
        }

        public Abastecimento Abastecer(float qtd, float preco)
        {
            if (qtd > Capacidade) qtd = Capacidade;
            Capacidade -= qtd;
            Abastecimento abastecimento = new Abastecimento(this, qtd, preco);
            return abastecimento;
        }
    }
}
