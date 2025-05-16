using ScottPlot.WinForms;
using System.Globalization;

namespace GraficoFromCSV
{
    public static class Uteis
    {
        public static string GetCaminhoBaseArquivos()
        {
            string caminhoBase = Path.Combine(Directory.GetCurrentDirectory(), "Dados2");
            if (!Directory.Exists(caminhoBase))
                Directory.CreateDirectory(caminhoBase);
            return caminhoBase;
        }

        public static List<ItemLista> GetDiasDisponiveis()
        {
            var arquivos = Directory.GetFiles(Uteis.GetCaminhoBaseArquivos(), "valores_*.csv");
            var itens = new List<ItemLista>();

            foreach (var arquivo in arquivos)
            {
                var nomeArquivo = Path.GetFileName(arquivo);
                var dataStr = nomeArquivo.Split('_')[1].Split('.')[0];
                var data = DateTime.ParseExact(dataStr, "yyyy-MM-dd", null).ToString("dd/MM/yyyy");
                itens.Add(new ItemLista(nomeArquivo, data));
            }

            var itensOrdenados = itens.OrderByDescending(x => x.Data).ToList();
            return itensOrdenados;
        }

        public static void CopiarGraficoParaAreaDeTransferencia(FormsPlot formsPlot)
        {
            var image = formsPlot?.Plot.GetImage(1200, 800);
            var bytes = image?.GetImageBytes(ScottPlot.ImageFormat.Png);
            using var memoryStream = new MemoryStream(bytes);
            var systemDrawingImage = Image.FromStream(memoryStream);
            Clipboard.SetImage(systemDrawingImage);
            MessageBox.Show("Gráfico PNG copiado para a área de transferência!");
        }

        public static void RemoverZerosIniciais(ItemLista itemLista)
        {
            string csvFile = Path.Combine(GetCaminhoBaseArquivos(), itemLista.Value);
            string[] linhas = File.ReadAllLines(csvFile);
            var resultado = new List<string> { linhas[0] }; // Mantém o cabeçalho
            bool encontrouValorDiferenteDeZero = false;

            foreach (var linha in linhas.Skip(1)) // Pula o cabeçalho
            {
                var partes = linha.Split(';');
                if (partes.Length < 2)
                    continue;

                // Remove espaços e converte para decimal
                var valorTexto = partes[1].Trim();
                if (decimal.TryParse(valorTexto, NumberStyles.Any, new CultureInfo("pt-BR"), out decimal valor))
                {
                    if (!encontrouValorDiferenteDeZero)
                    {
                        if (valor != 0)
                            encontrouValorDiferenteDeZero = true;
                    }

                    if (encontrouValorDiferenteDeZero)
                        resultado.Add(linha);
                }
            }

            File.WriteAllLines(csvFile, resultado);
        }

        public static void RemoverValoresIguaisNoFinal(ItemLista itemLista)
        {
            string csvFile = Path.Combine(GetCaminhoBaseArquivos(), itemLista.Value);
            string[] linhas = File.ReadAllLines(csvFile);
            var resultado = linhas.ToList();

            for (int i = linhas.Length - 1; i > 0; i--)
            {                
                var valorAtual = linhas[i].Split(';')[1].Trim();
                var valorAnterior = linhas[i - 1].Split(';')[1].Trim();
                if (valorAtual == valorAnterior)
                    resultado.RemoveAt(i);
                else
                    break;
            }
            File.WriteAllLines(csvFile, resultado);
        }

        public static Resultado CalcularGainsLosses(int gain, int loss)
        {
            int diasGain = 0;
            int diasLoss = 0;
            var dias = Uteis.GetDiasDisponiveis();
            foreach (var item in dias)
            {
                var arquivo = Path.Combine(Uteis.GetCaminhoBaseArquivos(), item.Value);
                var linhas = File.ReadAllLines(arquivo);
                for (int i = 1; i < linhas.Length; i++)
                {
                    var partes = linhas[i].Split(';');
                    if (double.TryParse(partes[1], out double valor))
                    {
                        if (valor >= gain)
                        {
                            diasGain++;
                            i = linhas.Length; // Para não contar mais de um ganho no mesmo dia
                        }
                        else if (valor <= loss)
                        {
                            diasLoss++;
                            i = linhas.Length; // Para não contar mais de uma perda no mesmo dia
                        }
                    }
                }
            }
            var lucro = gain * diasGain;
            var prejuizo = loss * diasLoss;

            return new Resultado
            {
                DiasTotais = dias.Count,
                DiasGain = diasGain,
                DiasLoss = diasLoss,
                DiaSemGL = dias.Count-diasGain-diasLoss,
                LucroBruto = lucro,
                PrejuizoBruto = prejuizo,
                ResultadoFinal = lucro + prejuizo
            };
        }
    }
}

public class Resultado
{
    public int DiasTotais { get; set; }
    public int DiasGain { get; set; }
    public int DiasLoss { get; set; }
    public int DiaSemGL { get; set; }
    public double LucroBruto { get; set; }
    public double PrejuizoBruto { get; set; }
    public double ResultadoFinal { get; set; }
}