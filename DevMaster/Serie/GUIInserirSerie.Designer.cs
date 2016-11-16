namespace GUI
{
    partial class GUIInserirSerie
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
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnInserir = new System.Windows.Forms.Button();
            this.textBoxDescricaoSerie = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btnInserir);
            this.panel1.Controls.Add(this.textBoxDescricaoSerie);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(417, 149);
            this.panel1.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(132, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(156, 24);
            this.label7.TabIndex = 14;
            this.label7.Text = "INSERIR SÉRIE";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(320, 103);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 34);
            this.button2.TabIndex = 13;
            this.button2.Text = "Voltar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnVoltarClick);
            // 
            // btnInserir
            // 
            this.btnInserir.Location = new System.Drawing.Point(12, 103);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(85, 34);
            this.btnInserir.TabIndex = 10;
            this.btnInserir.Text = "Concluir";
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserirClick);
            // 
            // textBoxDescricaoSerie
            // 
            this.textBoxDescricaoSerie.Location = new System.Drawing.Point(86, 47);
            this.textBoxDescricaoSerie.Name = "textBoxDescricaoSerie";
            this.textBoxDescricaoSerie.Size = new System.Drawing.Size(319, 20);
            this.textBoxDescricaoSerie.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descrição:";
            // 
            // GUIInserirSerie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 149);
            this.Controls.Add(this.panel1);
            this.Name = "GUIInserirSerie";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GUIInserirSerie";
            this.Load += new System.EventHandler(this.GUIInserirSerie_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxDescricaoSerie;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.Button button2;
    }
}