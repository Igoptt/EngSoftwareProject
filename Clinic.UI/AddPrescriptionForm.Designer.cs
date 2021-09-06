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
            this.grpBox_PrescriptionOptions = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_ExerciseName = new System.Windows.Forms.TextBox();
            this.textBox_TreatmentName = new System.Windows.Forms.TextBox();
            this.textBox_MedicineName = new System.Windows.Forms.TextBox();
            this.btn_SavePrescription = new System.Windows.Forms.Button();
            this.cb_ChooseSession = new System.Windows.Forms.ComboBox();
            this.grpBox_PrescriptionOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBox_PrescriptionOptions
            // 
            this.grpBox_PrescriptionOptions.Controls.Add(this.label3);
            this.grpBox_PrescriptionOptions.Controls.Add(this.label2);
            this.grpBox_PrescriptionOptions.Controls.Add(this.label1);
            this.grpBox_PrescriptionOptions.Controls.Add(this.textBox_ExerciseName);
            this.grpBox_PrescriptionOptions.Controls.Add(this.textBox_TreatmentName);
            this.grpBox_PrescriptionOptions.Controls.Add(this.textBox_MedicineName);
            this.grpBox_PrescriptionOptions.Controls.Add(this.btn_SavePrescription);
            this.grpBox_PrescriptionOptions.Location = new System.Drawing.Point(12, 83);
            this.grpBox_PrescriptionOptions.Name = "grpBox_PrescriptionOptions";
            this.grpBox_PrescriptionOptions.Size = new System.Drawing.Size(776, 355);
            this.grpBox_PrescriptionOptions.TabIndex = 3;
            this.grpBox_PrescriptionOptions.TabStop = false;
            this.grpBox_PrescriptionOptions.Text = "Opções";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(268, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(251, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Nome do Exercicio";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(268, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nome do Tratamento";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(268, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nome do Medicamento";
            // 
            // textBox_ExerciseName
            // 
            this.textBox_ExerciseName.Location = new System.Drawing.Point(268, 140);
            this.textBox_ExerciseName.Name = "textBox_ExerciseName";
            this.textBox_ExerciseName.Size = new System.Drawing.Size(251, 20);
            this.textBox_ExerciseName.TabIndex = 3;
            // 
            // textBox_TreatmentName
            // 
            this.textBox_TreatmentName.Location = new System.Drawing.Point(268, 90);
            this.textBox_TreatmentName.Name = "textBox_TreatmentName";
            this.textBox_TreatmentName.Size = new System.Drawing.Size(251, 20);
            this.textBox_TreatmentName.TabIndex = 2;
            // 
            // textBox_MedicineName
            // 
            this.textBox_MedicineName.Location = new System.Drawing.Point(268, 38);
            this.textBox_MedicineName.Name = "textBox_MedicineName";
            this.textBox_MedicineName.Size = new System.Drawing.Size(251, 20);
            this.textBox_MedicineName.TabIndex = 1;
            // 
            // btn_SavePrescription
            // 
            this.btn_SavePrescription.Location = new System.Drawing.Point(268, 189);
            this.btn_SavePrescription.Name = "btn_SavePrescription";
            this.btn_SavePrescription.Size = new System.Drawing.Size(251, 99);
            this.btn_SavePrescription.TabIndex = 0;
            this.btn_SavePrescription.Text = "Guardar";
            this.btn_SavePrescription.UseVisualStyleBackColor = true;
            this.btn_SavePrescription.Click += new System.EventHandler(this.btn_SavePrescription_Click);
            // 
            // cb_ChooseSession
            // 
            this.cb_ChooseSession.FormattingEnabled = true;
            this.cb_ChooseSession.Location = new System.Drawing.Point(280, 52);
            this.cb_ChooseSession.Name = "cb_ChooseSession";
            this.cb_ChooseSession.Size = new System.Drawing.Size(251, 21);
            this.cb_ChooseSession.TabIndex = 4;
            this.cb_ChooseSession.Text = "Escolha a sessão para adicionar uma prescrição";
            this.cb_ChooseSession.SelectedIndexChanged += new System.EventHandler(this.cb_ChooseSession_SelectedIndexChanged);
            // 
            // AddPrescriptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cb_ChooseSession);
            this.Controls.Add(this.grpBox_PrescriptionOptions);
            this.Name = "AddPrescriptionForm";
            this.Text = "Adicionar Prescrição";
            this.grpBox_PrescriptionOptions.ResumeLayout(false);
            this.grpBox_PrescriptionOptions.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btn_SavePrescription;
        private System.Windows.Forms.TextBox textBox_MedicineName;
        private System.Windows.Forms.TextBox textBox_TreatmentName;
        private System.Windows.Forms.TextBox textBox_ExerciseName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.GroupBox grpBox_PrescriptionOptions;

        private System.Windows.Forms.ComboBox cb_ChooseSession;

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;

        private System.Windows.Forms.ComboBox cb_;

        #endregion
    }
}