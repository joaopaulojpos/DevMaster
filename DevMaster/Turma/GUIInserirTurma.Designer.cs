namespace GUI
{
    partial class GUIInserirTurma
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxAno = new System.Windows.Forms.ComboBox();
            this.dateDataInicio = new System.Windows.Forms.DateTimePicker();
            this.comboBoxEnsino = new System.Windows.Forms.ComboBox();
            this.comboBoxTurno = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnConcluir = new System.Windows.Forms.Button();
            this.textBoxDescricao = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBoxAno);
            this.panel1.Controls.Add(this.dateDataInicio);
            this.panel1.Controls.Add(this.comboBoxEnsino);
            this.panel1.Controls.Add(this.comboBoxTurno);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnVoltar);
            this.panel1.Controls.Add(this.btnConcluir);
            this.panel1.Controls.Add(this.textBoxDescricao);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(456, 274);
            this.panel1.TabIndex = 5;
            // 
            // comboBoxAno
            // 
            this.comboBoxAno.FormattingEnabled = true;
            this.comboBoxAno.Location = new System.Drawing.Point(93, 104);
            this.comboBoxAno.Name = "comboBoxAno";
            this.comboBoxAno.Size = new System.Drawing.Size(132, 21);
            this.comboBoxAno.TabIndex = 22;
            // 
            // dateDataInicio
            // 
            this.dateDataInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDataInicio.Location = new System.Drawing.Point(93, 175);
            this.dateDataInicio.Name = "dateDataInicio";
            this.dateDataInicio.Size = new System.Drawing.Size(132, 20);
            this.dateDataInicio.TabIndex = 21;
            this.dateDataInicio.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // comboBoxEnsino
            // 
            this.comboBoxEnsino.FormattingEnabled = true;
            this.comboBoxEnsino.Location = new System.Drawing.Point(93, 63);
            this.comboBoxEnsino.Name = "comboBoxEnsino";
            this.comboBoxEnsino.Size = new System.Drawing.Size(132, 21);
            this.comboBoxEnsino.TabIndex = 20;
            this.comboBoxEnsino.SelectedIndexChanged += new System.EventHandler(this.comboBoxEnsino_SelectedIndexChanged_1);
            // 
            // comboBoxTurno
            // 
            this.comboBoxTurno.FormattingEnabled = true;
            this.comboBoxTurno.Location = new System.Drawing.Point(93, 137);
            this.comboBoxTurno.Name = "comboBoxTurno";
            this.comboBoxTurno.Size = new System.Drawing.Size(132, 21);
            this.comboBoxTurno.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Ensino:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Ano:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Turno:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Data de Início:";
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(359, 228);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(85, 34);
            this.btnVoltar.TabIndex = 13;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.Voltar_Click);
            // 
            // btnConcluir
            // 
            this.btnConcluir.Location = new System.Drawing.Point(12, 228);
            this.btnConcluir.Name = "btnConcluir";
            this.btnConcluir.Size = new System.Drawing.Size(85, 34);
            this.btnConcluir.TabIndex = 10;
            this.btnConcluir.Text = "Concluir";
            this.btnConcluir.UseVisualStyleBackColor = true;
            this.btnConcluir.Click += new System.EventHandler(this.Concluir_Click);
            // 
            // textBoxDescricao
            // 
            this.textBoxDescricao.Location = new System.Drawing.Point(93, 21);
            this.textBoxDescricao.Name = "textBoxDescricao";
            this.textBoxDescricao.Size = new System.Drawing.Size(319, 20);
            this.textBoxDescricao.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descrição:";
            // 
            // GUIInserirTurma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 274);
            this.Controls.Add(this.panel1);
            this.Name = "GUIInserirTurma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Inserir Turma";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnConcluir;
        private System.Windows.Forms.TextBox textBoxDescricao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateDataInicio;
        private System.Windows.Forms.ComboBox comboBoxEnsino;
        private System.Windows.Forms.ComboBox comboBoxTurno;
        private System.Windows.Forms.ComboBox comboBoxAno;
    }
}