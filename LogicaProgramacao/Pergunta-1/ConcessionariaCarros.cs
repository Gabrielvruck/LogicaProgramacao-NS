namespace LogicaProgramacao.Pergunta_1
{
    public class ConcessionariaCarros
    {
        public static void CalcularDesconto()
        {
            int totalCarrosAte2000 = 0;
            int totalGeral = 0;

            char continuar;

            do
            {
                Console.WriteLine("Digite o ano do carro:");
                int ano = int.Parse(Console.ReadLine());

                double desconto;
                if (ano <= 2000)
                {
                    desconto = 0.12;
                    totalCarrosAte2000++;
                }
                else
                {
                    desconto = 0.07;
                }

                Console.WriteLine("Digite o valor do carro:");
                double valor = double.Parse(Console.ReadLine());

                double valorComDesconto = valor - (valor * desconto);

                Console.WriteLine($"Desconto: {desconto * 100}%");
                Console.WriteLine($"Valor a ser pago: R${valorComDesconto}");

                totalGeral++;

                Console.WriteLine("Deseja continuar calculando desconto? (S/N)");
                continuar = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();
            } while (continuar == 'S');

            Console.WriteLine($"Total de carros até 2000: {totalCarrosAte2000}");
            Console.WriteLine($"Total geral: {totalGeral}");
        }

    }
}
