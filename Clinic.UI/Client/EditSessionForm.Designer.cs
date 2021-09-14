using System.ComponentModel;

namespace Clinic.UI
{
    partial class EditSessionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.dtp_SessionDate = new System.Windows.Forms.DateTimePicker();
            this.cb_SessionHours = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_SaveSessionChanges = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtp_SessionDate
            // 
            this.dtp_SessionDate.Location = new System.Drawing.Point(293, 213);
            this.dtp_SessionDate.Name = "dtp_SessionDate";
            this.dtp_SessionDate.Size = new System.Drawing.Size(297, 20);
            this.dtp_SessionDate.TabIndex = 0;
            // 
            // cb_SessionHours
            // 
            this.cb_SessionHours.FormattingEnabled = true;
            this.cb_SessionHours.Location = new System.Drawing.Point(293, 264);
            this.cb_SessionHours.Name = "cb_SessionHours";
            this.cb_SessionHours.Size = new System.Drawing.Size(297, 21);
            this.cb_SessionHours.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(293, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "Escolha a data e hora para os quais quer mudar a sessão";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(285, 302);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(198, 79);
            this.button1.TabIndex = 3;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btn_SaveSessionChanges
            // 
            this.btn_SaveSessionChanges.Location = new System.Drawing.Point(293, 328);
            this.btn_SaveSessionChanges.Name = "btn_SaveSessionChanges";
            this.btn_SaveSessionChanges.Size = new System.Drawing.Size(297, 71);
            this.btn_SaveSessionChanges.TabIndex = 3;
            this.btn_SaveSessionChanges.Text = "Guardar";
            this.btn_SaveSessionChanges.UseVisualStyleBackColor = true;
            this.btn_SaveSessionChanges.Click += new System.EventHandler(this.btn_SaveSessionChanges_Click);
            // 
            // EditSessionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(908, 561);
            this.Controls.Add(this.btn_SaveSessionChanges);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_SessionHours);
            this.Controls.Add(this.dtp_SessionDate);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "EditSessionForm";
            this.Text = "Mudar hora ou dia da sessao";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btn_SaveSessionChanges;

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.DateTimePicker dtp_SessionDate;
        private System.Windows.Forms.ComboBox cb_SessionHours;
        private System.Windows.Forms.Label label1;

        #endregion
    }
}