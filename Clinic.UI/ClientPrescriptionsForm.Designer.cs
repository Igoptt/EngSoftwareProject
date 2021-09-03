using System.ComponentModel;

namespace Clinic.UI
{
    partial class ClientPrescriptionsForm
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
            this.grid_ClientPrescriptions = new System.Windows.Forms.DataGridView();
            this.Dia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prescrito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChangePrescription = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grid_ClientPrescriptions)).BeginInit();
            this.SuspendLayout();
            // 
            // grid_ClientPrescriptions
            // 
            this.grid_ClientPrescriptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_ClientPrescriptions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.Dia, this.Hora, this.Prescrito, this.ChangePrescription });
            this.grid_ClientPrescriptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_ClientPrescriptions.Location = new System.Drawing.Point(0, 0);
            this.grid_ClientPrescriptions.Name = "grid_ClientPrescriptions";
            this.grid_ClientPrescriptions.Size = new System.Drawing.Size(800, 450);
            this.grid_ClientPrescriptions.TabIndex = 0;
            this.grid_ClientPrescriptions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_ClientPrescriptions_CellContentClick);
            // 
            // Dia
            // 
            this.Dia.HeaderText = "Dia";
            this.Dia.Name = "Dia";
            // 
            // Hora
            // 
            this.Hora.HeaderText = "Hora";
            this.Hora.Name = "Hora";
            // 
            // Prescrito
            // 
            this.Prescrito.HeaderText = "Prescrito";
            this.Prescrito.Name = "Prescrito";
            // 
            // ChangePrescription
            // 
            this.ChangePrescription.HeaderText = "Alterar Prescrição";
            this.ChangePrescription.Name = "ChangePrescription";
            this.ChangePrescription.Text = "Alterar Prescrição";
            this.ChangePrescription.UseColumnTextForButtonValue = true;
            // 
            // ClientPrescriptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grid_ClientPrescriptions);
            this.Name = "ClientPrescriptionsForm";
            this.Text = "ClientPrescriptionsForm";
            ((System.ComponentModel.ISupportInitialize)(this.grid_ClientPrescriptions)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridViewTextBoxColumn Dia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prescrito;
        private System.Windows.Forms.DataGridViewButtonColumn ChangePrescription;

        private System.Windows.Forms.DataGridView grid_ClientPrescriptions;

        #endregion
    }
}