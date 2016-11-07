namespace DevMaster
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
            this.secretáriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroDeAlunosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abonoDeFaltasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.professorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lançarFaltasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lançarNotasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coordenaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emitirBoletimToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroSérieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.secretáriaToolStripMenuItem,
            this.professorToolStripMenuItem,
            this.coordenaçãoToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(635, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // secretáriaToolStripMenuItem
            // 
            this.secretáriaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroDeAlunosToolStripMenuItem,
            this.abonoDeFaltasToolStripMenuItem});
            this.secretáriaToolStripMenuItem.Name = "secretáriaToolStripMenuItem";
            this.secretáriaToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.secretáriaToolStripMenuItem.Text = "Secretaria";
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
            // 
            // professorToolStripMenuItem
            // 
            this.professorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lançarFaltasToolStripMenuItem,
            this.lançarNotasToolStripMenuItem});
            this.professorToolStripMenuItem.Name = "professorToolStripMenuItem";
            this.professorToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.professorToolStripMenuItem.Text = "Professor";
            this.professorToolStripMenuItem.Click += new System.EventHandler(this.professorToolStripMenuItem_Click);
            // 
            // lançarFaltasToolStripMenuItem
            // 
            this.lançarFaltasToolStripMenuItem.Name = "lançarFaltasToolStripMenuItem";
            this.lançarFaltasToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.lançarFaltasToolStripMenuItem.Text = "Fazer Chamada";
            this.lançarFaltasToolStripMenuItem.Click += new System.EventHandler(this.lançarFaltasToolStripMenuItem_Click);
            // 
            // lançarNotasToolStripMenuItem
            // 
            this.lançarNotasToolStripMenuItem.Name = "lançarNotasToolStripMenuItem";
            this.lançarNotasToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.lançarNotasToolStripMenuItem.Text = "Lançar Notas";
            this.lançarNotasToolStripMenuItem.Click += new System.EventHandler(this.lançarNotasToolStripMenuItem_Click);
            // 
            // coordenaçãoToolStripMenuItem
            // 
            this.coordenaçãoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emitirBoletimToolStripMenuItem,
            this.cadastroSérieToolStripMenuItem});
            this.coordenaçãoToolStripMenuItem.Name = "coordenaçãoToolStripMenuItem";
            this.coordenaçãoToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.coordenaçãoToolStripMenuItem.Text = "Coordenação";
            // 
            // emitirBoletimToolStripMenuItem
            // 
            this.emitirBoletimToolStripMenuItem.Name = "emitirBoletimToolStripMenuItem";
            this.emitirBoletimToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.emitirBoletimToolStripMenuItem.Text = "Emitir Boletim";
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // cadastroSérieToolStripMenuItem
            // 
            this.cadastroSérieToolStripMenuItem.Name = "cadastroSérieToolStripMenuItem";
            this.cadastroSérieToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cadastroSérieToolStripMenuItem.Text = "Cadastro Série";
            this.cadastroSérieToolStripMenuItem.Click += new System.EventHandler(this.cadastroSérieToolStripMenuItem_Click);
            // 
            // GUIPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(635, 350);
            this.Controls.Add(this.menuStrip1);
            this.Name = "GUIPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem professorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lançarFaltasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lançarNotasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem secretáriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastroDeAlunosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coordenaçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emitirBoletimToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abonoDeFaltasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastroSérieToolStripMenuItem;
    }
}