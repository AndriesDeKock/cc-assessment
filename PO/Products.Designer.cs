namespace PO
{
    partial class Products
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
            this.btnCreateSupplier = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProdId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProdDescr = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProdPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboSupps = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnCreateSupplier
            // 
            this.btnCreateSupplier.Location = new System.Drawing.Point(268, 140);
            this.btnCreateSupplier.Name = "btnCreateSupplier";
            this.btnCreateSupplier.Size = new System.Drawing.Size(75, 23);
            this.btnCreateSupplier.TabIndex = 4;
            this.btnCreateSupplier.Text = "Save";
            this.btnCreateSupplier.UseVisualStyleBackColor = true;
            this.btnCreateSupplier.Click += new System.EventHandler(this.btnCreateSupplier_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Product ID:";
            // 
            // txtProdId
            // 
            this.txtProdId.Location = new System.Drawing.Point(95, 21);
            this.txtProdId.MaxLength = 50;
            this.txtProdId.Name = "txtProdId";
            this.txtProdId.Size = new System.Drawing.Size(253, 20);
            this.txtProdId.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Description:";
            // 
            // txtProdDescr
            // 
            this.txtProdDescr.Location = new System.Drawing.Point(95, 47);
            this.txtProdDescr.MaxLength = 250;
            this.txtProdDescr.Name = "txtProdDescr";
            this.txtProdDescr.Size = new System.Drawing.Size(253, 20);
            this.txtProdDescr.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Price:";
            // 
            // txtProdPrice
            // 
            this.txtProdPrice.Location = new System.Drawing.Point(95, 73);
            this.txtProdPrice.MaxLength = 10;
            this.txtProdPrice.Name = "txtProdPrice";
            this.txtProdPrice.Size = new System.Drawing.Size(253, 20);
            this.txtProdPrice.TabIndex = 2;
            this.txtProdPrice.Text = "0";
            this.txtProdPrice.Validated += new System.EventHandler(this.txtProdPrice_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Supplier:";
            // 
            // cboSupps
            // 
            this.cboSupps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSupps.FormattingEnabled = true;
            this.cboSupps.Location = new System.Drawing.Point(95, 99);
            this.cboSupps.Name = "cboSupps";
            this.cboSupps.Size = new System.Drawing.Size(253, 21);
            this.cboSupps.TabIndex = 3;
            // 
            // Products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 183);
            this.Controls.Add(this.cboSupps);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtProdPrice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtProdDescr);
            this.Controls.Add(this.btnCreateSupplier);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtProdId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Products";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Products";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Products_FormClosing);
            this.Load += new System.EventHandler(this.Products_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateSupplier;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProdId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProdDescr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProdPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboSupps;
    }
}