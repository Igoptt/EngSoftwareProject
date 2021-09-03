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
            this.SessionDataTherapistView = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddSessionNoteTherapistView = new System.Windows.Forms.DataGridViewButtonColumn();
            this.RemoveAppointmentTherapistView = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tab_ClientsTherapistView = new System.Windows.Forms.TabPage();
            this.grid_ClientsTherapistView = new System.Windows.Forms.DataGridView();
            this.ClientFirstNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientLastNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastSessionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prescrições = new System.Windows.Forms.DataGridViewButtonColumn();
            this.grid_therapistSessionList = new System.Windows.Forms.DataGridView();
            this.SessionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Actions = new System.Windows.Forms.DataGridViewButtonColumn();
            this.AddNote = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btn_AddPrescriptionToSession = new System.Windows.Forms.Button();
            this.table_TherapistView.SuspendLayout();
            this.tab_SessionsTherapistView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_SessionsTherapistView)).BeginInit();
            this.tab_ClientsTherapistView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_ClientsTherapistView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_therapistSessionList)).BeginInit();
            this.SuspendLayout();
            // 
            // table_TherapistView
            // 
            this.table_TherapistView.Controls.Add(this.tab_SessionsTherapistView);
            this.table_TherapistView.Controls.Add(this.tab_ClientsTherapistView);
            this.table_TherapistView.Location = new System.Drawing.Point(31, 84);
            this.table_TherapistView.Name = "table_TherapistView";
            this.table_TherapistView.SelectedIndex = 0;
            this.table_TherapistView.Size = new System.Drawing.Size(745, 354);
            this.table_TherapistView.TabIndex = 0;
            // 
            // tab_SessionsTherapistView
            // 
            this.tab_SessionsTherapistView.Controls.Add(this.grid_SessionsTherapistView);
            this.tab_SessionsTherapistView.Location = new System.Drawing.Point(4, 22);
            this.tab_SessionsTherapistView.Name = "tab_SessionsTherapistView";
            this.tab_SessionsTherapistView.Padding = new System.Windows.Forms.Padding(3);
            this.tab_SessionsTherapistView.Size = new System.Drawing.Size(737, 328);
            this.tab_SessionsTherapistView.TabIndex = 0;
            this.tab_SessionsTherapistView.Text = "Sessoes";
            this.tab_SessionsTherapistView.UseVisualStyleBackColor = true;
            // 
            // grid_SessionsTherapistView
            // 
            this.grid_SessionsTherapistView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_SessionsTherapistView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.SessionDataTherapistView, this.Column1, this.AddSessionNoteTherapistView, this.RemoveAppointmentTherapistView });
            this.grid_SessionsTherapistView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_SessionsTherapistView.Location = new System.Drawing.Point(3, 3);
            this.grid_SessionsTherapistView.Name = "grid_SessionsTherapistView";
            this.grid_SessionsTherapistView.Size = new System.Drawing.Size(731, 322);
            this.grid_SessionsTherapistView.TabIndex = 0;
            this.grid_SessionsTherapistView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_SessionsTherapistView_CellContentClick);
            // 
            // SessionDataTherapistView
            // 
            this.SessionDataTherapistView.HeaderText = "Data";
            this.SessionDataTherapistView.Name = "SessionDataTherapistView";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Cliente";
            this.Column1.Name = "Column1";
            // 
            // AddSessionNoteTherapistView
            // 
            this.AddSessionNoteTherapistView.HeaderText = "Adicionar Nota";
            this.AddSessionNoteTherapistView.Name = "AddSessionNoteTherapistView";
            this.AddSessionNoteTherapistView.Text = "Adicionar Nota";
            this.AddSessionNoteTherapistView.UseColumnTextForButtonValue = true;
            // 
            // RemoveAppointmentTherapistView
            // 
            this.RemoveAppointmentTherapistView.HeaderText = "Desmarcar Sessao";
            this.RemoveAppointmentTherapistView.Name = "RemoveAppointmentTherapistView";
            this.RemoveAppointmentTherapistView.Text = "Desmarcar Sessao";
            this.RemoveAppointmentTherapistView.UseColumnTextForButtonValue = true;
            // 
            // tab_ClientsTherapistView
            // 
            this.tab_ClientsTherapistView.Controls.Add(this.grid_ClientsTherapistView);
            this.tab_ClientsTherapistView.Location = new System.Drawing.Point(4, 22);
            this.tab_ClientsTherapistView.Name = "tab_ClientsTherapistView";
            this.tab_ClientsTherapistView.Padding = new System.Windows.Forms.Padding(3);
            this.tab_ClientsTherapistView.Size = new System.Drawing.Size(737, 328);
            this.tab_ClientsTherapistView.TabIndex = 1;
            this.tab_ClientsTherapistView.Text = "Clientes";
            this.tab_ClientsTherapistView.UseVisualStyleBackColor = true;
            // 
            // grid_ClientsTherapistView
            // 
            this.grid_ClientsTherapistView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_ClientsTherapistView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.ClientFirstNameColumn, this.ClientLastNameColumn, this.LastSessionDate, this.Prescrições });
            this.grid_ClientsTherapistView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_ClientsTherapistView.Location = new System.Drawing.Point(3, 3);
            this.grid_ClientsTherapistView.Name = "grid_ClientsTherapistView";
            this.grid_ClientsTherapistView.Size = new System.Drawing.Size(731, 322);
            this.grid_ClientsTherapistView.TabIndex = 0;
            this.grid_ClientsTherapistView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_ClientsTherapistView_CellContentClick);
            // 
            // ClientFirstNameColumn
            // 
            this.ClientFirstNameColumn.HeaderText = "Primeiro Nome";
            this.ClientFirstNameColumn.Name = "ClientFirstNameColumn";
            // 
            // ClientLastNameColumn
            // 
            this.ClientLastNameColumn.HeaderText = "Ultimo Nome";
            this.ClientLastNameColumn.Name = "ClientLastNameColumn";
            // 
            // LastSessionDate
            // 
            this.LastSessionDate.HeaderText = "Ultima Sessao";
            this.LastSessionDate.Name = "LastSessionDate";
            this.LastSessionDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.LastSessionDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Prescrições
            // 
            this.Prescrições.HeaderText = "Prescrições";
            this.Prescrições.Name = "Prescrições";
            this.Prescrições.Text = "Prescrições";
            this.Prescrições.UseColumnTextForButtonValue = true;
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
            this.btn_AddPrescriptionToSession.Location = new System.Drawing.Point(31, 12);
            this.btn_AddPrescriptionToSession.Name = "btn_AddPrescriptionToSession";
            this.btn_AddPrescriptionToSession.Size = new System.Drawing.Size(167, 66);
            this.btn_AddPrescriptionToSession.TabIndex = 1;
            this.btn_AddPrescriptionToSession.Text = "Adicionar Prescriçao a Sessão";
            this.btn_AddPrescriptionToSession.UseVisualStyleBackColor = true;
            this.btn_AddPrescriptionToSession.Click += new System.EventHandler(this.btn_AddPrescriptionToSession_Click);
            // 
            // TherapistViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_AddPrescriptionToSession);
            this.Controls.Add(this.table_TherapistView);
            this.Name = "TherapistViewForm";
            this.Text = "TherapistViewForm";
            this.table_TherapistView.ResumeLayout(false);
            this.tab_SessionsTherapistView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_SessionsTherapistView)).EndInit();
            this.tab_ClientsTherapistView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_ClientsTherapistView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_therapistSessionList)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridViewButtonColumn Prescrições;

        private System.Windows.Forms.DataGridView grid_ClientsTherapistView;

        private System.Windows.Forms.Button btn_AddPrescriptionToSession;

        private System.Windows.Forms.DataGridView grid_SessionsTherapistView;

        private System.Windows.Forms.DataGridViewTextBoxColumn ClientFirstNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientLastNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastSessionDate;

        private System.Windows.Forms.TabControl table_TherapistView;
        private System.Windows.Forms.DataGridView dataGridView2;

        private System.Windows.Forms.TabPage tab_ClientsTherapistView;

        private System.Windows.Forms.DataGridViewTextBoxColumn SessionDataTherapistView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
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