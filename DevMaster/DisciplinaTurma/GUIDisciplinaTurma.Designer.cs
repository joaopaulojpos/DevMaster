namespace GUI.DisciplinaTurma
{
    partial class GUIDisciplinaTurma
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
            this.buttonConfirmar = new System.Windows.Forms.Button();
            this.checkedListBoxDisciplinas = new System.Windows.Forms.CheckedListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkedListBoxDisciplinas);
            this.panel1.Controls.Add(this.buttonConfirmar);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 373);
            this.panel1.TabIndex = 0;
            // 
            // buttonConfirmar
            // 
            this.buttonConfirmar.Location = new System.Drawing.Point(162, 340);
            this.buttonConfirmar.Name = "buttonConfirmar";
            this.buttonConfirmar.Size = new System.Drawing.Size(75, 23);
            this.buttonConfirmar.TabIndex = 4;
            this.buttonConfirmar.Text = "Confirmar";
            this.buttonConfirmar.UseVisualStyleBackColor = true;
            this.buttonConfirmar.Click += new System.EventHandler(this.buttonConfirmar_Click);
            // 
            // checkedListBoxDisciplinas
            // 
            this.checkedListBoxDisciplinas.CheckOnClick = true;
            this.checkedListBoxDisciplinas.FormattingEnabled = true;
            this.checkedListBoxDisciplinas.Location = new System.Drawing.Point(12, 12);
            this.checkedListBoxDisciplinas.Name = "checkedListBoxDisciplinas";
            this.checkedListBoxDisciplinas.Size = new System.Drawing.Size(225, 304);
            this.checkedListBoxDisciplinas.TabIndex = 5;
            // 
            // GUIDisciplinaTurma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 375);
            this.Controls.Add(this.panel1);
            this.Name = "GUIDisciplinaTurma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vincular disciplinas à turma";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonConfirmar;
        private System.Windows.Forms.CheckedListBox checkedListBoxDisciplinas;
    }
}