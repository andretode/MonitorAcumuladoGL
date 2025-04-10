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
            tabControl1.SuspendLayout();
            tabMonitoramento.SuspendLayout();
            tabGrafico.SuspendLayout();
            SuspendLayout();
            // 
            // buttonMonitorar
            // 
            buttonMonitorar.BackColor = Color.LightGreen;
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
            buttonPararMonitoramento.BackColor = Color.Salmon;
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
    }
}