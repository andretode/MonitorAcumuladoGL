namespace GraficoFromCSV
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            buttonMonitorar = new Button();
            comboBoxFrequencia = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            buttonPararMonitoramento = new Button();
            buttonVisualizarGrafico = new Button();
            tabControl1 = new TabControl();
            tabMonitoramento = new TabPage();
            tabGrafico = new TabPage();
            label4 = new Label();
            label3 = new Label();
            listBoxDias = new ListBox();
            tabGainLoss = new TabPage();
            label7 = new Label();
            labelDiasSemGL = new Label();
            labelRotuloSemGL = new Label();
            labelRotuloResultado = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            labelResultado = new Label();
            labelPrejuizo = new Label();
            labelLucro = new Label();
            labelDiasGain = new Label();
            labelDiasLoss = new Label();
            label6 = new Label();
            textBoxLoss = new TextBox();
            textBoxGain = new TextBox();
            label5 = new Label();
            buttonCalcular = new Button();
            toolTipDiasSemGL = new ToolTip(components);
            tabControl1.SuspendLayout();
            tabMonitoramento.SuspendLayout();
            tabGrafico.SuspendLayout();
            tabGainLoss.SuspendLayout();
            SuspendLayout();
            // 
            // buttonMonitorar
            // 
            buttonMonitorar.BackColor = SystemColors.Window;
            buttonMonitorar.Location = new Point(6, 249);
            buttonMonitorar.Name = "buttonMonitorar";
            buttonMonitorar.Size = new Size(115, 34);
            buttonMonitorar.TabIndex = 0;
            buttonMonitorar.Text = "Iniciar\r\n";
            buttonMonitorar.UseVisualStyleBackColor = false;
            buttonMonitorar.Click += buttonMonitorar_Click;
            // 
            // comboBoxFrequencia
            // 
            comboBoxFrequencia.FormattingEnabled = true;
            comboBoxFrequencia.Items.AddRange(new object[] { "5", "10", "15" });
            comboBoxFrequencia.Location = new Point(6, 220);
            comboBoxFrequencia.Name = "comboBoxFrequencia";
            comboBoxFrequencia.Size = new Size(248, 23);
            comboBoxFrequencia.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 202);
            label1.Name = "label1";
            label1.Size = new Size(180, 15);
            label1.TabIndex = 2;
            label1.Text = "Frequência da captura de valores";
            // 
            // label2
            // 
            label2.BackColor = SystemColors.Info;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(6, 2);
            label2.Name = "label2";
            label2.Size = new Size(248, 159);
            label2.TabIndex = 3;
            label2.Text = resources.GetString("label2.Text");
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // buttonPararMonitoramento
            // 
            buttonPararMonitoramento.BackColor = SystemColors.Window;
            buttonPararMonitoramento.Enabled = false;
            buttonPararMonitoramento.Location = new Point(139, 249);
            buttonPararMonitoramento.Name = "buttonPararMonitoramento";
            buttonPararMonitoramento.Size = new Size(115, 34);
            buttonPararMonitoramento.TabIndex = 4;
            buttonPararMonitoramento.Text = "Parar";
            buttonPararMonitoramento.UseVisualStyleBackColor = false;
            buttonPararMonitoramento.Click += buttonPararMonitoramento_Click;
            // 
            // buttonVisualizarGrafico
            // 
            buttonVisualizarGrafico.BackColor = Color.LightSkyBlue;
            buttonVisualizarGrafico.Location = new Point(6, 256);
            buttonVisualizarGrafico.Name = "buttonVisualizarGrafico";
            buttonVisualizarGrafico.Size = new Size(248, 33);
            buttonVisualizarGrafico.TabIndex = 5;
            buttonVisualizarGrafico.Text = "Visualizar Gráfico";
            buttonVisualizarGrafico.UseVisualStyleBackColor = false;
            buttonVisualizarGrafico.Click += buttonVisualizarGrafico_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabMonitoramento);
            tabControl1.Controls.Add(tabGrafico);
            tabControl1.Controls.Add(tabGainLoss);
            tabControl1.Location = new Point(12, 11);
            tabControl1.Margin = new Padding(3, 2, 3, 2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(268, 320);
            tabControl1.TabIndex = 6;
            tabControl1.Selecting += tabControl1_Selecting;
            // 
            // tabMonitoramento
            // 
            tabMonitoramento.Controls.Add(label2);
            tabMonitoramento.Controls.Add(buttonPararMonitoramento);
            tabMonitoramento.Controls.Add(buttonMonitorar);
            tabMonitoramento.Controls.Add(label1);
            tabMonitoramento.Controls.Add(comboBoxFrequencia);
            tabMonitoramento.Location = new Point(4, 24);
            tabMonitoramento.Margin = new Padding(3, 2, 3, 2);
            tabMonitoramento.Name = "tabMonitoramento";
            tabMonitoramento.Padding = new Padding(3, 2, 3, 2);
            tabMonitoramento.Size = new Size(260, 292);
            tabMonitoramento.TabIndex = 0;
            tabMonitoramento.Text = "Monitoramento";
            tabMonitoramento.UseVisualStyleBackColor = true;
            // 
            // tabGrafico
            // 
            tabGrafico.Controls.Add(label4);
            tabGrafico.Controls.Add(label3);
            tabGrafico.Controls.Add(listBoxDias);
            tabGrafico.Controls.Add(buttonVisualizarGrafico);
            tabGrafico.Location = new Point(4, 24);
            tabGrafico.Margin = new Padding(3, 2, 3, 2);
            tabGrafico.Name = "tabGrafico";
            tabGrafico.Padding = new Padding(3, 2, 3, 2);
            tabGrafico.Size = new Size(260, 292);
            tabGrafico.TabIndex = 1;
            tabGrafico.Text = "Gráfico";
            tabGrafico.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.BackColor = SystemColors.Info;
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(6, 2);
            label4.Name = "label4";
            label4.Size = new Size(248, 57);
            label4.TabIndex = 8;
            label4.Text = "Como Usar:\r\n1- Selecione os dados do dia capturado.\r\n2- Clique em \"Visualizar Gráfico\".";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 68);
            label3.Name = "label3";
            label3.Size = new Size(142, 15);
            label3.TabIndex = 7;
            label3.Text = "Dados capturados por dia";
            // 
            // listBoxDias
            // 
            listBoxDias.FormattingEnabled = true;
            listBoxDias.ItemHeight = 15;
            listBoxDias.Location = new Point(6, 86);
            listBoxDias.Name = "listBoxDias";
            listBoxDias.Size = new Size(248, 169);
            listBoxDias.TabIndex = 6;
            // 
            // tabGainLoss
            // 
            tabGainLoss.Controls.Add(label7);
            tabGainLoss.Controls.Add(labelDiasSemGL);
            tabGainLoss.Controls.Add(labelRotuloSemGL);
            tabGainLoss.Controls.Add(labelRotuloResultado);
            tabGainLoss.Controls.Add(label8);
            tabGainLoss.Controls.Add(label9);
            tabGainLoss.Controls.Add(label10);
            tabGainLoss.Controls.Add(label11);
            tabGainLoss.Controls.Add(labelResultado);
            tabGainLoss.Controls.Add(labelPrejuizo);
            tabGainLoss.Controls.Add(labelLucro);
            tabGainLoss.Controls.Add(labelDiasGain);
            tabGainLoss.Controls.Add(labelDiasLoss);
            tabGainLoss.Controls.Add(label6);
            tabGainLoss.Controls.Add(textBoxLoss);
            tabGainLoss.Controls.Add(textBoxGain);
            tabGainLoss.Controls.Add(label5);
            tabGainLoss.Controls.Add(buttonCalcular);
            tabGainLoss.Location = new Point(4, 24);
            tabGainLoss.Name = "tabGainLoss";
            tabGainLoss.Size = new Size(260, 292);
            tabGainLoss.TabIndex = 2;
            tabGainLoss.Text = "Estudo";
            tabGainLoss.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.BackColor = SystemColors.Info;
            label7.BorderStyle = BorderStyle.FixedSingle;
            label7.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(9, 12);
            label7.Name = "label7";
            label7.Size = new Size(248, 57);
            label7.TabIndex = 17;
            label7.Text = "Como Usar:\r\n1- Informe o gain/loss do estudo.\r\n2- Clique em \"Fazer Estudo\".";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelDiasSemGL
            // 
            labelDiasSemGL.AutoSize = true;
            labelDiasSemGL.Font = new Font("Segoe UI", 9F);
            labelDiasSemGL.ForeColor = Color.DarkOrange;
            labelDiasSemGL.Location = new Point(162, 184);
            labelDiasSemGL.Name = "labelDiasSemGL";
            labelDiasSemGL.Size = new Size(17, 15);
            labelDiasSemGL.TabIndex = 16;
            labelDiasSemGL.Text = "--";
            labelDiasSemGL.Visible = false;
            // 
            // labelRotuloSemGL
            // 
            labelRotuloSemGL.AutoSize = true;
            labelRotuloSemGL.Font = new Font("Segoe UI", 9F);
            labelRotuloSemGL.ForeColor = Color.DarkOrange;
            labelRotuloSemGL.Location = new Point(14, 184);
            labelRotuloSemGL.Name = "labelRotuloSemGL";
            labelRotuloSemGL.Size = new Size(120, 15);
            labelRotuloSemGL.TabIndex = 15;
            labelRotuloSemGL.Text = "Dias não atingidos [?]";
            toolTipDiasSemGL.SetToolTip(labelRotuloSemGL, "Dias não atingidos pelo gain/loss alvo informado.");
            labelRotuloSemGL.Visible = false;
            // 
            // labelRotuloResultado
            // 
            labelRotuloResultado.AutoSize = true;
            labelRotuloResultado.Location = new Point(14, 261);
            labelRotuloResultado.Name = "labelRotuloResultado";
            labelRotuloResultado.Size = new Size(62, 15);
            labelRotuloResultado.TabIndex = 14;
            labelRotuloResultado.Text = "Resultado:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = Color.Red;
            label8.Location = new Point(14, 246);
            label8.Name = "label8";
            label8.Size = new Size(84, 15);
            label8.TabIndex = 13;
            label8.Text = "Prejuízo bruto:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = Color.LimeGreen;
            label9.Location = new Point(14, 231);
            label9.Name = "label9";
            label9.Size = new Size(72, 15);
            label9.TabIndex = 12;
            label9.Text = "Lucro Bruto:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ForeColor = Color.LimeGreen;
            label10.Location = new Point(14, 201);
            label10.Name = "label10";
            label10.Size = new Size(75, 15);
            label10.TabIndex = 11;
            label10.Text = "Dias de Gain:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.ForeColor = Color.Red;
            label11.Location = new Point(14, 216);
            label11.Name = "label11";
            label11.Size = new Size(74, 15);
            label11.TabIndex = 10;
            label11.Text = "Dias de Loss:";
            // 
            // labelResultado
            // 
            labelResultado.AutoSize = true;
            labelResultado.Location = new Point(162, 261);
            labelResultado.Name = "labelResultado";
            labelResultado.Size = new Size(17, 15);
            labelResultado.TabIndex = 9;
            labelResultado.Text = "--";
            // 
            // labelPrejuizo
            // 
            labelPrejuizo.AutoSize = true;
            labelPrejuizo.ForeColor = Color.Red;
            labelPrejuizo.Location = new Point(162, 246);
            labelPrejuizo.Name = "labelPrejuizo";
            labelPrejuizo.Size = new Size(17, 15);
            labelPrejuizo.TabIndex = 8;
            labelPrejuizo.Text = "--";
            // 
            // labelLucro
            // 
            labelLucro.AutoSize = true;
            labelLucro.ForeColor = Color.LimeGreen;
            labelLucro.Location = new Point(162, 231);
            labelLucro.Name = "labelLucro";
            labelLucro.Size = new Size(17, 15);
            labelLucro.TabIndex = 7;
            labelLucro.Text = "--";
            // 
            // labelDiasGain
            // 
            labelDiasGain.AutoSize = true;
            labelDiasGain.ForeColor = Color.LimeGreen;
            labelDiasGain.Location = new Point(162, 201);
            labelDiasGain.Name = "labelDiasGain";
            labelDiasGain.Size = new Size(17, 15);
            labelDiasGain.TabIndex = 6;
            labelDiasGain.Text = "--";
            // 
            // labelDiasLoss
            // 
            labelDiasLoss.AutoSize = true;
            labelDiasLoss.ForeColor = Color.Red;
            labelDiasLoss.Location = new Point(162, 216);
            labelDiasLoss.Name = "labelDiasLoss";
            labelDiasLoss.Size = new Size(17, 15);
            labelDiasLoss.TabIndex = 5;
            labelDiasLoss.Text = "--";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(154, 84);
            label6.Name = "label6";
            label6.Size = new Size(55, 15);
            label6.TabIndex = 4;
            label6.Text = "Loss alvo";
            // 
            // textBoxLoss
            // 
            textBoxLoss.Location = new Point(154, 102);
            textBoxLoss.Name = "textBoxLoss";
            textBoxLoss.Size = new Size(64, 23);
            textBoxLoss.TabIndex = 3;
            textBoxLoss.Text = "2800";
            textBoxLoss.KeyPress += textBoxLoss_KeyPress;
            // 
            // textBoxGain
            // 
            textBoxGain.Location = new Point(38, 102);
            textBoxGain.Name = "textBoxGain";
            textBoxGain.Size = new Size(64, 23);
            textBoxGain.TabIndex = 2;
            textBoxGain.Text = "1500";
            textBoxGain.KeyPress += textBoxGain_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(38, 84);
            label5.Name = "label5";
            label5.Size = new Size(56, 15);
            label5.TabIndex = 1;
            label5.Text = "Gain alvo";
            // 
            // buttonCalcular
            // 
            buttonCalcular.Location = new Point(14, 142);
            buttonCalcular.Name = "buttonCalcular";
            buttonCalcular.Size = new Size(231, 29);
            buttonCalcular.TabIndex = 0;
            buttonCalcular.Text = "Fazer Estudo";
            buttonCalcular.UseVisualStyleBackColor = true;
            buttonCalcular.Click += buttonCalcular_Click;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(288, 334);
            Controls.Add(tabControl1);
            MaximizeBox = false;
            Name = "FormPrincipal";
            Text = "Monitor GL Flexscan";
            tabControl1.ResumeLayout(false);
            tabMonitoramento.ResumeLayout(false);
            tabMonitoramento.PerformLayout();
            tabGrafico.ResumeLayout(false);
            tabGrafico.PerformLayout();
            tabGainLoss.ResumeLayout(false);
            tabGainLoss.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonMonitorar;
        private Label label1;
        private Label label2;
        public ComboBox comboBoxFrequencia;
        private Button buttonPararMonitoramento;
        private Button buttonVisualizarGrafico;
        private TabControl tabControl1;
        private TabPage tabMonitoramento;
        private TabPage tabGrafico;
        private ListBox listBoxDias;
        private Label label3;
        private Label label4;
        private TabPage tabGainLoss;
        private TextBox textBoxGain;
        private Label label5;
        private Button buttonCalcular;
        private Label label6;
        private TextBox textBoxLoss;
        private Label labelResultado;
        private Label labelPrejuizo;
        private Label labelLucro;
        private Label labelDiasGain;
        private Label labelDiasLoss;
        private Label labelRotuloResultado;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label labelRotuloSemGL;
        private Label labelDiasSemGL;
        private ToolTip toolTipDiasSemGL;
        private Label label7;
    }
}