﻿
namespace StarGarments.GUI.Controls
{
    partial class Ctrl_User
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSchool = new System.Windows.Forms.TextBox();
            this.School = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(29, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Name";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnUpdate.Location = new System.Drawing.Point(308, 279);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(170, 60);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtFirstName.Location = new System.Drawing.Point(128, 54);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(350, 29);
            this.txtFirstName.TabIndex = 2;
            // 
            // txtLastName
            // 
            this.txtLastName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtLastName.Location = new System.Drawing.Point(128, 101);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(350, 29);
            this.txtLastName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(29, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Last Name";
            // 
            // txtSchool
            // 
            this.txtSchool.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSchool.Location = new System.Drawing.Point(128, 221);
            this.txtSchool.Name = "txtSchool";
            this.txtSchool.Size = new System.Drawing.Size(350, 29);
            this.txtSchool.TabIndex = 8;
            // 
            // School
            // 
            this.School.AutoSize = true;
            this.School.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.School.Location = new System.Drawing.Point(52, 224);
            this.School.Name = "School";
            this.School.Size = new System.Drawing.Size(57, 21);
            this.School.TabIndex = 7;
            this.School.Text = "School";
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAddress.Location = new System.Drawing.Point(128, 150);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(350, 56);
            this.txtAddress.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(43, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 21);
            this.label4.TabIndex = 5;
            this.label4.Text = "Address";
            // 
            // Ctrl_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtSchool);
            this.Controls.Add(this.School);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label1);
            this.Name = "Ctrl_User";
            this.Size = new System.Drawing.Size(527, 368);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSchool;
        private System.Windows.Forms.Label School;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label4;
    }
}