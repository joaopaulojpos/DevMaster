namespace GUI
{
    partial class GUITurma
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
            this.textBoxDescricao = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listViewTurma = new System.Windows.Forms.ListView();
            this.columnHeaderCodigo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDescricaoTurma = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTurno = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderAno = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDataInicio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderEnsino = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.textBoxCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.novaTurmaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonVincular = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonVincular);
            this.panel1.Controls.Add(this.textBoxDescricao);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.listViewTurma);
            this.panel1.Controls.Add(this.btnVoltar);
            this.panel1.Controls.Add(this.btnConsultar);
            this.panel1.Controls.Add(this.btnRemover);
            this.panel1.Controls.Add(this.btnAlterar);
            this.panel1.Controls.Add(this.textBoxCodigo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(585, 402);
            this.panel1.TabIndex = 4;
            // 
            // textBoxDescricao
            // 
            this.textBoxDescricao.Location = new System.Drawing.Point(61, 65);
            this.textBoxDescricao.Name = "textBoxDescricao";
            this.textBoxDescricao.Size = new System.Drawing.Size(146, 20);
            this.textBoxDescricao.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Turma:";
            // 
            // listViewTurma
            // 
            this.listViewTurma.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderCodigo,
            this.columnHeaderDescricaoTurma,
            this.columnHeaderTurno,
            this.columnHeaderAno,
            this.columnHeaderDataInicio,
            this.columnHeaderEnsino});
            this.listViewTurma.FullRowSelect = true;
            this.listViewTurma.GridLines = true;
            this.listViewTurma.Location = new System.Drawing.Point(12, 133);
            this.listViewTurma.MultiSelect = false;
            this.listViewTurma.Name = "listViewTurma";
            this.listViewTurma.Size = new System.Drawing.Size(475, 257);
            this.listViewTurma.TabIndex = 8;
            this.listViewTurma.UseCompatibleStateImageBehavior = false;
            this.listViewTurma.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderCodigo
            // 
            this.columnHeaderCodigo.Text = "Código";
            // 
            // columnHeaderDescricaoTurma
            // 
            this.columnHeaderDescricaoTurma.Text = "Descrição Turma";
            this.columnHeaderDescricaoTurma.Width = 101;
            // 
            // columnHeaderTurno
            // 
            this.columnHeaderTurno.Text = "Turno";
            // 
            // columnHeaderAno
            // 
            this.columnHeaderAno.Text = "Ano";
            // 
            // columnHeaderDataInicio
            // 
            this.columnHeaderDataInicio.Text = "Data Início";
            this.columnHeaderDataInicio.Width = 73;
            // 
            // columnHeaderEnsino
            // 
            this.columnHeaderEnsino.Text = "Ensino";
            this.columnHeaderEnsino.Width = 90;
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(493, 359);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(79, 31);
            this.btnVoltar.TabIndex = 6;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Image = global::GUI.Properties.Resources.magnify__1_;
            this.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultar.Location = new System.Drawing.Point(12, 96);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(79, 31);
            this.btnConsultar.TabIndex = 5;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.Image = global::GUI.Properties.Resources.delete__1_;
            this.btnRemover.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemover.Location = new System.Drawing.Point(493, 170);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(79, 31);
            this.btnRemover.TabIndex = 4;
            this.btnRemover.Text = "Remover";
            this.btnRemover.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(493, 133);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(79, 31);
            this.btnAlterar.TabIndex = 3;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // textBoxCodigo
            // 
            this.textBoxCodigo.Location = new System.Drawing.Point(61, 39);
            this.textBoxCodigo.Name = "textBoxCodigo";
            this.textBoxCodigo.Size = new System.Drawing.Size(146, 20);
            this.textBoxCodigo.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Código:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novaTurmaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(585, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // novaTurmaToolStripMenuItem
            // 
            this.novaTurmaToolStripMenuItem.Image = global::GUI.Properties.Resources.plus_box__1_;
            this.novaTurmaToolStripMenuItem.Name = "novaTurmaToolStripMenuItem";
            this.novaTurmaToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.novaTurmaToolStripMenuItem.Text = "Nova Turma";
            this.novaTurmaToolStripMenuItem.Click += new System.EventHandler(this.novaTurmaToolStripMenuItem_Click);
            // 
            // buttonVincular
            // 
            this.buttonVincular.Location = new System.Drawing.Point(493, 207);
            this.buttonVincular.Name = "buttonVincular";
            this.buttonVincular.Size = new System.Drawing.Size(79, 30);
            this.buttonVincular.TabIndex = 11;
            this.buttonVincular.Text = "Disciplinas";
            this.buttonVincular.UseVisualStyleBackColor = true;
            this.buttonVincular.Click += new System.EventHandler(this.buttonVincular_Click);
            // 
            // GUITurma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 402);
            this.Controls.Add(this.panel1);
            this.Name = "GUITurma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cadastro de Turma";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.TextBox textBoxCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem novaTurmaToolStripMenuItem;
        private System.Windows.Forms.ListView listViewTurma;
        private System.Windows.Forms.ColumnHeader columnHeaderCodigo;
        private System.Windows.Forms.ColumnHeader columnHeaderDescricaoTurma;
        private System.Windows.Forms.ColumnHeader columnHeaderTurno;
        private System.Windows.Forms.ColumnHeader columnHeaderAno;
        private System.Windows.Forms.ColumnHeader columnHeaderDataInicio;
        private System.Windows.Forms.ColumnHeader columnHeaderEnsino;
        private System.Windows.Forms.TextBox textBoxDescricao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonVincular;
    }
}