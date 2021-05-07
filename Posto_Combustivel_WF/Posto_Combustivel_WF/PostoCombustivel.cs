using System;
using System.Collections.Generic;
using System.Text;

namespace Posto_Combustivel_WF
{
    class PostoCombustivel
    {
        private string _nome;
        private List<BombaCombustivel> _bombas;
        private List<Abastecimento> _abastecimento;
        private float _precoGas;
        private float _precoEtanol;

        public string Nome { get => _nome; private set => _nome = value; }
        public List<BombaCombustivel> Bombas { get => _bombas; private set => _bombas = value; }
        public List<Abastecimento> Abastecimento { get => _abastecimento; private set => _abastecimento = value; }
        public float PrecoGas { get => _precoGas; set => _precoGas = value; }
        public float PrecoEtanol { get => _precoEtanol; set => _precoEtanol = value; }

        public PostoCombustivel(string nome, TipoCombustivel[] tiposBombas, float precogas, float precoeta)
        {
            Nome = nome;
            int numBomba = 1;
            this.Bombas = new List<BombaCombustivel>();

            foreach (TipoCombustivel tipo in tiposBombas)
            {
                BombaCombustivel b = new BombaCombustivel(numBomba++, tipo, 100f);
                Bombas.Add(b);
            }
            Abastecimento = new List<Abastecimento>();
            PrecoGas = precogas;
            PrecoEtanol = precoeta;
        }
        public Abastecimento Abastecer(float qtd, int numBomba)
        {
            //Buscar a bomba pelo seu número
            BombaCombustivel bomba = null;

            foreach (BombaCombustivel b in Bombas)
            {
                if (b.NumBomba == numBomba) bomba = b;
            }
            if (bomba != null)
            {
                //buscar o tipo de combustível para saber o preço
                float preco = 0;
                switch (bomba.Tipo)
                {
                    case TipoCombustivel.Gasolina:
                        preco = PrecoGas;
                        break;
                    case TipoCombustivel.Etanol:
                        preco = PrecoEtanol;
                        break;
                }
                Abastecimento abastecimento = bomba.Abastecer(qtd, preco);
                Abastecimento.Add(abastecimento);
                return abastecimento;
            }
            else
            {
                throw new Exception("Bomba não encontrada pelo número!");
            }
        }
        public Dictionary<TipoCombustivel, float> GerarRelatorio()
        {
            Dictionary<TipoCombustivel, float> precos = new Dictionary<TipoCombustivel, float>();
            precos.Add(TipoCombustivel.Gasolina, 0f);
            precos.Add(TipoCombustivel.Etanol, 0f);

            foreach(Abastecimento a in Abastecimento)
            {
                TipoCombustivel tipo = a.Bomba.Tipo;
                float valor = a.Valor;
                precos[tipo] += valor;
            }
            return precos;
        }
    }
}
