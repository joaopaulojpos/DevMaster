namespace GUI
{
    partial class GUILogin
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
            this.btnLogar = new System.Windows.Forms.Button();
            this.labeLogin = new System.Windows.Forms.Label();
            this.labelSenha = new System.Windows.Forms.Label();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.textBoxSenha = new System.Windows.Forms.TextBox();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLogar
            // 
            this.btnLogar.Location = new System.Drawing.Point(99, 234);
            this.btnLogar.Name = "btnLogar";
            this.btnLogar.Size = new System.Drawing.Size(144, 35);
            this.btnLogar.TabIndex = 0;
            this.btnLogar.Text = "Logar";
            this.btnLogar.UseVisualStyleBackColor = true;
            this.btnLogar.Click += new System.EventHandler(this.buttonLogar_Click);
            // 
            // labeLogin
            // 
            this.labeLogin.AutoSize = true;
            this.labeLogin.Location = new System.Drawing.Point(11, 154);
            this.labeLogin.Name = "labeLogin";
            this.labeLogin.Size = new System.Drawing.Size(36, 13);
            this.labeLogin.TabIndex = 1;
            this.labeLogin.Text = "Login:";
            this.labeLogin.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelSenha
            // 
            this.labelSenha.AutoSize = true;
            this.labelSenha.Location = new System.Drawing.Point(6, 180);
            this.labelSenha.Name = "labelSenha";
            this.labelSenha.Size = new System.Drawing.Size(41, 13);
            this.labelSenha.TabIndex = 2;
            this.labelSenha.Text = "Senha:";
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(53, 151);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(236, 20);
            this.textBoxLogin.TabIndex = 3;
            // 
            // textBoxSenha
            // 
            this.textBoxSenha.Location = new System.Drawing.Point(53, 177);
            this.textBoxSenha.Name = "textBoxSenha";
            this.textBoxSenha.Size = new System.Drawing.Size(236, 20);
            this.textBoxSenha.TabIndex = 4;
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.Location = new System.Drawing.Point(22, 9);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelTitulo.Size = new System.Drawing.Size(258, 20);
            this.labelTitulo.TabIndex = 5;
            this.labelTitulo.Text = "Sistema Acadêmico DevMaster";
            this.labelTitulo.Click += new System.EventHandler(this.label3_Click);
            // 
            // GUILogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(301, 281);
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.textBoxSenha);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.labelSenha);
            this.Controls.Add(this.labeLogin);
            this.Controls.Add(this.btnLogar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GUILogin";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema Acadêmico";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogar;
        private System.Windows.Forms.Label labeLogin;
        private System.Windows.Forms.Label labelSenha;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.TextBox textBoxSenha;
        private System.Windows.Forms.Label labelTitulo;
    }
}

