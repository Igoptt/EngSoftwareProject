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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btn_SavePrescriptionVisibilityChanges = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] { "Sim", "Não" });
            this.comboBox1.Location = new System.Drawing.Point(237, 166);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(253, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Text = "Deseja que esta prescrição seja privada?";
            // 
            // btn_SavePrescriptionVisibilityChanges
            // 
            this.btn_SavePrescriptionVisibilityChanges.Location = new System.Drawing.Point(264, 246);
            this.btn_SavePrescriptionVisibilityChanges.Name = "btn_SavePrescriptionVisibilityChanges";
            this.btn_SavePrescriptionVisibilityChanges.Size = new System.Drawing.Size(195, 78);
            this.btn_SavePrescriptionVisibilityChanges.TabIndex = 1;
            this.btn_SavePrescriptionVisibilityChanges.Text = "Guardar";
            this.btn_SavePrescriptionVisibilityChanges.UseVisualStyleBackColor = true;
            this.btn_SavePrescriptionVisibilityChanges.Click += new System.EventHandler(this.btn_SavePrescriptionVisibilityChanges_Click);
            // 
            // ChangePrescriptionVisibilityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_SavePrescriptionVisibilityChanges);
            this.Controls.Add(this.comboBox1);
            this.Name = "ChangePrescriptionVisibilityForm";
            this.Text = "ChangePrescriptionVisibilityForm";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btn_SavePrescriptionVisibilityChanges;

        private System.Windows.Forms.ComboBox comboBox1;

        #endregion
    }
}