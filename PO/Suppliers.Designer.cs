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
            this.btnCreateSupplier = new System.Windows.Forms.Button();
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
            // btnCreateSupplier
            // 
            this.btnCreateSupplier.Location = new System.Drawing.Point(257, 70);
            this.btnCreateSupplier.Name = "btnCreateSupplier";
            this.btnCreateSupplier.Size = new System.Drawing.Size(75, 23);
            this.btnCreateSupplier.TabIndex = 2;
            this.btnCreateSupplier.Text = "Save";
            this.btnCreateSupplier.UseVisualStyleBackColor = true;
            this.btnCreateSupplier.Click += new System.EventHandler(this.btnCreateSupplier_Click);
            // 
            // Suppliers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 117);
            this.Controls.Add(this.btnCreateSupplier);
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
        private System.Windows.Forms.Button btnCreateSupplier;
    }
}