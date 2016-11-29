namespace GUI
{
    partial class GUIDisciplina
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
            this.label1 = new System.Windows.Forms.Label();
            this.listViewDisciplinas = new System.Windows.Forms.ListView();
            this.columnHeaderCodDisc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.textBoxCodigo = new System.Windows.Forms.TextBox();
            this.labelCodigo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxDescricao);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.listViewDisciplinas);
            this.panel1.Controls.Add(this.btnVoltar);
            this.panel1.Controls.Add(this.btnConsultar);
            this.panel1.Controls.Add(this.textBoxCodigo);
            this.panel1.Controls.Add(this.labelCodigo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(390, 334);
            this.panel1.TabIndex = 4;
            // 
            // textBoxDescricao
            // 
            this.textBoxDescricao.Location = new System.Drawing.Point(74, 65);
            this.textBoxDescricao.Name = "textBoxDescricao";
            this.textBoxDescricao.Size = new System.Drawing.Size(200, 20);
            this.textBoxDescricao.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Disciplina:";
            // 
            // listViewDisciplinas
            // 
            this.listViewDisciplinas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderCodDisc,
            this.columnHeaderDesc});
            this.listViewDisciplinas.FullRowSelect = true;
            this.listViewDisciplinas.Location = new System.Drawing.Point(15, 91);
            this.listViewDisciplinas.Name = "listViewDisciplinas";
            this.listViewDisciplinas.Size = new System.Drawing.Size(259, 233);
            this.listViewDisciplinas.TabIndex = 8;
            this.listViewDisciplinas.UseCompatibleStateImageBehavior = false;
            this.listViewDisciplinas.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderCodDisc
            // 
            this.columnHeaderCodDisc.Text = "Código";
            // 
            // columnHeaderDesc
            // 
            this.columnHeaderDesc.Text = "Disciplina";
            this.columnHeaderDesc.Width = 195;
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(280, 284);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(100, 40);
            this.btnVoltar.TabIndex = 6;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Image = global::GUI.Properties.Resources.magnify__1_;
            this.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultar.Location = new System.Drawing.Point(280, 91);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(100, 40);
            this.btnConsultar.TabIndex = 5;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // textBoxCodigo
            // 
            this.textBoxCodigo.Location = new System.Drawing.Point(74, 39);
            this.textBoxCodigo.Name = "textBoxCodigo";
            this.textBoxCodigo.Size = new System.Drawing.Size(200, 20);
            this.textBoxCodigo.TabIndex = 2;
            // 
            // labelCodigo
            // 
            this.labelCodigo.AutoSize = true;
            this.labelCodigo.Location = new System.Drawing.Point(12, 42);
            this.labelCodigo.Name = "labelCodigo";
            this.labelCodigo.Size = new System.Drawing.Size(43, 13);
            this.labelCodigo.TabIndex = 1;
            this.labelCodigo.Text = "Código:";
            // 
            // GUIDisciplina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 334);
            this.Controls.Add(this.panel1);
            this.Name = "GUIDisciplina";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Consultar Disciplinas";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.TextBox textBoxCodigo;
        private System.Windows.Forms.Label labelCodigo;
        private System.Windows.Forms.ListView listViewDisciplinas;
        private System.Windows.Forms.ColumnHeader columnHeaderCodDisc;
        private System.Windows.Forms.ColumnHeader columnHeaderDesc;
        private System.Windows.Forms.TextBox textBoxDescricao;
        private System.Windows.Forms.Label label1;
    }
}