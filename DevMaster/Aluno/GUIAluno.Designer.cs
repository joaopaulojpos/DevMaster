namespace DevMaster
{
    partial class GUIAluno
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnPesquisarSerie = new System.Windows.Forms.Button();
            this.btnInserirAluno = new System.Windows.Forms.Button();
            this.btnListarAluno = new System.Windows.Forms.Button();
            this.btnAlterarAluno = new System.Windows.Forms.Button();
            this.btnRemoverAluno = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnPesquisarSerie);
            this.panel1.Controls.Add(this.btnInserirAluno);
            this.panel1.Controls.Add(this.btnListarAluno);
            this.panel1.Controls.Add(this.btnAlterarAluno);
            this.panel1.Controls.Add(this.btnRemoverAluno);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 356);
            this.panel1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Escolha a opção desejada:";
            // 
            // btnPesquisarSerie
            // 
            this.btnPesquisarSerie.Location = new System.Drawing.Point(21, 299);
            this.btnPesquisarSerie.Name = "btnPesquisarSerie";
            this.btnPesquisarSerie.Size = new System.Drawing.Size(225, 46);
            this.btnPesquisarSerie.TabIndex = 4;
            this.btnPesquisarSerie.Text = "Pesquisar Séries";
            this.btnPesquisarSerie.UseVisualStyleBackColor = true;
            this.btnPesquisarSerie.Click += new System.EventHandler(this.btnPesquisarSerie_Click);
            // 
            // btnInserirAluno
            // 
            this.btnInserirAluno.Location = new System.Drawing.Point(21, 33);
            this.btnInserirAluno.Name = "btnInserirAluno";
            this.btnInserirAluno.Size = new System.Drawing.Size(225, 46);
            this.btnInserirAluno.TabIndex = 0;
            this.btnInserirAluno.Text = "Inserir Aluno";
            this.btnInserirAluno.UseVisualStyleBackColor = true;
            this.btnInserirAluno.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnListarAluno
            // 
            this.btnListarAluno.Location = new System.Drawing.Point(21, 233);
            this.btnListarAluno.Name = "btnListarAluno";
            this.btnListarAluno.Size = new System.Drawing.Size(225, 46);
            this.btnListarAluno.TabIndex = 3;
            this.btnListarAluno.Text = "Listar Aluno";
            this.btnListarAluno.UseVisualStyleBackColor = true;
            this.btnListarAluno.Click += new System.EventHandler(this.btnListarAluno_Click);
            // 
            // btnAlterarAluno
            // 
            this.btnAlterarAluno.Location = new System.Drawing.Point(21, 99);
            this.btnAlterarAluno.Name = "btnAlterarAluno";
            this.btnAlterarAluno.Size = new System.Drawing.Size(225, 46);
            this.btnAlterarAluno.TabIndex = 1;
            this.btnAlterarAluno.Text = "Alterar Aluno";
            this.btnAlterarAluno.UseVisualStyleBackColor = true;
            this.btnAlterarAluno.Click += new System.EventHandler(this.btnAlterarAluno_Click);
            // 
            // btnRemoverAluno
            // 
            this.btnRemoverAluno.Location = new System.Drawing.Point(21, 168);
            this.btnRemoverAluno.Name = "btnRemoverAluno";
            this.btnRemoverAluno.Size = new System.Drawing.Size(225, 46);
            this.btnRemoverAluno.TabIndex = 2;
            this.btnRemoverAluno.Text = "Remover Aluno";
            this.btnRemoverAluno.UseVisualStyleBackColor = true;
            this.btnRemoverAluno.Click += new System.EventHandler(this.btnRemoverAluno_Click);
            // 
            // GUIAluno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 356);
            this.Controls.Add(this.panel1);
            this.Name = "GUIAluno";
            this.Text = "GUIAluno";
            this.Load += new System.EventHandler(this.GUIAluno_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPesquisarSerie;
        private System.Windows.Forms.Button btnInserirAluno;
        private System.Windows.Forms.Button btnListarAluno;
        private System.Windows.Forms.Button btnAlterarAluno;
        private System.Windows.Forms.Button btnRemoverAluno;
    }
}