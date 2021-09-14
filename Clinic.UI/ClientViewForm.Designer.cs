using System.ComponentModel;

namespace Clinic.UI
{
    partial class ClientViewForm
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
            this.btn_CreateSessionClientView = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_Prescriptions = new System.Windows.Forms.TabPage();
            this.grid_PrescriptionsClientView = new System.Windows.Forms.DataGridView();
            this.Mais = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Visibilidade = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tab_Sessions = new System.Windows.Forms.TabPage();
            this.grid_ClientSessions = new System.Windows.Forms.DataGridView();
            this.DetalhesClientView = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DesmarcarClientView = new System.Windows.Forms.DataGridViewButtonColumn();
            this.EditarSessao = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TerapeutaSessao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detalhes = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Desmarcar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_ClientName = new System.Windows.Forms.Label();
            this.btn_logout = new System.Windows.Forms.Button();
            this.btn_sair = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tab_Prescriptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_PrescriptionsClientView)).BeginInit();
            this.tab_Sessions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_ClientSessions)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_CreateSessionClientView
            // 
            this.btn_CreateSessionClientView.Location = new System.Drawing.Point(12, 34);
            this.btn_CreateSessionClientView.Name = "btn_CreateSessionClientView";
            this.btn_CreateSessionClientView.Size = new System.Drawing.Size(136, 60);
            this.btn_CreateSessionClientView.TabIndex = 0;
            this.btn_CreateSessionClientView.Text = "Criar Sessão";
            this.btn_CreateSessionClientView.UseVisualStyleBackColor = true;
            this.btn_CreateSessionClientView.Click += new System.EventHandler(this.btn_CreateSessionClientView_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tab_Prescriptions);
            this.tabControl1.Controls.Add(this.tab_Sessions);
            this.tabControl1.Location = new System.Drawing.Point(12, 100);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(893, 457);
            this.tabControl1.TabIndex = 1;
            // 
            // tab_Prescriptions
            // 
            this.tab_Prescriptions.Controls.Add(this.grid_PrescriptionsClientView);
            this.tab_Prescriptions.Location = new System.Drawing.Point(4, 22);
            this.tab_Prescriptions.Name = "tab_Prescriptions";
            this.tab_Prescriptions.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Prescriptions.Size = new System.Drawing.Size(885, 431);
            this.tab_Prescriptions.TabIndex = 0;
            this.tab_Prescriptions.Text = "Prescrições";
            this.tab_Prescriptions.UseVisualStyleBackColor = true;
            // 
            // grid_PrescriptionsClientView
            // 
            this.grid_PrescriptionsClientView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_PrescriptionsClientView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_PrescriptionsClientView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.Mais, this.Visibilidade });
            this.grid_PrescriptionsClientView.Location = new System.Drawing.Point(3, 3);
            this.grid_PrescriptionsClientView.Name = "grid_PrescriptionsClientView";
            this.grid_PrescriptionsClientView.Size = new System.Drawing.Size(879, 425);
            this.grid_PrescriptionsClientView.TabIndex = 0;
            this.grid_PrescriptionsClientView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_PrescriptionsClientView_CellContentClick);
            // 
            // Mais
            // 
            this.Mais.HeaderText = "Mais";
            this.Mais.Name = "Mais";
            this.Mais.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Mais.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Mais.Text = "Mais";
            this.Mais.UseColumnTextForButtonValue = true;
            // 
            // Visibilidade
            // 
            this.Visibilidade.HeaderText = "Visibilidade";
            this.Visibilidade.Name = "Visibilidade";
            this.Visibilidade.Text = "Visibilidade";
            this.Visibilidade.UseColumnTextForButtonValue = true;
            // 
            // tab_Sessions
            // 
            this.tab_Sessions.Controls.Add(this.grid_ClientSessions);
            this.tab_Sessions.Location = new System.Drawing.Point(4, 22);
            this.tab_Sessions.Name = "tab_Sessions";
            this.tab_Sessions.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Sessions.Size = new System.Drawing.Size(885, 431);
            this.tab_Sessions.TabIndex = 1;
            this.tab_Sessions.Text = "Sessões";
            this.tab_Sessions.UseVisualStyleBackColor = true;
            // 
            // grid_ClientSessions
            // 
            this.grid_ClientSessions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_ClientSessions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_ClientSessions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.DetalhesClientView, this.DesmarcarClientView, this.EditarSessao });
            this.grid_ClientSessions.Location = new System.Drawing.Point(3, 3);
            this.grid_ClientSessions.Name = "grid_ClientSessions";
            this.grid_ClientSessions.Size = new System.Drawing.Size(879, 425);
            this.grid_ClientSessions.TabIndex = 0;
            this.grid_ClientSessions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_ClientSessions_CellContentClick);
            // 
            // DetalhesClientView
            // 
            this.DetalhesClientView.HeaderText = "Detalhes";
            this.DetalhesClientView.Name = "DetalhesClientView";
            this.DetalhesClientView.Text = "Detalhes";
            this.DetalhesClientView.UseColumnTextForButtonValue = true;
            // 
            // DesmarcarClientView
            // 
            this.DesmarcarClientView.HeaderText = "Desmarcar";
            this.DesmarcarClientView.Name = "DesmarcarClientView";
            this.DesmarcarClientView.Text = "Desmarcar";
            this.DesmarcarClientView.UseColumnTextForButtonValue = true;
            // 
            // EditarSessao
            // 
            this.EditarSessao.HeaderText = "Editar Sessao";
            this.EditarSessao.Name = "EditarSessao";
            this.EditarSessao.Text = "Editar Sessao";
            this.EditarSessao.UseColumnTextForButtonValue = true;
            // 
            // Data
            // 
            this.Data.HeaderText = "Data";
            this.Data.Name = "Data";
            // 
            // Hora
            // 
            this.Hora.HeaderText = "Hora";
            this.Hora.Name = "Hora";
            // 
            // TerapeutaSessao
            // 
            this.TerapeutaSessao.HeaderText = "TerapeutaSessao";
            this.TerapeutaSessao.Name = "TerapeutaSessao";
            // 
            // Detalhes
            // 
            this.Detalhes.HeaderText = "Detalhes";
            this.Detalhes.Name = "Detalhes";
            this.Detalhes.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Detalhes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Detalhes.Text = "Detalhes";
            this.Detalhes.UseColumnTextForButtonValue = true;
            // 
            // Desmarcar
            // 
            this.Desmarcar.HeaderText = "Desmarcar";
            this.Desmarcar.Name = "Desmarcar";
            this.Desmarcar.Text = "Desmarcar";
            this.Desmarcar.UseColumnTextForButtonValue = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bem vindo Cliente";
            // 
            // lb_ClientName
            // 
            this.lb_ClientName.Location = new System.Drawing.Point(103, 8);
            this.lb_ClientName.Name = "lb_ClientName";
            this.lb_ClientName.Size = new System.Drawing.Size(253, 23);
            this.lb_ClientName.TabIndex = 3;
            // 
            // btn_logout
            // 
            this.btn_logout.Location = new System.Drawing.Point(924, 600);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(103, 30);
            this.btn_logout.TabIndex = 4;
            this.btn_logout.Text = "Sair";
            this.btn_logout.UseVisualStyleBackColor = true;
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            // 
            // btn_sair
            // 
            this.btn_sair.Location = new System.Drawing.Point(801, 34);
            this.btn_sair.Name = "btn_sair";
            this.btn_sair.Size = new System.Drawing.Size(95, 40);
            this.btn_sair.TabIndex = 5;
            this.btn_sair.Text = "Sair";
            this.btn_sair.UseVisualStyleBackColor = true;
            this.btn_sair.Click += new System.EventHandler(this.button1_Click);
            // 
            // ClientViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 561);
            this.Controls.Add(this.btn_sair);
            this.Controls.Add(this.btn_logout);
            this.Controls.Add(this.lb_ClientName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btn_CreateSessionClientView);
            this.Name = "ClientViewForm";
            this.Text = "ClientViewForm";
            this.tabControl1.ResumeLayout(false);
            this.tab_Prescriptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_PrescriptionsClientView)).EndInit();
            this.tab_Sessions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_ClientSessions)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btn_sair;

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.Button btn_logout;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_ClientName;

        private System.Windows.Forms.DataGridViewButtonColumn DetalhesClientView;
        private System.Windows.Forms.DataGridViewButtonColumn DesmarcarClientView;

        private System.Windows.Forms.DataGridViewButtonColumn EditarSessao;

        private System.Windows.Forms.DataGridViewButtonColumn Detalhes;
        private System.Windows.Forms.DataGridViewButtonColumn Desmarcar;
        private System.Windows.Forms.DataGridView grid_ClientSessions;

        private System.Windows.Forms.DataGridViewTextBoxColumn TerapeutaSessao;

        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora;

        private System.Windows.Forms.DataGridView grid_PrescriptionsClientView;

        private System.Windows.Forms.DataGridViewButtonColumn Mais;
        private System.Windows.Forms.DataGridViewButtonColumn Visibilidade;

        private System.Windows.Forms.TabPage tab_Prescriptions;
        private System.Windows.Forms.TabPage tab_Sessions;
        private System.Windows.Forms.DataGridView dataGridView1;

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_;
        private System.Windows.Forms.TabPage tab;

        private System.Windows.Forms.Button btn_CreateSessionClientView;

        #endregion
    }
}