namespace GUI
{
    partial class GUIAlterarTurma
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
            this.panel1.Size = new System.Drawing.Size(455, 281);
            this.panel1.TabIndex = 6;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // comboBoxAno
            // 
            this.comboBoxAno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAno.FormattingEnabled = true;
            this.comboBoxAno.Location = new System.Drawing.Point(93, 111);
            this.comboBoxAno.Name = "comboBoxAno";
            this.comboBoxAno.Size = new System.Drawing.Size(132, 21);
            this.comboBoxAno.TabIndex = 22;
            // 
            // dateDataInicio
            // 
            this.dateDataInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDataInicio.Location = new System.Drawing.Point(93, 178);
            this.dateDataInicio.Name = "dateDataInicio";
            this.dateDataInicio.Size = new System.Drawing.Size(132, 20);
            this.dateDataInicio.TabIndex = 21;
            // 
            // comboBoxEnsino
            // 
            this.comboBoxEnsino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEnsino.FormattingEnabled = true;
            this.comboBoxEnsino.Location = new System.Drawing.Point(93, 84);
            this.comboBoxEnsino.Name = "comboBoxEnsino";
            this.comboBoxEnsino.Size = new System.Drawing.Size(132, 21);
            this.comboBoxEnsino.TabIndex = 20;
            this.comboBoxEnsino.SelectedIndexChanged += new System.EventHandler(this.comboBoxEnsino_SelectedIndexChanged);
            // 
            // comboBoxTurno
            // 
            this.comboBoxTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTurno.FormattingEnabled = true;
            this.comboBoxTurno.Location = new System.Drawing.Point(93, 141);
            this.comboBoxTurno.Name = "comboBoxTurno";
            this.comboBoxTurno.Size = new System.Drawing.Size(132, 21);
            this.comboBoxTurno.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Ensino:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Ano:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Turno:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Data de Início:";
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(358, 235);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(85, 34);
            this.btnVoltar.TabIndex = 13;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click_1);
            // 
            // btnConcluir
            // 
            this.btnConcluir.Location = new System.Drawing.Point(12, 235);
            this.btnConcluir.Name = "btnConcluir";
            this.btnConcluir.Size = new System.Drawing.Size(85, 34);
            this.btnConcluir.TabIndex = 10;
            this.btnConcluir.Text = "Concluir";
            this.btnConcluir.UseVisualStyleBackColor = true;
            this.btnConcluir.Click += new System.EventHandler(this.btnConcluir_Click);
            // 
            // textBoxDescricao
            // 
            this.textBoxDescricao.Location = new System.Drawing.Point(93, 47);
            this.textBoxDescricao.Name = "textBoxDescricao";
            this.textBoxDescricao.Size = new System.Drawing.Size(319, 20);
            this.textBoxDescricao.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descrição:";
            // 
            // GUIAlterarTurma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 281);
            this.Controls.Add(this.panel1);
            this.Name = "GUIAlterarTurma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GUIAlterarTurma";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dateDataInicio;
        private System.Windows.Forms.ComboBox comboBoxEnsino;
        private System.Windows.Forms.ComboBox comboBoxTurno;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDescricao;
        private System.Windows.Forms.Button btnConcluir;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxAno;
    }
}