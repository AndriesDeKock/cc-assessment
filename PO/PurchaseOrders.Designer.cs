namespace PO
{
    partial class PurchaseOrders
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtPODescr = new System.Windows.Forms.TextBox();
            this.btnCreatePO = new System.Windows.Forms.Button();
            this.lstPOItems = new System.Windows.Forms.ListBox();
            this.btnAddProdItem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboProds = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtqty = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Description:";
            // 
            // txtPODescr
            // 
            this.txtPODescr.Location = new System.Drawing.Point(93, 24);
            this.txtPODescr.MaxLength = 250;
            this.txtPODescr.Name = "txtPODescr";
            this.txtPODescr.Size = new System.Drawing.Size(253, 20);
            this.txtPODescr.TabIndex = 13;
            // 
            // btnCreatePO
            // 
            this.btnCreatePO.Location = new System.Drawing.Point(271, 267);
            this.btnCreatePO.Name = "btnCreatePO";
            this.btnCreatePO.Size = new System.Drawing.Size(75, 23);
            this.btnCreatePO.TabIndex = 16;
            this.btnCreatePO.Text = "Save";
            this.btnCreatePO.UseVisualStyleBackColor = true;
            this.btnCreatePO.Click += new System.EventHandler(this.btnCreatePO_Click);
            // 
            // lstPOItems
            // 
            this.lstPOItems.FormattingEnabled = true;
            this.lstPOItems.Location = new System.Drawing.Point(93, 128);
            this.lstPOItems.Name = "lstPOItems";
            this.lstPOItems.Size = new System.Drawing.Size(253, 121);
            this.lstPOItems.TabIndex = 21;
            // 
            // btnAddProdItem
            // 
            this.btnAddProdItem.Location = new System.Drawing.Point(271, 76);
            this.btnAddProdItem.Name = "btnAddProdItem";
            this.btnAddProdItem.Size = new System.Drawing.Size(75, 23);
            this.btnAddProdItem.TabIndex = 22;
            this.btnAddProdItem.Text = "Add";
            this.btnAddProdItem.UseVisualStyleBackColor = true;
            this.btnAddProdItem.Click += new System.EventHandler(this.btnAddProdItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Products:";
            // 
            // cboProds
            // 
            this.cboProds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProds.FormattingEnabled = true;
            this.cboProds.Location = new System.Drawing.Point(93, 50);
            this.cboProds.Name = "cboProds";
            this.cboProds.Size = new System.Drawing.Size(253, 21);
            this.cboProds.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Items:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Qty:";
            // 
            // txtqty
            // 
            this.txtqty.Location = new System.Drawing.Point(93, 77);
            this.txtqty.MaxLength = 250;
            this.txtqty.Name = "txtqty";
            this.txtqty.Size = new System.Drawing.Size(172, 20);
            this.txtqty.TabIndex = 26;
            this.txtqty.Text = "1";
            this.txtqty.Validated += new System.EventHandler(this.txtqty_Validated);
            // 
            // PurchaseOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 308);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtqty);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboProds);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddProdItem);
            this.Controls.Add(this.lstPOItems);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPODescr);
            this.Controls.Add(this.btnCreatePO);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PurchaseOrders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Purchase Order";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PurchaseOrders_FormClosing);
            this.Load += new System.EventHandler(this.PurchaseOrders_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPODescr;
        private System.Windows.Forms.Button btnCreatePO;
        private System.Windows.Forms.ListBox lstPOItems;
        private System.Windows.Forms.Button btnAddProdItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboProds;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtqty;
    }
}