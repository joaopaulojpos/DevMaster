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
            this.textBoxCodigo = new System.Windows.Forms.TextBox();
            this.labelCodigo = new System.Windows.Forms.Label();
            this.listViewTipoUsuarios = new System.Windows.Forms.ListView();
            this.columnHeaderCodigo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTipoUsuario = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.textBoxTipo = new System.Windows.Forms.TextBox();
            this.labelTipo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxCodigo);
            this.panel1.Controls.Add(this.labelCodigo);
            this.panel1.Controls.Add(this.listViewTipoUsuarios);
            this.panel1.Controls.Add(this.btnVoltar);
            this.panel1.Controls.Add(this.btnConsultar);
            this.panel1.Controls.Add(this.textBoxTipo);
            this.panel1.Controls.Add(this.labelTipo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(383, 301);
            this.panel1.TabIndex = 4;
            // 
            // textBoxCodigo
            // 
            this.textBoxCodigo.Location = new System.Drawing.Point(105, 17);
            this.textBoxCodigo.Name = "textBoxCodigo";
            this.textBoxCodigo.Size = new System.Drawing.Size(266, 20);
            this.textBoxCodigo.TabIndex = 10;
            // 
            // labelCodigo
            // 
            this.labelCodigo.AutoSize = true;
            this.labelCodigo.Location = new System.Drawing.Point(14, 20);
            this.labelCodigo.Name = "labelCodigo";
            this.labelCodigo.Size = new System.Drawing.Size(43, 13);
            this.labelCodigo.TabIndex = 9;
            this.labelCodigo.Text = "Código:";
            // 
            // listViewTipoUsuarios
            // 
            this.listViewTipoUsuarios.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderCodigo,
            this.columnHeaderTipoUsuario});
            this.listViewTipoUsuarios.FullRowSelect = true;
            this.listViewTipoUsuarios.Location = new System.Drawing.Point(17, 87);
            this.listViewTipoUsuarios.Name = "listViewTipoUsuarios";
            this.listViewTipoUsuarios.Size = new System.Drawing.Size(250, 198);
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
            this.columnHeaderTipoUsuario.Width = 167;
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(273, 245);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(100, 40);
            this.btnVoltar.TabIndex = 6;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(273, 87);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(100, 40);
            this.btnConsultar.TabIndex = 5;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // textBoxTipo
            // 
            this.textBoxTipo.Location = new System.Drawing.Point(105, 43);
            this.textBoxTipo.Name = "textBoxTipo";
            this.textBoxTipo.Size = new System.Drawing.Size(266, 20);
            this.textBoxTipo.TabIndex = 2;
            // 
            // labelTipo
            // 
            this.labelTipo.AutoSize = true;
            this.labelTipo.Location = new System.Drawing.Point(14, 46);
            this.labelTipo.Name = "labelTipo";
            this.labelTipo.Size = new System.Drawing.Size(85, 13);
            this.labelTipo.TabIndex = 1;
            this.labelTipo.Text = "Tipo de Usuário:";
            // 
            // GUITipoUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 301);
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
        private System.Windows.Forms.TextBox textBoxTipo;
        private System.Windows.Forms.Label labelTipo;
        private System.Windows.Forms.ListView listViewTipoUsuarios;
        private System.Windows.Forms.ColumnHeader columnHeaderCodigo;
        private System.Windows.Forms.ColumnHeader columnHeaderTipoUsuario;
        private System.Windows.Forms.TextBox textBoxCodigo;
        private System.Windows.Forms.Label labelCodigo;
    }
}