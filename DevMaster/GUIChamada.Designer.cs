namespace GUI
{
    partial class GUIChamada
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnFinalizarChamada = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.checkedListBoxAlunos = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.dateDia = new System.Windows.Forms.DateTimePicker();
            this.comboBoxTurma = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxAula = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxDisciplina = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Turma:";
            // 
            // btnFinalizarChamada
            // 
            this.btnFinalizarChamada.Location = new System.Drawing.Point(336, 161);
            this.btnFinalizarChamada.Name = "btnFinalizarChamada";
            this.btnFinalizarChamada.Size = new System.Drawing.Size(97, 34);
            this.btnFinalizarChamada.TabIndex = 7;
            this.btnFinalizarChamada.Text = "Finalizar Chamada";
            this.btnFinalizarChamada.UseVisualStyleBackColor = true;
            this.btnFinalizarChamada.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "ALUNOS";
            // 
            // checkedListBoxAlunos
            // 
            this.checkedListBoxAlunos.BackColor = System.Drawing.SystemColors.Control;
            this.checkedListBoxAlunos.CheckOnClick = true;
            this.checkedListBoxAlunos.FormattingEnabled = true;
            this.checkedListBoxAlunos.Items.AddRange(new object[] {
            ""});
            this.checkedListBoxAlunos.Location = new System.Drawing.Point(13, 161);
            this.checkedListBoxAlunos.Name = "checkedListBoxAlunos";
            this.checkedListBoxAlunos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkedListBoxAlunos.Size = new System.Drawing.Size(317, 364);
            this.checkedListBoxAlunos.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Dia:";
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(336, 495);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(97, 34);
            this.btnVoltar.TabIndex = 7;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btn_Voltar_Click);
            // 
            // dateDia
            // 
            this.dateDia.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDia.Location = new System.Drawing.Point(56, 41);
            this.dateDia.Name = "dateDia";
            this.dateDia.Size = new System.Drawing.Size(200, 20);
            this.dateDia.TabIndex = 8;
            this.dateDia.ValueChanged += new System.EventHandler(this.dateDia_ValueChanged);
            // 
            // comboBoxTurma
            // 
            this.comboBoxTurma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTurma.FormattingEnabled = true;
            this.comboBoxTurma.Location = new System.Drawing.Point(56, 10);
            this.comboBoxTurma.Name = "comboBoxTurma";
            this.comboBoxTurma.Size = new System.Drawing.Size(200, 21);
            this.comboBoxTurma.TabIndex = 1;
            this.comboBoxTurma.SelectedIndexChanged += new System.EventHandler(this.birl1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Aula:";
            // 
            // comboBoxAula
            // 
            this.comboBoxAula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAula.FormattingEnabled = true;
            this.comboBoxAula.Location = new System.Drawing.Point(56, 73);
            this.comboBoxAula.Name = "comboBoxAula";
            this.comboBoxAula.Size = new System.Drawing.Size(200, 21);
            this.comboBoxAula.TabIndex = 10;
            this.comboBoxAula.SelectedIndexChanged += new System.EventHandler(this.comboBoxAula_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.comboBoxDisciplina);
            this.panel1.Controls.Add(this.checkedListBoxAlunos);
            this.panel1.Controls.Add(this.comboBoxAula);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnVoltar);
            this.panel1.Controls.Add(this.btnFinalizarChamada);
            this.panel1.Controls.Add(this.dateDia);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBoxTurma);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(452, 547);
            this.panel1.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-5, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Disciplina:";
            // 
            // comboBoxDisciplina
            // 
            this.comboBoxDisciplina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDisciplina.FormattingEnabled = true;
            this.comboBoxDisciplina.Location = new System.Drawing.Point(56, 100);
            this.comboBoxDisciplina.Name = "comboBoxDisciplina";
            this.comboBoxDisciplina.Size = new System.Drawing.Size(200, 21);
            this.comboBoxDisciplina.TabIndex = 11;
            this.comboBoxDisciplina.SelectedIndexChanged += new System.EventHandler(this.comboBoxDisciplina_SelectedIndexChanged_1);
            // 
            // GUIChamada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 550);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GUIChamada";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chamada";
            this.Load += new System.EventHandler(this.GUIChamada_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox checkedListBoxAlunos;
        private System.Windows.Forms.Button btnFinalizarChamada;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.DateTimePicker dateDia;
        private System.Windows.Forms.ComboBox comboBoxTurma;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxAula;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxDisciplina;
        private System.Windows.Forms.Label label5;
    }
}