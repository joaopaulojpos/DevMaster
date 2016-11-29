namespace GUI
{
    partial class GUIEnsino
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
            this.textBoxCodigo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listViewEnsinos = new System.Windows.Forms.ListView();
            this.ColumnHeaderCodigo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderSerie = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.textBoxEnsino = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.novoAlunoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxCodigo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.listViewEnsinos);
            this.panel1.Controls.Add(this.btnVoltar);
            this.panel1.Controls.Add(this.btnConsultar);
            this.panel1.Controls.Add(this.btnRemover);
            this.panel1.Controls.Add(this.btnAlterar);
            this.panel1.Controls.Add(this.textBoxEnsino);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(441, 420);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // textBoxCodigo
            // 
            this.textBoxCodigo.Location = new System.Drawing.Point(104, 68);
            this.textBoxCodigo.Name = "textBoxCodigo";
            this.textBoxCodigo.Size = new System.Drawing.Size(219, 20);
            this.textBoxCodigo.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Código:";
            // 
            // listViewEnsinos
            // 
            this.listViewEnsinos.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewEnsinos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeaderCodigo,
            this.ColumnHeaderSerie});
            this.listViewEnsinos.FullRowSelect = true;
            this.listViewEnsinos.GridLines = true;
            this.listViewEnsinos.Location = new System.Drawing.Point(12, 120);
            this.listViewEnsinos.Name = "listViewEnsinos";
            this.listViewEnsinos.Size = new System.Drawing.Size(311, 286);
            this.listViewEnsinos.TabIndex = 8;
            this.listViewEnsinos.UseCompatibleStateImageBehavior = false;
            this.listViewEnsinos.View = System.Windows.Forms.View.Details;
            this.listViewEnsinos.SelectedIndexChanged += new System.EventHandler(this.listViewEnsino_SelectedIndexChanged);
            // 
            // ColumnHeaderCodigo
            // 
            this.ColumnHeaderCodigo.Text = "Código";
            // 
            // ColumnHeaderSerie
            // 
            this.ColumnHeaderSerie.Text = "Ensino";
            this.ColumnHeaderSerie.Width = 76;
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(329, 366);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(100, 40);
            this.btnVoltar.TabIndex = 6;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltarClick);
            // 
            // btnConsultar
            // 
            this.btnConsultar.AccessibleName = "";
            this.btnConsultar.Image = global::GUI.Properties.Resources.magnify__1_;
            this.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultar.Location = new System.Drawing.Point(329, 120);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(100, 40);
            this.btnConsultar.TabIndex = 5;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultarClick);
            // 
            // btnRemover
            // 
            this.btnRemover.Location = new System.Drawing.Point(329, 212);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(100, 40);
            this.btnRemover.TabIndex = 4;
            this.btnRemover.Text = "Remover";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(329, 166);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(100, 40);
            this.btnAlterar.TabIndex = 3;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // textBoxEnsino
            // 
            this.textBoxEnsino.Location = new System.Drawing.Point(104, 94);
            this.textBoxEnsino.Name = "textBoxEnsino";
            this.textBoxEnsino.Size = new System.Drawing.Size(219, 20);
            this.textBoxEnsino.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ensino:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoAlunoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(441, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // novoAlunoToolStripMenuItem
            // 
            this.novoAlunoToolStripMenuItem.Name = "novoAlunoToolStripMenuItem";
            this.novoAlunoToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.novoAlunoToolStripMenuItem.Text = "Nova Série";
            this.novoAlunoToolStripMenuItem.Click += new System.EventHandler(this.novoAlunoToolStripMenuItem_Click);
            // 
            // GUIEnsino
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 420);
            this.Controls.Add(this.panel1);
            this.Name = "GUIEnsino";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cadastro de Série";
            this.Load += new System.EventHandler(this.GUIEnsino_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxEnsino;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem novoAlunoToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView listViewEnsinos;
        private System.Windows.Forms.ColumnHeader ColumnHeaderCodigo;
        private System.Windows.Forms.ColumnHeader ColumnHeaderSerie;
        private System.Windows.Forms.TextBox textBoxCodigo;
        private System.Windows.Forms.Label label2;
    }
}