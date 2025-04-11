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
            Text = $"Multipla - {itemLista.Text}";
            LoadCsvAndPlot();
        }

        private void LoadCsvAndPlot()
        {
            string csvFile = _itemLista.Value;
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
            plt.Title($"Multipla - {_itemLista.Text}");
            plt?.Add.Scatter(xs.ToArray(), ys.ToArray()); // Corrige o uso do método Add.Scatter  

            // Substitui o método inexistente DateTimeFormat por configuração manual do formato do eixo X
            plt?.Axes.DateTimeTicksBottom();

            // Cria o controle FormsPlot (do ScottPlot) e configura-o para preencher o formulário  
            _formsPlot = new FormsPlot
            {
                Dock = DockStyle.Fill
            };

            // Atribui o plot ao controle FormsPlot usando o método Reset
            _formsPlot.Reset(plt);

            // Add/update o FormsPlot ao formulário
            //if (Controls.Count > 1)
            //    Controls.RemoveAt(1);
            //Controls.Add(_formsPlot);
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
        }
    }
}