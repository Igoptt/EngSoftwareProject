using System.ComponentModel;

namespace Clinic.UI
{
    partial class CreateSessionForm
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
            this.cb_ChooseTherapist = new System.Windows.Forms.ComboBox();
            this.dtp_SessionDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_CreateSession = new System.Windows.Forms.Button();
            this.cb_sessionHours = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cb_ChooseTherapist
            // 
            this.cb_ChooseTherapist.FormattingEnabled = true;
            this.cb_ChooseTherapist.Location = new System.Drawing.Point(305, 171);
            this.cb_ChooseTherapist.Name = "cb_ChooseTherapist";
            this.cb_ChooseTherapist.Size = new System.Drawing.Size(310, 21);
            this.cb_ChooseTherapist.TabIndex = 0;
            this.cb_ChooseTherapist.Text = "Escolha um dos nossos Terapeutas";
            // 
            // dtp_SessionDate
            // 
            this.dtp_SessionDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_SessionDate.Location = new System.Drawing.Point(305, 232);
            this.dtp_SessionDate.Name = "dtp_SessionDate";
            this.dtp_SessionDate.Size = new System.Drawing.Size(310, 20);
            this.dtp_SessionDate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(305, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Escolha a data e hora da consulta";
            // 
            // btn_CreateSession
            // 
            this.btn_CreateSession.Location = new System.Drawing.Point(305, 325);
            this.btn_CreateSession.Name = "btn_CreateSession";
            this.btn_CreateSession.Size = new System.Drawing.Size(310, 74);
            this.btn_CreateSession.TabIndex = 4;
            this.btn_CreateSession.Text = "Guardar";
            this.btn_CreateSession.UseVisualStyleBackColor = true;
            this.btn_CreateSession.Click += new System.EventHandler(this.btn_CreateSession_Click);
            // 
            // cb_sessionHours
            // 
            this.cb_sessionHours.FormattingEnabled = true;
            this.cb_sessionHours.Location = new System.Drawing.Point(305, 272);
            this.cb_sessionHours.Name = "cb_sessionHours";
            this.cb_sessionHours.Size = new System.Drawing.Size(310, 21);
            this.cb_sessionHours.TabIndex = 5;
            // 
            // CreateSessionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 561);
            this.Controls.Add(this.cb_sessionHours);
            this.Controls.Add(this.btn_CreateSession);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtp_SessionDate);
            this.Controls.Add(this.cb_ChooseTherapist);
            this.Name = "CreateSessionForm";
            this.Text = "CreateSessionForm";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ComboBox cb_sessionHours;

        private System.Windows.Forms.Button btn_CreateSession;

        private System.Windows.Forms.DateTimePicker dtp_SessionDate;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox cb_ChooseTherapist;

        private System.Windows.Forms.ComboBox comboBox1;

        #endregion
    }
}