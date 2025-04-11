
using ScottPlot.WinForms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraficoFromCSV
{
    public static class Uteis
    {

        public static void CopiarGraficoParaAreaDeTransferencia(FormsPlot formsPlot)
        {
            var image = formsPlot?.Plot.GetImage(1200, 800);
            var bytes = image?.GetImageBytes(ScottPlot.ImageFormat.Png);
            using var memoryStream = new MemoryStream(bytes);
            var systemDrawingImage = System.Drawing.Image.FromStream(memoryStream);
            Clipboard.SetImage(systemDrawingImage);
            MessageBox.Show("Gráfico PNG copiado para a área de transferência!");
        }

        public static void RemoverZerosIniciais(ItemLista itemLista)
        {
            string csvFile = itemLista.Value;
            string[] linhas = File.ReadAllLines(csvFile);
            var resultado = new List<string>
            {
                // Mantém o cabeçalho
                linhas[0]
            };

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
    }
}
