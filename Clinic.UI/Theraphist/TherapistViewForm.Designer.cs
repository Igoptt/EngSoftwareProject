using System.ComponentModel;

namespace Clinic.UI
{
    partial class TherapistViewForm
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
            this.table_TherapistView = new System.Windows.Forms.TabControl();
            this.tab_SessionsTherapistView = new System.Windows.Forms.TabPage();
            this.grid_SessionsTherapistView = new System.Windows.Forms.DataGridView();
            this.AddSessionNoteTherapistView = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Prescription = new System.Windows.Forms.DataGridViewButtonColumn();
            this.RemoveAppointmentTherapistView = new System.Windows.Forms.DataGridViewButtonColumn();
            this.grid_therapistSessionList = new System.Windows.Forms.DataGridView();
            this.SessionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Actions = new System.Windows.Forms.DataGridViewButtonColumn();
            this.AddNote = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btn_AddPrescriptionToSession = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label_TherapistName = new System.Windows.Forms.Label();
            this.btn_logout = new System.Windows.Forms.Button();
            this.table_TherapistView.SuspendLayout();
            this.tab_SessionsTherapistView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_SessionsTherapistView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_therapistSessionList)).BeginInit();
            this.SuspendLayout();
            // 
            // table_TherapistView
            // 
            this.table_TherapistView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.table_TherapistView.Controls.Add(this.tab_SessionsTherapistView);
            this.table_TherapistView.Location = new System.Drawing.Point(31, 110);
            this.table_TherapistView.Name = "table_TherapistView";
            this.table_TherapistView.SelectedIndex = 0;
            this.table_TherapistView.Size = new System.Drawing.Size(853, 439);
            this.table_TherapistView.TabIndex = 0;
            // 
            // tab_SessionsTherapistView
            // 
            this.tab_SessionsTherapistView.Controls.Add(this.grid_SessionsTherapistView);
            this.tab_SessionsTherapistView.Location = new System.Drawing.Point(4, 22);
            this.tab_SessionsTherapistView.Name = "tab_SessionsTherapistView";
            this.tab_SessionsTherapistView.Padding = new System.Windows.Forms.Padding(3);
            this.tab_SessionsTherapistView.Size = new System.Drawing.Size(845, 413);
            this.tab_SessionsTherapistView.TabIndex = 0;
            this.tab_SessionsTherapistView.Text = "Sessoes";
            this.tab_SessionsTherapistView.UseVisualStyleBackColor = true;
            // 
            // grid_SessionsTherapistView
            // 
            this.grid_SessionsTherapistView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_SessionsTherapistView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_SessionsTherapistView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.AddSessionNoteTherapistView, this.Prescription, this.RemoveAppointmentTherapistView });
            this.grid_SessionsTherapistView.Location = new System.Drawing.Point(3, 3);
            this.grid_SessionsTherapistView.Name = "grid_SessionsTherapistView";
            this.grid_SessionsTherapistView.Size = new System.Drawing.Size(839, 407);
            this.grid_SessionsTherapistView.TabIndex = 0;
            this.grid_SessionsTherapistView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_SessionsTherapistView_CellContentClick);
            // 
            // AddSessionNoteTherapistView
            // 
            this.AddSessionNoteTherapistView.HeaderText = "Adicionar Nota";
            this.AddSessionNoteTherapistView.Name = "AddSessionNoteTherapistView";
            this.AddSessionNoteTherapistView.Text = "Adicionar Nota";
            this.AddSessionNoteTherapistView.UseColumnTextForButtonValue = true;
            // 
            // Prescription
            // 
            this.Prescription.HeaderText = "Prescrição";
            this.Prescription.Name = "Prescription";
            this.Prescription.Text = "Prescrição";
            this.Prescription.UseColumnTextForButtonValue = true;
            // 
            // RemoveAppointmentTherapistView
            // 
            this.RemoveAppointmentTherapistView.HeaderText = "Desmarcar Sessao";
            this.RemoveAppointmentTherapistView.Name = "RemoveAppointmentTherapistView";
            this.RemoveAppointmentTherapistView.Text = "Desmarcar Sessao";
            this.RemoveAppointmentTherapistView.UseColumnTextForButtonValue = true;
            // 
            // grid_therapistSessionList
            // 
            this.grid_therapistSessionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_therapistSessionList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.SessionDate, this.ClientName, this.Actions, this.AddNote });
            this.grid_therapistSessionList.GridColor = System.Drawing.SystemColors.ControlLight;
            this.grid_therapistSessionList.Location = new System.Drawing.Point(24, 34);
            this.grid_therapistSessionList.Name = "grid_therapistSessionList";
            this.grid_therapistSessionList.Size = new System.Drawing.Size(658, 265);
            this.grid_therapistSessionList.TabIndex = 0;
            // 
            // SessionDate
            // 
            this.SessionDate.HeaderText = "Data da Sessão";
            this.SessionDate.Name = "SessionDate";
            // 
            // ClientName
            // 
            this.ClientName.HeaderText = "Nome Do Cliente";
            this.ClientName.Name = "ClientName";
            // 
            // Actions
            // 
            this.Actions.HeaderText = "Apagar Sessão";
            this.Actions.Name = "Actions";
            this.Actions.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Actions.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // AddNote
            // 
            this.AddNote.HeaderText = "AdicionarNota";
            this.AddNote.Name = "AddNote";
            this.AddNote.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AddNote.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // btn_AddPrescriptionToSession
            // 
            this.btn_AddPrescriptionToSession.Location = new System.Drawing.Point(31, 38);
            this.btn_AddPrescriptionToSession.Name = "btn_AddPrescriptionToSession";
            this.btn_AddPrescriptionToSession.Size = new System.Drawing.Size(167, 66);
            this.btn_AddPrescriptionToSession.TabIndex = 1;
            this.btn_AddPrescriptionToSession.Text = "Adicionar Prescriçao a Sessão";
            this.btn_AddPrescriptionToSession.UseVisualStyleBackColor = true;
            this.btn_AddPrescriptionToSession.Click += new System.EventHandler(this.btn_AddPrescriptionToSession_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(31, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bem Vindo Terapeuta ";
            // 
            // label_TherapistName
            // 
            this.label_TherapistName.Location = new System.Drawing.Point(141, 12);
            this.label_TherapistName.Name = "label_TherapistName";
            this.label_TherapistName.Size = new System.Drawing.Size(267, 23);
            this.label_TherapistName.TabIndex = 2;
            this.label_TherapistName.Text = "XX";
            // 
            // btn_logout
            // 
            this.btn_logout.Location = new System.Drawing.Point(792, 38);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(88, 34);
            this.btn_logout.TabIndex = 3;
            this.btn_logout.Text = "Logout";
            this.btn_logout.UseVisualStyleBackColor = true;
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            // 
            // TherapistViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 561);
            this.Controls.Add(this.btn_logout);
            this.Controls.Add(this.label_TherapistName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_AddPrescriptionToSession);
            this.Controls.Add(this.table_TherapistView);
            this.Name = "TherapistViewForm";
            this.Text = "TherapistViewForm";
            this.table_TherapistView.ResumeLayout(false);
            this.tab_SessionsTherapistView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_SessionsTherapistView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_therapistSessionList)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btn_logout;

        private System.Windows.Forms.DataGridViewButtonColumn Prescription;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_TherapistName;

        private System.Windows.Forms.Button btn_AddPrescriptionToSession;

        private System.Windows.Forms.DataGridView grid_SessionsTherapistView;

        private System.Windows.Forms.TabControl table_TherapistView;
        private System.Windows.Forms.DataGridView dataGridView2;

        private System.Windows.Forms.DataGridViewButtonColumn AddSessionNoteTherapistView;
        private System.Windows.Forms.DataGridViewButtonColumn RemoveAppointmentTherapistView;

        private System.Windows.Forms.TabPage tab_SessionsTherapistView;

        private System.Windows.Forms.TabPage tabPage3;

        private System.Windows.Forms.DataGridView grid_therapistSessionList;

        private System.Windows.Forms.DataGridViewButtonColumn AddNote;

        private System.Windows.Forms.DataGridViewTextBoxColumn SessionDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientName;
        private System.Windows.Forms.DataGridViewButtonColumn Actions;

        private System.Windows.Forms.DataGridView dataGridView1;

        private System.Windows.Forms.Button button2;

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;

        #endregion
    }
}