namespace PO
{
    partial class Suppliers
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSuppName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveSupps = new System.Windows.Forms.Button();
            this.btnCreatePO = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSuppName
            // 
            this.txtSuppName.Location = new System.Drawing.Point(79, 32);
            this.txtSuppName.MaxLength = 150;
            this.txtSuppName.Name = "txtSuppName";
            this.txtSuppName.Size = new System.Drawing.Size(253, 22);
            this.txtSuppName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name:";
            // 
            // btnSaveSupps
            // 
            this.btnSaveSupps.Location = new System.Drawing.Point(174, 70);
            this.btnSaveSupps.Name = "btnSaveSupps";
            this.btnSaveSupps.Size = new System.Drawing.Size(75, 23);
            this.btnSaveSupps.TabIndex = 2;
            this.btnSaveSupps.Text = "Save";
            this.btnSaveSupps.UseVisualStyleBackColor = true;
            this.btnSaveSupps.Click += new System.EventHandler(this.btnCreateSupplier_Click);
            // 
            // btnCreatePO
            // 
            this.btnCreatePO.Location = new System.Drawing.Point(257, 70);
            this.btnCreatePO.Name = "btnCreatePO";
            this.btnCreatePO.Size = new System.Drawing.Size(75, 23);
            this.btnCreatePO.TabIndex = 3;
            this.btnCreatePO.Text = "Create PO";
            this.btnCreatePO.UseVisualStyleBackColor = true;
            this.btnCreatePO.Click += new System.EventHandler(this.btnCreatePO_Click);
            // 
            // Suppliers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 117);
            this.Controls.Add(this.btnCreatePO);
            this.Controls.Add(this.btnSaveSupps);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSuppName);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Suppliers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Suppliers";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Suppliers_FormClosing);
            this.Load += new System.EventHandler(this.Suppliers_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSuppName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveSupps;
        private System.Windows.Forms.Button btnCreatePO;
    }
}