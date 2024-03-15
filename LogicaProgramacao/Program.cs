using LogicaProgramacao.Pergunta_1;
using LogicaProgramacao.Pergunta_2;
using LogicaProgramacao.Pergunta_4;

char opcao;

do
{
    Console.WriteLine("Escolha uma opção:");
    Console.WriteLine("1 - Calcular desconto de carros");
    Console.WriteLine("2 - Calcular média ponderada para cada aluno");
    Console.WriteLine("4 - Recálculo de Boletos");
    Console.WriteLine("0 - Sair");

    opcao = char.ToUpper(Console.ReadKey().KeyChar);
    Console.WriteLine();

    switch (opcao)
    {
        case '1':
            ConcessionariaCarros.CalcularDesconto();
            break;
        case '2':
            MediaPonderada.Aluno();
            break;
        case '4':
            Boleto.Recalcular();
            break;
        case '0':
            Console.WriteLine("Saindo...");
            break;
        default:
            Console.WriteLine("Opção inválida.");
            break;
    }
} while (opcao != '3');