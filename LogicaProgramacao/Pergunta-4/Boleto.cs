namespace LogicaProgramacao.Pergunta_4
{
    public class Boleto
    {
        public static void Recalcular()
        {
            Console.WriteLine("Informe a data de vencimento (no formato dd/MM/yyyy):");
            DateTime vencimentoOriginal = LerData();

            Console.WriteLine("Informe a nova data de vencimento (data de pagamento) (no formato dd/MM/yyyy):");
            DateTime novaDataVencimento = LerData();

            Console.WriteLine("Informe o valor do boleto:");
            double valorBoleto = LerDouble();

            double valorRecalculado = RecalcularBoleto(vencimentoOriginal, novaDataVencimento, valorBoleto, 0.03, 2.00);
            Console.WriteLine($"Valor do boleto recalculado: R$ {valorRecalculado:F2}");
        }

        static DateTime LerData()
        {
            DateTime data;
            while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out data))
            {
                Console.WriteLine("Formato de data inválido. Por favor, insira novamente (no formato dd/MM/yyyy):");
            }
            return data;
        }

        static double LerDouble()
        {
            double valor;
            while (!double.TryParse(Console.ReadLine(), out valor))
            {
                Console.WriteLine("Valor inválido. Por favor, insira um número válido:");
            }
            return valor;
        }

        public static double  RecalcularBoleto(DateTime vencimentoOriginal, DateTime novaDataVencimento, double valorBoleto, double jurosDiario, double multa)
        {
            double valorRecalculado = valorBoleto;

            // Verifica se a data de pagamento é anterior à data de vencimento
            if (novaDataVencimento < vencimentoOriginal)
                return valorRecalculado; // Retorna o valor original do boleto

            TimeSpan periodo = novaDataVencimento - vencimentoOriginal;
            int numDias = periodo.Days;

            DateTime dataTemp = vencimentoOriginal;

            for (int i = 0; i < numDias; i++)
            {
                // Verifica se a data é feriado ou final de semana
                if (VerificaFeriado(dataTemp) || VerificaFinalDeSemana(dataTemp))
                {
                    // Verifica se o pagamento ocorre no próximo dia útil consecutivo
                    if (!VerificaFinalDeSemana(dataTemp.AddDays(1)) && !VerificaFeriado(dataTemp.AddDays(1)))
                    {
                        if (dataTemp != vencimentoOriginal && dataTemp != novaDataVencimento)
                        {
                            // Se o pagamento ocorrer após o próximo dia útil consecutivo a um feriado ou final de semana
                            valorRecalculado += jurosDiario;
                        }
                    }
                }
                dataTemp = dataTemp.AddDays(1);
            }

            // Adiciona multa se o pagamento for posterior ao vencimento
            if (novaDataVencimento > vencimentoOriginal)
                valorRecalculado += multa;

            return valorRecalculado;
        }

        static bool VerificaFeriado(DateTime data)
        {
            DateTime[] feriados = {
            new DateTime(data.Year, 1, 1),   // Ano Novo
            new DateTime(data.Year, 4, 21),  // Tiradentes
            new DateTime(data.Year, 5, 1),   // Dia do Trabalhador
            new DateTime(data.Year, 9, 7),   // Independência do Brasil
            new DateTime(data.Year, 10, 12), // Dia de Nossa Senhora Aparecida
            new DateTime(data.Year, 11, 2),  // Finados
            new DateTime(data.Year, 11, 15), // Proclamação da República
            new DateTime(data.Year, 12, 25)  // Natal
            };

            foreach (DateTime feriado in feriados)
            {
                if (data.Date == feriado.Date)
                {
                    return true; // Se a data corresponder a um feriado, retorna verdadeiro
                }
            }

            return false; // Se não for feriado, retorna falso
        }

        static bool VerificaFinalDeSemana(DateTime data)
        {
            return data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday;
        }

    }
}
