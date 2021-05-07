using System;

namespace Posto_Combustivel_WF
{
    class Program
    {
        static void Main(string[] args)
        {
            PostoCombustivel posto1;
            Abastecimento abastecimento1;

            TipoCombustivel[] tiposBombas =
            {
                TipoCombustivel.Gasolina,
                TipoCombustivel.Etanol,
                TipoCombustivel.Gasolina,
                TipoCombustivel.Etanol,
            };
            posto1 = new PostoCombustivel("Posto VGD", tiposBombas, 5.60f, 4.09f);

            MostrarStatusBombas(posto1);

            abastecimento1 = posto1.Abastecer(50, 2);
            Abastecimento a2 = posto1.Abastecer(26, 2);
            Abastecimento a3 = posto1.Abastecer(47, 4);
            Abastecimento a4 = posto1.Abastecer(28, 3);
            Abastecimento a5 = posto1.Abastecer(97.5f, 1);

            abastecimento1.MarcarPago(true);
            a2.MarcarPago(true);
            a3.MarcarPago(true);
            a4.MarcarPago(true);
            a2.MarcarPago(true);

            MudarPreco(posto1);

            MostrarStatusBombas(posto1);
        }
        static void MostrarStatusBombas(PostoCombustivel posto)
        {
            Console.WriteLine($"Status das bombas do posto {posto.Nome}");
            foreach (BombaCombustivel b in posto.Bombas)
            {
                Console.WriteLine($"Bomba {b.NumBomba} de {b.Tipo}\n" +
                    $"Capacidade: {b.Capacidade}");
            }
            Console.WriteLine();
        }
        static void MudarPreco(PostoCombustivel posto)
        {
            TipoCombustivel tipo;
            float preco;
            int num = -1;
            do
            {
                Console.WriteLine("Digite 0 para mudar o preço da gasolina.\n" +
                    "Digite 1 para mudar o preço do etanol");
                num = int.Parse(Console.ReadLine());
            } while (num != 0 && num != 1);

            if (num == 0) tipo = TipoCombustivel.Gasolina;
            else tipo = TipoCombustivel.Etanol;

            Console.WriteLine($"Digite o novo valor do combustível: {tipo}");
            preco = float.Parse(Console.ReadLine());
            if (tipo == TipoCombustivel.Gasolina) posto.PrecoGas = preco;
            else if (tipo == TipoCombustivel.Etanol) posto.PrecoEtanol = preco;
        }
    }
}
