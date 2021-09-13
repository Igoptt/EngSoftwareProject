using System.ComponentModel;

namespace Clinic.UI
{
    partial class CreateServiceForm
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
            this.cb_ServiceType = new System.Windows.Forms.ComboBox();
            this.grpBox_Medicine = new System.Windows.Forms.GroupBox();
            this.btn_SaveMedicine = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_MedicineSchedule = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_MedicineDosage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_MedicineName = new System.Windows.Forms.TextBox();
            this.grpBox_Exercise = new System.Windows.Forms.GroupBox();
            this.cb_ExerciseIntensity = new System.Windows.Forms.ComboBox();
            this.grpBox_Treatment = new System.Windows.Forms.GroupBox();
            this.cb_TreatmentDuration = new System.Windows.Forms.ComboBox();
            this.btn_SaveTreatment = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_TreatmentType = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_TreatmentName = new System.Windows.Forms.TextBox();
            this.btn_SaveExercise = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_ExerciseSchedule = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_ExerciseName = new System.Windows.Forms.TextBox();
            this.grpBox_Medicine.SuspendLayout();
            this.grpBox_Exercise.SuspendLayout();
            this.grpBox_Treatment.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_ServiceType
            // 
            this.cb_ServiceType.FormattingEnabled = true;
            this.cb_ServiceType.Items.AddRange(new object[] { "Medicamento", "Exercicio", "Tratamento" });
            this.cb_ServiceType.Location = new System.Drawing.Point(254, 69);
            this.cb_ServiceType.Name = "cb_ServiceType";
            this.cb_ServiceType.Size = new System.Drawing.Size(235, 21);
            this.cb_ServiceType.TabIndex = 0;
            this.cb_ServiceType.Text = "Escolha o tipo de Serviço";
            this.cb_ServiceType.SelectedIndexChanged += new System.EventHandler(this.cb_ServiceType_SelectedIndexChanged);
            // 
            // grpBox_Medicine
            // 
            this.grpBox_Medicine.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBox_Medicine.Controls.Add(this.btn_SaveMedicine);
            this.grpBox_Medicine.Controls.Add(this.label3);
            this.grpBox_Medicine.Controls.Add(this.textBox_MedicineSchedule);
            this.grpBox_Medicine.Controls.Add(this.label2);
            this.grpBox_Medicine.Controls.Add(this.textBox_MedicineDosage);
            this.grpBox_Medicine.Controls.Add(this.label1);
            this.grpBox_Medicine.Controls.Add(this.textBox_MedicineName);
            this.grpBox_Medicine.Location = new System.Drawing.Point(12, 137);
            this.grpBox_Medicine.Name = "grpBox_Medicine";
            this.grpBox_Medicine.Size = new System.Drawing.Size(820, 312);
            this.grpBox_Medicine.TabIndex = 1;
            this.grpBox_Medicine.TabStop = false;
            this.grpBox_Medicine.Text = "Medicamento";
            // 
            // btn_SaveMedicine
            // 
            this.btn_SaveMedicine.Location = new System.Drawing.Point(242, 219);
            this.btn_SaveMedicine.Name = "btn_SaveMedicine";
            this.btn_SaveMedicine.Size = new System.Drawing.Size(235, 78);
            this.btn_SaveMedicine.TabIndex = 7;
            this.btn_SaveMedicine.Text = "Guardar";
            this.btn_SaveMedicine.UseVisualStyleBackColor = true;
            this.btn_SaveMedicine.Click += new System.EventHandler(this.btn_SaveMedicine_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(242, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(235, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Quando tomar";
            // 
            // textBox_MedicineSchedule
            // 
            this.textBox_MedicineSchedule.Location = new System.Drawing.Point(242, 175);
            this.textBox_MedicineSchedule.Name = "textBox_MedicineSchedule";
            this.textBox_MedicineSchedule.Size = new System.Drawing.Size(235, 20);
            this.textBox_MedicineSchedule.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(242, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(235, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Dosagem";
            // 
            // textBox_MedicineDosage
            // 
            this.textBox_MedicineDosage.Location = new System.Drawing.Point(242, 117);
            this.textBox_MedicineDosage.Name = "textBox_MedicineDosage";
            this.textBox_MedicineDosage.Size = new System.Drawing.Size(235, 20);
            this.textBox_MedicineDosage.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(242, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nome do medicamento";
            // 
            // textBox_MedicineName
            // 
            this.textBox_MedicineName.Location = new System.Drawing.Point(242, 60);
            this.textBox_MedicineName.Name = "textBox_MedicineName";
            this.textBox_MedicineName.Size = new System.Drawing.Size(235, 20);
            this.textBox_MedicineName.TabIndex = 0;
            // 
            // grpBox_Exercise
            // 
            this.grpBox_Exercise.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBox_Exercise.Controls.Add(this.cb_ExerciseIntensity);
            this.grpBox_Exercise.Controls.Add(this.btn_SaveExercise);
            this.grpBox_Exercise.Controls.Add(this.label7);
            this.grpBox_Exercise.Controls.Add(this.textBox_ExerciseSchedule);
            this.grpBox_Exercise.Controls.Add(this.label8);
            this.grpBox_Exercise.Controls.Add(this.label9);
            this.grpBox_Exercise.Controls.Add(this.textBox_ExerciseName);
            this.grpBox_Exercise.Location = new System.Drawing.Point(12, 137);
            this.grpBox_Exercise.Name = "grpBox_Exercise";
            this.grpBox_Exercise.Size = new System.Drawing.Size(820, 312);
            this.grpBox_Exercise.TabIndex = 6;
            this.grpBox_Exercise.TabStop = false;
            this.grpBox_Exercise.Text = "Exercicio";
            // 
            // cb_ExerciseIntensity
            // 
            this.cb_ExerciseIntensity.FormattingEnabled = true;
            this.cb_ExerciseIntensity.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            this.cb_ExerciseIntensity.Location = new System.Drawing.Point(242, 117);
            this.cb_ExerciseIntensity.Name = "cb_ExerciseIntensity";
            this.cb_ExerciseIntensity.Size = new System.Drawing.Size(235, 21);
            this.cb_ExerciseIntensity.TabIndex = 7;
            // 
            // grpBox_Treatment
            // 
            this.grpBox_Treatment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBox_Treatment.Controls.Add(this.cb_TreatmentDuration);
            this.grpBox_Treatment.Controls.Add(this.btn_SaveTreatment);
            this.grpBox_Treatment.Controls.Add(this.label6);
            this.grpBox_Treatment.Controls.Add(this.textBox_TreatmentType);
            this.grpBox_Treatment.Controls.Add(this.label5);
            this.grpBox_Treatment.Controls.Add(this.label4);
            this.grpBox_Treatment.Controls.Add(this.textBox_TreatmentName);
            this.grpBox_Treatment.Location = new System.Drawing.Point(12, 137);
            this.grpBox_Treatment.Name = "grpBox_Treatment";
            this.grpBox_Treatment.Size = new System.Drawing.Size(820, 312);
            this.grpBox_Treatment.TabIndex = 2;
            this.grpBox_Treatment.TabStop = false;
            this.grpBox_Treatment.Text = "Tratamento";
            // 
            // cb_TreatmentDuration
            // 
            this.cb_TreatmentDuration.FormattingEnabled = true;
            this.cb_TreatmentDuration.Items.AddRange(new object[] {"1 mes", "2 meses", "3 meses", "4 meses", "5 meses", "6 meses", "7 meses", "8 meses", "9 meses", "10 meses", "11 meses", "12 meses"});
            this.cb_TreatmentDuration.Location = new System.Drawing.Point(242, 117);
            this.cb_TreatmentDuration.Name = "cb_TreatmentDuration";
            this.cb_TreatmentDuration.Size = new System.Drawing.Size(235, 21);
            this.cb_TreatmentDuration.TabIndex = 7;
            // 
            // btn_SaveTreatment
            // 
            this.btn_SaveTreatment.Location = new System.Drawing.Point(242, 217);
            this.btn_SaveTreatment.Name = "btn_SaveTreatment";
            this.btn_SaveTreatment.Size = new System.Drawing.Size(235, 76);
            this.btn_SaveTreatment.TabIndex = 6;
            this.btn_SaveTreatment.Text = "Guardar";
            this.btn_SaveTreatment.UseVisualStyleBackColor = true;
            this.btn_SaveTreatment.Click += new System.EventHandler(this.btn_SaveTreatment_Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(242, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(235, 23);
            this.label6.TabIndex = 5;
            this.label6.Text = "Tipo de tratamento";
            // 
            // textBox_TreatmentType
            // 
            this.textBox_TreatmentType.Location = new System.Drawing.Point(242, 179);
            this.textBox_TreatmentType.Name = "textBox_TreatmentType";
            this.textBox_TreatmentType.Size = new System.Drawing.Size(235, 20);
            this.textBox_TreatmentType.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(242, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(235, 23);
            this.label5.TabIndex = 3;
            this.label5.Text = "Duração do tratamento";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(242, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(235, 23);
            this.label4.TabIndex = 1;
            this.label4.Text = "Nome do tratamento";
            // 
            // textBox_TreatmentName
            // 
            this.textBox_TreatmentName.Location = new System.Drawing.Point(242, 60);
            this.textBox_TreatmentName.Name = "textBox_TreatmentName";
            this.textBox_TreatmentName.Size = new System.Drawing.Size(235, 20);
            this.textBox_TreatmentName.TabIndex = 0;
            // 
            // btn_SaveExercise
            // 
            this.btn_SaveExercise.Location = new System.Drawing.Point(242, 221);
            this.btn_SaveExercise.Name = "btn_SaveExercise";
            this.btn_SaveExercise.Size = new System.Drawing.Size(235, 67);
            this.btn_SaveExercise.TabIndex = 6;
            this.btn_SaveExercise.Text = "Guardar";
            this.btn_SaveExercise.UseVisualStyleBackColor = true;
            this.btn_SaveExercise.Click += new System.EventHandler(this.btn_SaveExercise_Click);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(242, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(235, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "Horario sugerido\r\n";
            // 
            // textBox_ExerciseSchedule
            // 
            this.textBox_ExerciseSchedule.Location = new System.Drawing.Point(242, 177);
            this.textBox_ExerciseSchedule.Name = "textBox_ExerciseSchedule";
            this.textBox_ExerciseSchedule.Size = new System.Drawing.Size(235, 20);
            this.textBox_ExerciseSchedule.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(242, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(235, 20);
            this.label8.TabIndex = 3;
            this.label8.Text = "Intensidade do Exercicio\r\n";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(242, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(235, 20);
            this.label9.TabIndex = 1;
            this.label9.Text = "Nome do Exercicio\r\n";
            // 
            // textBox_ExerciseName
            // 
            this.textBox_ExerciseName.Location = new System.Drawing.Point(242, 60);
            this.textBox_ExerciseName.Name = "textBox_ExerciseName";
            this.textBox_ExerciseName.Size = new System.Drawing.Size(235, 20);
            this.textBox_ExerciseName.TabIndex = 0;
            // 
            // CreateServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 561);
            this.Controls.Add(this.grpBox_Exercise);
            this.Controls.Add(this.grpBox_Treatment);
            this.Controls.Add(this.grpBox_Medicine);
            this.Controls.Add(this.cb_ServiceType);
            this.Name = "CreateServiceForm";
            this.Text = "Cria serviços";
            this.grpBox_Medicine.ResumeLayout(false);
            this.grpBox_Medicine.PerformLayout();
            this.grpBox_Exercise.ResumeLayout(false);
            this.grpBox_Exercise.PerformLayout();
            this.grpBox_Treatment.ResumeLayout(false);
            this.grpBox_Treatment.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ComboBox cb_ExerciseIntensity;

        private System.Windows.Forms.ComboBox cb_TreatmentDuration;

        private System.Windows.Forms.Button btn_SaveExercise;

        private System.Windows.Forms.Button btn_SaveMedicine;

        private System.Windows.Forms.Button btn_SaveTreatment;

        private System.Windows.Forms.TextBox textBox_ExerciseSchedule;

        private System.Windows.Forms.GroupBox grpBox_Exercise;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_ExerciseName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;

        private System.Windows.Forms.TextBox textBox_TreatmentType;

        private System.Windows.Forms.ComboBox cb_ServiceType;
        private System.Windows.Forms.GroupBox grpBox_Medicine;
        private System.Windows.Forms.TextBox textBox_MedicineName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_MedicineDosage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_MedicineSchedule;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grpBox_Treatment;
        private System.Windows.Forms.TextBox textBox_TreatmentName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;

        #endregion
    }
}