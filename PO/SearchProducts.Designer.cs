namespace PO
{
    partial class SearchProducts
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
            this.btnNewSupp = new System.Windows.Forms.Button();
            this.dgvProds = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProds)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNewSupp
            // 
            this.btnNewSupp.Location = new System.Drawing.Point(697, 242);
            this.btnNewSupp.Name = "btnNewSupp";
            this.btnNewSupp.Size = new System.Drawing.Size(75, 33);
            this.btnNewSupp.TabIndex = 3;
            this.btnNewSupp.Text = "New";
            this.btnNewSupp.UseVisualStyleBackColor = true;
            this.btnNewSupp.Click += new System.EventHandler(this.btnNewSupp_Click);
            // 
            // dgvProds
            // 
            this.dgvProds.AllowUserToAddRows = false;
            this.dgvProds.AllowUserToDeleteRows = false;
            this.dgvProds.AllowUserToResizeColumns = false;
            this.dgvProds.AllowUserToResizeRows = false;
            this.dgvProds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProds.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvProds.Location = new System.Drawing.Point(21, 23);
            this.dgvProds.MultiSelect = false;
            this.dgvProds.Name = "dgvProds";
            this.dgvProds.ReadOnly = true;
            this.dgvProds.RowHeadersVisible = false;
            this.dgvProds.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProds.Size = new System.Drawing.Size(751, 213);
            this.dgvProds.TabIndex = 2;
            this.dgvProds.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProds_CellContentClick);
            // 
            // SearchProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 291);
            this.Controls.Add(this.btnNewSupp);
            this.Controls.Add(this.dgvProds);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchProducts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search";
            this.Load += new System.EventHandler(this.SearchProducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProds)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNewSupp;
        private System.Windows.Forms.DataGridView dgvProds;
    }
}