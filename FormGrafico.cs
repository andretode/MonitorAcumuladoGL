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
            Text = $"Multipla Padr�o - {itemLista.Text}";
            LoadCsvAndPlot();
        }

        private void LoadCsvAndPlot()
        {
            string csvFile = _itemLista.Value;
            if (!File.Exists(csvFile))
            {
                MessageBox.Show("Arquivo CSV n�o encontrado!");
                return;
            }

            // Listas para armazenar os dados dos eixos X e Y  
            List<double> xs = new List<double>();
            List<double> ys = new List<double>();

            // L� todas as linhas do CSV  
            string[] lines = File.ReadAllLines(csvFile);

            // Percorre as linhas ignorando o cabe�alho  
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i].Trim();
                if (string.IsNullOrEmpty(line))
                    continue;

                // Divide a linha pelo ponto e v�rgula  
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

                // ScottPlot trabalha com n�meros. Para exibir datas/hora, converta DateTime para OADate.  
                xs.Add(hora.ToOADate());
                ys.Add(valor);
            }

            // Cria a plotagem ScottPlot  
            var plt = new ScottPlot.Plot();
            var scatter = plt.Add.Scatter(xs.ToArray(), ys.ToArray()); // Corrige o uso do m�todo Add.Scatter  

            // Substitui o m�todo inexistente DateTimeFormat por configura��o manual do formato do eixo X
            //plt.XAxis.DateTimeFormat(true); // Configura o eixo X para exibir datas/horas  
            plt.Axes.DateTimeTicksBottom();

            // Cria o controle FormsPlot (do ScottPlot) e configura-o para preencher o formul�rio  
            _formsPlot = new FormsPlot
            {
                Dock = DockStyle.Fill
            };

            // Atribui o plot ao controle FormsPlot usando o m�todo Reset
            _formsPlot.Reset(plt);

            // Add/update o FormsPlot ao formul�rio
            if(Controls.Count > 1)
                Controls.RemoveAt(1);
            Controls.Add(_formsPlot);
        }

        private void CopiarGraficoParaAreaDeTransferencia()
        {
            var image = _formsPlot?.Plot.GetImage(1200, 800);
            var bytes = image?.GetImageBytes(ScottPlot.ImageFormat.Png);
            using var memoryStream = new MemoryStream(bytes);
            var systemDrawingImage = System.Drawing.Image.FromStream(memoryStream);
            Clipboard.SetImage(systemDrawingImage);
            MessageBox.Show("Gr�fico PNG copiado para a �rea de transfer�ncia!");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            CopiarGraficoParaAreaDeTransferencia();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            LoadCsvAndPlot();
        }
    }
}