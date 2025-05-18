using System.Data;

namespace GraficoFromCSV
{
    public partial class FormPrincipal : Form
    {
        FormGrafico? formGrafico;
        public static string nomePastaDados = "Dados";
        const string NOME_ARQUIVO_CONFIG = "app.config";

        public FormPrincipal()
        {
            InitializeComponent();

            comboBoxFrequencia.SelectedIndex = 0;
            listBoxDias.DisplayMember = "Text";
            listBoxDias.ValueMember = "Value";
            AjustarAparenciaBotoesMonitoramentoParado();
            CarregarNomePastaDados();
        }

        /// <summary>
        /// Carregar o nome da pasta de dados do arquivo de configuração
        /// </summary>
        private void CarregarNomePastaDados()
        {
            //string caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), NOME_ARQUIVO_CONFIG);
            if (File.Exists(NOME_ARQUIVO_CONFIG))
            {
                nomePastaDados = File.ReadAllText(NOME_ARQUIVO_CONFIG);
                textBoxPastaDados.Text = nomePastaDados;
            }
            else
            {
                SalvarNomePastaDados();
            }
        }

        /// <summary>
        /// Salvar o nome da pasta de dados no arquivo de configuração para ser recuperado
        /// na inicialização do programa.
        /// </summary>
        private void SalvarNomePastaDados()
        {
            File.WriteAllText(NOME_ARQUIVO_CONFIG, nomePastaDados);
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
                AjustarAparenciaBotoesMonitoramentoExecutando();
                await taskMonitoramento;
            }
            finally
            {
                AjustarAparenciaBotoesMonitoramentoParado();
            }
        }

        private void AjustarAparenciaBotoesMonitoramentoExecutando()
        {
            comboBoxFrequencia.Enabled = false;
            buttonMonitorar.Enabled = false;
            buttonPararMonitoramento.Enabled = true;
            buttonMonitorar.BackColor = Color.LightGray;
            buttonPararMonitoramento.BackColor = Color.Red;
        }

        private void AjustarAparenciaBotoesMonitoramentoParado()
        {
            comboBoxFrequencia.Enabled = true;
            buttonMonitorar.Enabled = true;
            buttonPararMonitoramento.Enabled = false;
            buttonMonitorar.BackColor = Color.LightGreen;
            buttonPararMonitoramento.BackColor = Color.LightGray;
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
            var itensOrdenados = Uteis.GetDiasDisponiveis();
            foreach (var item in itensOrdenados)
                listBoxDias.Items.Add(item);
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

        private void buttonCalcular_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxGain.Text) || string.IsNullOrEmpty(textBoxLoss.Text))
            {
                MessageBox.Show("Preencha os campos de ganho e perda.");
                return;
            }
            var gain = Math.Abs(int.Parse(textBoxGain.Text));
            var loss = Math.Abs(int.Parse(textBoxLoss.Text)) * -1;
            var resultado = Uteis.CalcularGainsLosses(gain, loss);

            labelDiasGain.Text = $"{resultado.DiasGain} de {resultado.DiasTotais}";
            labelDiasLoss.Text = $"{resultado.DiasLoss} de {resultado.DiasTotais}";
            if (resultado.DiaSemGL == 0)
            {
                labelDiasSemGL.Visible = false;
                labelRotuloSemGL.Visible = false;
            }
            else
            {
                labelDiasSemGL.Visible = true;
                labelRotuloSemGL.Visible = true;
                labelDiasSemGL.Text = $"{resultado.DiaSemGL} de {resultado.DiasTotais}";
            }
            labelLucro.Text = resultado.LucroBruto.ToString("C");
            labelPrejuizo.Text = resultado.PrejuizoBruto.ToString("C");
            labelResultado.Text = resultado.ResultadoFinal.ToString("C");
            var corResultado = resultado.ResultadoFinal >= 0 ? Color.LimeGreen : Color.Red;
            labelRotuloResultado.ForeColor = corResultado;
            labelResultado.ForeColor = corResultado;
        }

        private void textBoxLoss_KeyPress(object sender, KeyPressEventArgs e)
        {
            SomenteNumeros(e);
        }

        private void textBoxGain_KeyPress(object sender, KeyPressEventArgs e)
        {
            SomenteNumeros(e);
        }

        private void SomenteNumeros(KeyPressEventArgs e)
        {
            // Permite controle (backspace, delete, etc.)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // bloqueia a tecla
            }
        }

        private void buttonSalvarNomePastaDados_Click(object sender, EventArgs e)
        {
            nomePastaDados = textBoxPastaDados.Text.Trim();
            SalvarNomePastaDados();
            MessageBox.Show($"Nome salvo com sucesso!");
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
