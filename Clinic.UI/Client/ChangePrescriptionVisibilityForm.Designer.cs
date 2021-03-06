using System.ComponentModel;

namespace Clinic.UI
{
    partial class ChangePrescriptionVisibilityForm
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
            this.btn_SavePrescriptionVisibilityChanges = new System.Windows.Forms.Button();
            this.cb_ChooseTherapist = new System.Windows.Forms.ComboBox();
            this.textBox_PrescriptionInformation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_SavePrescriptionVisibilityChanges
            // 
            this.btn_SavePrescriptionVisibilityChanges.Location = new System.Drawing.Point(318, 286);
            this.btn_SavePrescriptionVisibilityChanges.Name = "btn_SavePrescriptionVisibilityChanges";
            this.btn_SavePrescriptionVisibilityChanges.Size = new System.Drawing.Size(312, 87);
            this.btn_SavePrescriptionVisibilityChanges.TabIndex = 1;
            this.btn_SavePrescriptionVisibilityChanges.Text = "Guardar";
            this.btn_SavePrescriptionVisibilityChanges.UseVisualStyleBackColor = true;
            this.btn_SavePrescriptionVisibilityChanges.Click += new System.EventHandler(this.btn_SavePrescriptionVisibilityChanges_Click);
            // 
            // cb_ChooseTherapist
            // 
            this.cb_ChooseTherapist.FormattingEnabled = true;
            this.cb_ChooseTherapist.Location = new System.Drawing.Point(318, 232);
            this.cb_ChooseTherapist.Name = "cb_ChooseTherapist";
            this.cb_ChooseTherapist.Size = new System.Drawing.Size(312, 21);
            this.cb_ChooseTherapist.TabIndex = 3;
            this.cb_ChooseTherapist.Text = "Escolha o terapeuta ao qual deseja atribuir acesso";
            // 
            // textBox_PrescriptionInformation
            // 
            this.textBox_PrescriptionInformation.Location = new System.Drawing.Point(318, 185);
            this.textBox_PrescriptionInformation.Name = "textBox_PrescriptionInformation";
            this.textBox_PrescriptionInformation.Size = new System.Drawing.Size(312, 20);
            this.textBox_PrescriptionInformation.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(318, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(312, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Informação sobre a prescrição";
            // 
            // ChangePrescriptionVisibilityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(908, 561);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_PrescriptionInformation);
            this.Controls.Add(this.cb_ChooseTherapist);
            this.Controls.Add(this.btn_SavePrescriptionVisibilityChanges);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "ChangePrescriptionVisibilityForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.TextBox textBox_PrescriptionInformation;

        private System.Windows.Forms.ComboBox cb_ChooseTherapist;

        private System.Windows.Forms.Button btn_SavePrescriptionVisibilityChanges;

        private System.Windows.Forms.ComboBox comboBox1;

        #endregion
    }
}