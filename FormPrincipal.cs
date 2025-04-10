using System.Data;

namespace GraficoFromCSV
{
    public partial class FormPrincipal : Form
    {
        FormGrafico? formGrafico;

        public FormPrincipal()
        {
            InitializeComponent();

            listBoxDias.DisplayMember = "Text";
            listBoxDias.ValueMember = "Value";
        }

        private async void buttonMonitorar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxFrequencia.Text))
            {
                MessageBox.Show("Selecione a frequência desejada.");
                return;
            }

            var frequenciaEmSegundos = int.Parse(comboBoxFrequencia.Text);
            var taskMonitoramento = Task.Run(() => CapturarValoresGL.Exec(frequenciaEmSegundos * 1000));

            try
            {
                comboBoxFrequencia.Enabled = false;
                buttonMonitorar.Enabled = false;
                buttonPararMonitoramento.Enabled = true;
                await taskMonitoramento;
            }
            finally
            {
                comboBoxFrequencia.Enabled = true;
                buttonMonitorar.Enabled = true;
                buttonPararMonitoramento.Enabled = false;
            }
        }

        private void buttonPararMonitoramento_Click(object sender, EventArgs e)
        {
            CapturarValoresGL.Cancelar();
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (tabControl1.SelectedTab?.Name == "tabGrafico")
            {
                AtualizarDiasDisponiveis();
                if (listBoxDias.Items.Count == 0)
                {
                    MessageBox.Show("Nenhum arquivo encontrado. O monitoramento deve ser iniciado primeiro.");
                    buttonVisualizarGrafico.Enabled = false;
                }
                else
                {
                    buttonVisualizarGrafico.Enabled = true;
                }
            }
        }

        private void AtualizarDiasDisponiveis()
        {
            listBoxDias.Items.Clear();
            var arquivos = Directory.GetFiles(Directory.GetCurrentDirectory(), "valores_*.csv");
            var itens = new List<ItemLista>();

            foreach (var arquivo in arquivos)
            {
                var nomeArquivo = Path.GetFileName(arquivo);
                var dataStr = nomeArquivo.Split('_')[1].Split('.')[0];
                var data = DateTime.ParseExact(dataStr, "yyyy-MM-dd", null).ToString("dd/MM/yyyy");
                itens.Add(new ItemLista(nomeArquivo, data));
            }

            var itensOrdenados = itens.OrderByDescending(x => x.Data).ToList();
            foreach (var item in itensOrdenados)
            {
                listBoxDias.Items.Add(item);
            }
        }

        private void buttonVisualizarGrafico_Click(object sender, EventArgs e)
        {
            if (listBoxDias.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecione um dia para visualizar o gráfico.");
                return;
            }

            var selecionado = listBoxDias.SelectedItems[0] as ItemLista;
            if (formGrafico != null && !formGrafico.IsDisposed)
                formGrafico.Dispose();
            formGrafico = new FormGrafico(selecionado);
            formGrafico.Show();

        }
    }

    public class ItemLista
    {        
        public ItemLista(string value, string text)
        {
            Value = value;
            Text = text;
        }

        public string Value { get; set; }
        public string Text { get; set; }
        public DateTime Data { 
            get
            {
                return DateTime.ParseExact(Text, "dd/MM/yyyy", null);
            }
        }
        public override string ToString()
        {
            return Text;
        }
    }
}
