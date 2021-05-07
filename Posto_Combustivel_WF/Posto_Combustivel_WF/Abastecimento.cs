using System;
using System.Collections.Generic;
using System.Text;

namespace Posto_Combustivel_WF
{
    class Abastecimento
    {
        private BombaCombustivel _bomba;
        private float _qtd;
        private float _preco;
        private bool _isPago;
        public BombaCombustivel Bomba { get => _bomba; private set => _bomba = value; }
        public float Qtd { get => _qtd; 
            set 
            {
                _qtd = value;
                if (value < 0) Qtd = 0; 
            }
        }
        public float Preco { get => _preco; private set => _preco = value; }
        public bool IsPago { get => _isPago; private set => _isPago = value; }
        public float Valor { get => Qtd * Preco; }

        public Abastecimento(BombaCombustivel bomba, float qtd, float preco)
        {
            Bomba = bomba;
            Qtd = qtd;
            Preco = preco;
            this.IsPago = false;
        }
        public void MarcarPago(bool pago)
        {
            IsPago = pago;
        }
    }
}
