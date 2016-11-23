namespace GUI
{
    partial class GUITipoUsuario
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
            this.listViewTipoUsuarios = new System.Windows.Forms.ListView();
            this.columnHeaderCodigo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTipoUsuario = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.textBoxFiltro = new System.Windows.Forms.TextBox();
            this.labelFiltro = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listViewTipoUsuarios);
            this.panel1.Controls.Add(this.btnVoltar);
            this.panel1.Controls.Add(this.btnConsultar);
            this.panel1.Controls.Add(this.textBoxFiltro);
            this.panel1.Controls.Add(this.labelFiltro);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(357, 327);
            this.panel1.TabIndex = 4;
            // 
            // listViewTipoUsuarios
            // 
            this.listViewTipoUsuarios.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderCodigo,
            this.columnHeaderTipoUsuario});
            this.listViewTipoUsuarios.FullRowSelect = true;
            this.listViewTipoUsuarios.Location = new System.Drawing.Point(15, 74);
            this.listViewTipoUsuarios.Name = "listViewTipoUsuarios";
            this.listViewTipoUsuarios.Size = new System.Drawing.Size(327, 198);
            this.listViewTipoUsuarios.TabIndex = 8;
            this.listViewTipoUsuarios.UseCompatibleStateImageBehavior = false;
            this.listViewTipoUsuarios.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderCodigo
            // 
            this.columnHeaderCodigo.Text = "Código";
            this.columnHeaderCodigo.Width = 73;
            // 
            // columnHeaderTipoUsuario
            // 
            this.columnHeaderTipoUsuario.Text = "Tipo";
            this.columnHeaderTipoUsuario.Width = 245;
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(15, 278);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(327, 40);
            this.btnVoltar.TabIndex = 6;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(242, 28);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(100, 40);
            this.btnConsultar.TabIndex = 5;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // textBoxFiltro
            // 
            this.textBoxFiltro.Location = new System.Drawing.Point(74, 39);
            this.textBoxFiltro.Name = "textBoxFiltro";
            this.textBoxFiltro.Size = new System.Drawing.Size(162, 20);
            this.textBoxFiltro.TabIndex = 2;
            // 
            // labelFiltro
            // 
            this.labelFiltro.AutoSize = true;
            this.labelFiltro.Location = new System.Drawing.Point(12, 42);
            this.labelFiltro.Name = "labelFiltro";
            this.labelFiltro.Size = new System.Drawing.Size(56, 13);
            this.labelFiltro.TabIndex = 1;
            this.labelFiltro.Text = "Pesquisar:";
            // 
            // GUITipoUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 327);
            this.Controls.Add(this.panel1);
            this.Name = "GUITipoUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GUITipoUsuari";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.TextBox textBoxFiltro;
        private System.Windows.Forms.Label labelFiltro;
        private System.Windows.Forms.ListView listViewTipoUsuarios;
        private System.Windows.Forms.ColumnHeader columnHeaderCodigo;
        private System.Windows.Forms.ColumnHeader columnHeaderTipoUsuario;
    }
}