namespace LogicaProgramacao.Pergunta_2
{
    public class MediaPonderada
    {
        public static void Aluno()
        {
            int codigo;

            do
            {
                Console.WriteLine("Digite o código do aluno (ou 0 para encerrar):");
                codigo = int.Parse(Console.ReadLine());

                if (codigo != 0)
                {
                    Console.WriteLine("Digite as três notas do aluno:");
                    double nota1 = double.Parse(Console.ReadLine());
                    double nota2 = double.Parse(Console.ReadLine());
                    double nota3 = double.Parse(Console.ReadLine());

                    double media = CalcularMediaPonderada(nota1, nota2, nota3);

                    Console.WriteLine($"Código do aluno: {codigo}");
                    Console.WriteLine($"Notas: {nota1}, {nota2}, {nota3}");
                    Console.WriteLine($"Média ponderada: {media}");

                    if (media >= 6)
                    {
                        Console.WriteLine("Situação: APROVADO\n");
                    }
                    else
                    {
                        Console.WriteLine("Situação: REPROVADO\n");
                    }
                }
            } while (codigo != 0);
        }

        static double CalcularMediaPonderada(double nota1, double nota2, double nota3)
        {
            // Determina a maior nota
            double maiorNota = Math.Max(Math.Max(nota1, nota2), nota3);

            // Calcula a média ponderada
            double media = (maiorNota * 4 + (nota1 + nota2 + nota3 - maiorNota) * 3) / 10;
            return media;
        }
    }
}
