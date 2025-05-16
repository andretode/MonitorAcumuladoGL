using ScottPlot;
using ScottPlot.WinForms;
using System.Globalization;

namespace GraficoFromCSV
{
    public partial class FormGrafico : Form
    {
        private readonly ItemLista _itemLista;
        private FormsPlot _formsPlot;

        public FormGrafico(ItemLista itemLista)
        {
            _itemLista = itemLista;
            InitializeComponent();
            Text = $"Resultado Financeiro - {itemLista.Text}";
            LoadCsvAndPlot();
        }

        private void LoadCsvAndPlot()
        {
            string csvFile = Path.Combine(Uteis.GetCaminhoBaseArquivos(), _itemLista.Value);
            if (!File.Exists(csvFile))
            {
                MessageBox.Show("Arquivo CSV não encontrado!");
                return;
            }

            // Listas para armazenar os dados dos eixos X e Y  
            List<double> xs = new List<double>();
            List<double> ys = new List<double>();

            // Lê todas as linhas do CSV  
            string[] lines = File.ReadAllLines(csvFile);

            // Percorre as linhas ignorando o cabeçalho  
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i].Trim();
                if (string.IsNullOrEmpty(line))
                    continue;

                // Divide a linha pelo ponto e vírgula  
                string[] parts = line.Split(';');
                if (parts.Length < 2)
                    continue;

                string horaStr = parts[0].Trim();
                string valorStr = parts[1].Trim();

                // Converte a hora para DateTime  
                if (!DateTime.TryParseExact($"{_itemLista.Text} {horaStr}",
                    "dd/MM/yyyy HH:mm:ss",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime hora))
                {
                    if (!DateTime.TryParse(horaStr, out hora))
                        continue;
                }

                // Converte o valor para double usando cultura "pt-BR"  
                if (!double.TryParse(valorStr, NumberStyles.Any, new CultureInfo("pt-BR"), out double valor))
                    continue;

                // ScottPlot trabalha com números. Para exibir datas/hora, converta DateTime para OADate.  
                xs.Add(hora.ToOADate());
                ys.Add(valor);
            }

            // Cria a plotagem ScottPlot  
            var plt = new ScottPlot.Plot();
            plt.Title($"Resultado Financeiro - {_itemLista.Text}");

            // Adiciona a linha de dados com cor neutra
            var todos = plt.Add.Scatter(xs.ToArray(), ys.ToArray());
            todos.LineColor = ScottPlot.Color.FromColor(System.Drawing.Color.Gray);
            todos.MarkerSize = 0;

            List<(double x, double y)> segmento = new();
            bool? sinalAtual = null;

            for (int i = 0; i < xs.Count; i++)
            {
                double x = xs[i];
                double y = ys[i];
                bool positivo = y >= 0;

                // Se mudou de sinal, fecha o segmento anterior
                if (sinalAtual != null && positivo != sinalAtual)
                {
                    AdicionarSegmento(segmento, sinalAtual.Value);
                    segmento.Clear();

                    // Adiciona ponto anterior novamente para manter continuidade visual
                    if (i > 0)
                        segmento.Add((xs[i - 1], ys[i - 1]));
                }

                segmento.Add((x, y));
                sinalAtual = positivo;
            }

            // Adiciona o último segmento
            if (segmento.Count > 0 && sinalAtual != null)
                AdicionarSegmento(segmento, sinalAtual.Value);

            // Função auxiliar local
            void AdicionarSegmento(List<(double x, double y)> seg, bool positivo)
            {
                var xsSeg = seg.Select(p => p.x).ToArray();
                var ysSeg = seg.Select(p => p.y).ToArray();
                var cor = positivo ?
                    ScottPlot.Color.FromColor(System.Drawing.Color.Green) :
                    ScottPlot.Color.FromColor(System.Drawing.Color.Red);
                var linha = plt.Add.Scatter(xsSeg, ysSeg, cor);
                linha.MarkerSize = 0; // sem marcadores
            }

            // Substitui o método inexistente DateTimeFormat por configuração manual do formato do eixo X  
            plt.Axes.DateTimeTicksBottom();

            // Adiciona uma linha horizontal no valor zero  
            var hLineColocar = ScottPlot.Color.FromColor(System.Drawing.Color.Black);
            var hLine = plt.Add.HorizontalLine(0.5, 0.5F, hLineColocar, LinePattern.Dashed);

            // Cria o controle FormsPlot (do ScottPlot) e configura-o para preencher o formulário  
            _formsPlot = new FormsPlot { Dock = DockStyle.Fill };

            // Atribui o plot ao controle FormsPlot usando o método Reset  
            _formsPlot.Reset(plt);

            // Add/update o FormsPlot ao formulário  
            if (panelGrafico.Controls.Count > 0)
                panelGrafico.Controls.RemoveAt(0);
            panelGrafico.Controls.Add(_formsPlot);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Uteis.CopiarGraficoParaAreaDeTransferencia(_formsPlot);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            LoadCsvAndPlot();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Uteis.RemoverZerosIniciais(_itemLista);
            LoadCsvAndPlot();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Uteis.RemoverValoresIguaisNoFinal(_itemLista);
            LoadCsvAndPlot();
        }
    }
}