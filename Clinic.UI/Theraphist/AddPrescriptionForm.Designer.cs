using System.ComponentModel;

namespace Clinic.UI
{
    partial class AddPrescriptionForm
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
            this.cb_ChooseSession = new System.Windows.Forms.ComboBox();
            this.btn_CreateService = new System.Windows.Forms.Button();
            this.cb_Medicines = new System.Windows.Forms.ComboBox();
            this.btn_SavePrescription = new System.Windows.Forms.Button();
            this.cb_Exercises = new System.Windows.Forms.ComboBox();
            this.cb_Treatments = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cb_ChooseSession
            // 
            this.cb_ChooseSession.FormattingEnabled = true;
            this.cb_ChooseSession.Location = new System.Drawing.Point(12, 127);
            this.cb_ChooseSession.Name = "cb_ChooseSession";
            this.cb_ChooseSession.Size = new System.Drawing.Size(776, 21);
            this.cb_ChooseSession.TabIndex = 4;
            this.cb_ChooseSession.Text = "Escolha a sessão para adicionar uma prescrição";
            // 
            // btn_CreateService
            // 
            this.btn_CreateService.Location = new System.Drawing.Point(12, 49);
            this.btn_CreateService.Name = "btn_CreateService";
            this.btn_CreateService.Size = new System.Drawing.Size(184, 51);
            this.btn_CreateService.TabIndex = 5;
            this.btn_CreateService.Text = "Criar Serviço";
            this.btn_CreateService.UseVisualStyleBackColor = true;
            this.btn_CreateService.Click += new System.EventHandler(this.btn_CreateService_Click);
            // 
            // cb_Medicines
            // 
            this.cb_Medicines.FormattingEnabled = true;
            this.cb_Medicines.Location = new System.Drawing.Point(12, 164);
            this.cb_Medicines.Name = "cb_Medicines";
            this.cb_Medicines.Size = new System.Drawing.Size(776, 21);
            this.cb_Medicines.TabIndex = 6;
            this.cb_Medicines.Text = "Escolha o medicamento para adicionar";
            // 
            // btn_SavePrescription
            // 
            this.btn_SavePrescription.Location = new System.Drawing.Point(351, 309);
            this.btn_SavePrescription.Name = "btn_SavePrescription";
            this.btn_SavePrescription.Size = new System.Drawing.Size(163, 61);
            this.btn_SavePrescription.TabIndex = 7;
            this.btn_SavePrescription.Text = "Guardar";
            this.btn_SavePrescription.UseVisualStyleBackColor = true;
            this.btn_SavePrescription.Click += new System.EventHandler(this.btn_SavePrescription_Click);
            // 
            // cb_Exercises
            // 
            this.cb_Exercises.FormattingEnabled = true;
            this.cb_Exercises.Location = new System.Drawing.Point(12, 207);
            this.cb_Exercises.Name = "cb_Exercises";
            this.cb_Exercises.Size = new System.Drawing.Size(776, 21);
            this.cb_Exercises.TabIndex = 8;
            this.cb_Exercises.Text = "Escolha o exercicio para adicionar";
            // 
            // cb_Treatments
            // 
            this.cb_Treatments.FormattingEnabled = true;
            this.cb_Treatments.Location = new System.Drawing.Point(12, 246);
            this.cb_Treatments.Name = "cb_Treatments";
            this.cb_Treatments.Size = new System.Drawing.Size(776, 21);
            this.cb_Treatments.TabIndex = 9;
            this.cb_Treatments.Text = "Escolha o tratamento para adicionar";
            // 
            // AddPrescriptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 561);
            this.Controls.Add(this.cb_Treatments);
            this.Controls.Add(this.cb_Exercises);
            this.Controls.Add(this.btn_SavePrescription);
            this.Controls.Add(this.cb_Medicines);
            this.Controls.Add(this.btn_CreateService);
            this.Controls.Add(this.cb_ChooseSession);
            this.Name = "AddPrescriptionForm";
            this.Text = "Adicionar Prescrição";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ComboBox cb_Medicines;
        private System.Windows.Forms.ComboBox cb_Exercises;
        private System.Windows.Forms.ComboBox cb_Treatments;

        private System.Windows.Forms.Button btn_SavePrescription;

        private System.Windows.Forms.ComboBox cb_Services;

        private System.Windows.Forms.Button btn_CreateService;

        private System.Windows.Forms.ComboBox cb_ChooseSession;

        

        #endregion
    }
}