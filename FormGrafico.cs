using System.Globalization;

namespace GraficoFromCSV
{
    public partial class FormGrafico : Form
    {
        public FormGrafico(ItemLista itemLista)
        {
            InitializeComponent();

            Text = $"Multipla Padrão - {itemLista.Text}";
            LoadCsvAndPlot(itemLista);
        }

        private void LoadCsvAndPlot(ItemLista itemLista)
        {
            string csvFile = itemLista.Value;
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
                if (!DateTime.TryParseExact($"{itemLista.Text} {horaStr}", 
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
            var scatter = plt.Add.Scatter(xs.ToArray(), ys.ToArray()); // Corrige o uso do método Add.Scatter  

            // Substitui o método inexistente DateTimeFormat por configuração manual do formato do eixo X
            //plt.XAxis.DateTimeFormat(true); // Configura o eixo X para exibir datas/horas  
            plt.Axes.DateTimeTicksBottom();

            // Cria o controle FormsPlot (do ScottPlot) e configura-o para preencher o formulário  
            var formsPlot = new ScottPlot.WinForms.FormsPlot
            {
                Dock = DockStyle.Fill
            };

            // Atribui o plot ao controle FormsPlot usando o método Reset
            formsPlot.Reset(plt);

            // Adiciona o FormsPlot ao formulário  
            this.Controls.Add(formsPlot);
        }
    }
}
