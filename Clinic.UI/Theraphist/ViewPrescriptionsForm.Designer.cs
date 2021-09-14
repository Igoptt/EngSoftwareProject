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
            this.grid_EmitedPrescriptions = new System.Windows.Forms.DataGridView();
            this.Mais = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.grid_PrescriptionsWithClientGrantedAcess = new System.Windows.Forms.DataGridView();
            this.More = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grid_EmitedPrescriptions)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_PrescriptionsWithClientGrantedAcess)).BeginInit();
            this.SuspendLayout();
            // 
            // grid_EmitedPrescriptions
            // 
            this.grid_EmitedPrescriptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_EmitedPrescriptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_EmitedPrescriptions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.Mais });
            this.grid_EmitedPrescriptions.Location = new System.Drawing.Point(3, 3);
            this.grid_EmitedPrescriptions.Name = "grid_EmitedPrescriptions";
            this.grid_EmitedPrescriptions.Size = new System.Drawing.Size(892, 430);
            this.grid_EmitedPrescriptions.TabIndex = 0;
            this.grid_EmitedPrescriptions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_EmitedPrescriptions_CellContentClick);
            // 
            // Mais
            // 
            this.Mais.HeaderText = "Mais Informação";
            this.Mais.Name = "Mais";
            this.Mais.Text = "Mais Informação";
            this.Mais.UseColumnTextForButtonValue = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(192, 74);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(788, 350);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(3, 97);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(906, 462);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.grid_EmitedPrescriptions);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(898, 436);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Prescrições Emitidas";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.grid_PrescriptionsWithClientGrantedAcess);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(898, 436);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Prescrições com permissão do cliente";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // grid_PrescriptionsWithClientGrantedAcess
            // 
            this.grid_PrescriptionsWithClientGrantedAcess.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_PrescriptionsWithClientGrantedAcess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_PrescriptionsWithClientGrantedAcess.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.More });
            this.grid_PrescriptionsWithClientGrantedAcess.Location = new System.Drawing.Point(3, 3);
            this.grid_PrescriptionsWithClientGrantedAcess.Name = "grid_PrescriptionsWithClientGrantedAcess";
            this.grid_PrescriptionsWithClientGrantedAcess.Size = new System.Drawing.Size(892, 430);
            this.grid_PrescriptionsWithClientGrantedAcess.TabIndex = 0;
            this.grid_PrescriptionsWithClientGrantedAcess.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_PrescriptionsWithClientGrantedAcess_CellContentClick);
            // 
            // More
            // 
            this.More.HeaderText = "Mais";
            this.More.Name = "More";
            // 
            // ClientPrescriptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(908, 561);
            this.Controls.Add(this.tabControl1);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "ClientPrescriptionsForm";
            this.Text = "View Client Prescription";
            //this.Load += new System.EventHandler(this.ClientPrescriptionsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_EmitedPrescriptions)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_PrescriptionsWithClientGrantedAcess)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridViewButtonColumn More;

        private System.Windows.Forms.DataGridViewButtonColumn Mais;

        private System.Windows.Forms.DataGridView grid_PrescriptionsWithClientGrantedAcess;

        // private System.Windows.Forms.DataGridView dataGridView1;

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;

        private System.Windows.Forms.DataGridView grid_EmitedPrescriptions;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;

        // private System.Windows.Forms.DataGridView grid_ClientPrescriptions;

        #endregion
    }
}