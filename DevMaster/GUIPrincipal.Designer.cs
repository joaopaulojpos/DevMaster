namespace GUI
{
    partial class GUIPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUIPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.secretariaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroDeAlunosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abonoDeFaltasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.professorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lancarFaltasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lancarNotasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroAulaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coordenacaoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emitirBoletimToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroDisciplinaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarEnsinoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarTipoDeUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.turmaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroDisciplinaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroAlunosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroDeTurmaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarProfessorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.secretariaToolStripMenuItem,
            this.professorToolStripMenuItem,
            this.coordenacaoToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1264, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // secretariaToolStripMenuItem
            // 
            this.secretariaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroDeAlunosToolStripMenuItem,
            this.abonoDeFaltasToolStripMenuItem});
            this.secretariaToolStripMenuItem.Name = "secretariaToolStripMenuItem";
            this.secretariaToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.secretariaToolStripMenuItem.Text = "Secretaria";
            // 
            // cadastroDeAlunosToolStripMenuItem
            // 
            this.cadastroDeAlunosToolStripMenuItem.Name = "cadastroDeAlunosToolStripMenuItem";
            this.cadastroDeAlunosToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.cadastroDeAlunosToolStripMenuItem.Text = "Cadastro de Aluno";
            this.cadastroDeAlunosToolStripMenuItem.Click += new System.EventHandler(this.cadastroDeAlunosToolStripMenuItem_Click);
            // 
            // abonoDeFaltasToolStripMenuItem
            // 
            this.abonoDeFaltasToolStripMenuItem.Name = "abonoDeFaltasToolStripMenuItem";
            this.abonoDeFaltasToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.abonoDeFaltasToolStripMenuItem.Text = "Abono de Faltas";
            this.abonoDeFaltasToolStripMenuItem.Click += new System.EventHandler(this.abonoDeFaltasToolStripMenuItem_Click);
            // 
            // professorToolStripMenuItem
            // 
            this.professorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lancarFaltasToolStripMenuItem,
            this.lancarNotasToolStripMenuItem,
            this.cadastroAulaToolStripMenuItem});
            this.professorToolStripMenuItem.Name = "professorToolStripMenuItem";
            this.professorToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.professorToolStripMenuItem.Text = "Professor";
            this.professorToolStripMenuItem.Click += new System.EventHandler(this.professorToolStripMenuItem_Click);
            // 
            // lancarFaltasToolStripMenuItem
            // 
            this.lancarFaltasToolStripMenuItem.Name = "lancarFaltasToolStripMenuItem";
            this.lancarFaltasToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.lancarFaltasToolStripMenuItem.Text = "Fazer Chamada";
            this.lancarFaltasToolStripMenuItem.Click += new System.EventHandler(this.lançarFaltasToolStripMenuItem_Click);
            // 
            // lancarNotasToolStripMenuItem
            // 
            this.lancarNotasToolStripMenuItem.Name = "lancarNotasToolStripMenuItem";
            this.lancarNotasToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.lancarNotasToolStripMenuItem.Text = "Lançar Notas";
            this.lancarNotasToolStripMenuItem.Click += new System.EventHandler(this.lançarNotasToolStripMenuItem_Click);
            // 
            // cadastroAulaToolStripMenuItem
            // 
            this.cadastroAulaToolStripMenuItem.Name = "cadastroAulaToolStripMenuItem";
            this.cadastroAulaToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.cadastroAulaToolStripMenuItem.Text = "Cadastro Aula";
            this.cadastroAulaToolStripMenuItem.Click += new System.EventHandler(this.cadastroAulaToolStripMenuItem_Click);
            // 
            // coordenacaoToolStripMenuItem
            // 
            this.coordenacaoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emitirBoletimToolStripMenuItem,
            this.cadastroDisciplinaToolStripMenuItem,
            this.cadastroUsuarioToolStripMenuItem,
            this.consultarEnsinoToolStripMenuItem,
            this.consultarTipoDeUsuarioToolStripMenuItem,
            this.turmaToolStripMenuItem});
            this.coordenacaoToolStripMenuItem.Name = "coordenacaoToolStripMenuItem";
            this.coordenacaoToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.coordenacaoToolStripMenuItem.Text = "Coordenação";
            this.coordenacaoToolStripMenuItem.Click += new System.EventHandler(this.coordenaçãoToolStripMenuItem_Click);
            // 
            // emitirBoletimToolStripMenuItem
            // 
            this.emitirBoletimToolStripMenuItem.Name = "emitirBoletimToolStripMenuItem";
            this.emitirBoletimToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.emitirBoletimToolStripMenuItem.Text = "Emitir Boletim";
            // 
            // cadastroDisciplinaToolStripMenuItem
            // 
            this.cadastroDisciplinaToolStripMenuItem.Name = "cadastroDisciplinaToolStripMenuItem";
            this.cadastroDisciplinaToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.cadastroDisciplinaToolStripMenuItem.Text = "Cadastro de Disciplina";
            this.cadastroDisciplinaToolStripMenuItem.Click += new System.EventHandler(this.cadastroDisciplinaToolStripMenuItem_Click);
            // 
            // cadastroUsuarioToolStripMenuItem
            // 
            this.cadastroUsuarioToolStripMenuItem.Name = "cadastroUsuarioToolStripMenuItem";
            this.cadastroUsuarioToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.cadastroUsuarioToolStripMenuItem.Text = "Cadastro de Usuário";
            this.cadastroUsuarioToolStripMenuItem.Click += new System.EventHandler(this.cadastroUsuárioToolStripMenuItem_Click);
            // 
            // consultarEnsinoToolStripMenuItem
            // 
            this.consultarEnsinoToolStripMenuItem.Name = "consultarEnsinoToolStripMenuItem";
            this.consultarEnsinoToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.consultarEnsinoToolStripMenuItem.Text = "Consultar Ensino";
            this.consultarEnsinoToolStripMenuItem.Click += new System.EventHandler(this.consultarEnsinoToolStripMenuItem_Click);
            // 
            // consultarTipoDeUsuarioToolStripMenuItem
            // 
            this.consultarTipoDeUsuarioToolStripMenuItem.Name = "consultarTipoDeUsuarioToolStripMenuItem";
            this.consultarTipoDeUsuarioToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.consultarTipoDeUsuarioToolStripMenuItem.Text = "Consultar Tipo de Usuário";
            this.consultarTipoDeUsuarioToolStripMenuItem.Click += new System.EventHandler(this.consultarTipoDeUsuarioToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // turmaToolStripMenuItem
            // 
            this.turmaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroDeTurmaToolStripMenuItem,
            this.cadastroDisciplinaToolStripMenuItem1,
            this.cadastroAlunosToolStripMenuItem,
            this.registrarProfessorToolStripMenuItem});
            this.turmaToolStripMenuItem.Name = "turmaToolStripMenuItem";
            this.turmaToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.turmaToolStripMenuItem.Text = "Turma";
            // 
            // cadastroDisciplinaToolStripMenuItem1
            // 
            this.cadastroDisciplinaToolStripMenuItem1.Name = "cadastroDisciplinaToolStripMenuItem1";
            this.cadastroDisciplinaToolStripMenuItem1.Size = new System.Drawing.Size(175, 22);
            this.cadastroDisciplinaToolStripMenuItem1.Text = "Registrar Disciplina";
            // 
            // cadastroAlunosToolStripMenuItem
            // 
            this.cadastroAlunosToolStripMenuItem.Name = "cadastroAlunosToolStripMenuItem";
            this.cadastroAlunosToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.cadastroAlunosToolStripMenuItem.Text = "Registrar Aluno";
            // 
            // cadastroDeTurmaToolStripMenuItem
            // 
            this.cadastroDeTurmaToolStripMenuItem.Name = "cadastroDeTurmaToolStripMenuItem";
            this.cadastroDeTurmaToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.cadastroDeTurmaToolStripMenuItem.Text = "Cadastro de Turma";
            // 
            // registrarProfessorToolStripMenuItem
            // 
            this.registrarProfessorToolStripMenuItem.Name = "registrarProfessorToolStripMenuItem";
            this.registrarProfessorToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.registrarProfessorToolStripMenuItem.Text = "Registrar Professor";
            // 
            // GUIPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1264, 682);
            this.Controls.Add(this.menuStrip1);
            this.Name = "GUIPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Escola DevMaster";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem professorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lancarFaltasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lancarNotasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem secretariaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastroDeAlunosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coordenacaoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emitirBoletimToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abonoDeFaltasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastroDisciplinaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastroAulaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastroUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarEnsinoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarTipoDeUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem turmaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastroDeTurmaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastroDisciplinaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cadastroAlunosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarProfessorToolStripMenuItem;
    }
}