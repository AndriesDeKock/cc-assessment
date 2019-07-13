namespace PO
{
    partial class SearchSuppliers
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
            this.dgvSupps = new System.Windows.Forms.DataGridView();
            this.btnNewSupp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupps)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSupps
            // 
            this.dgvSupps.AllowUserToAddRows = false;
            this.dgvSupps.AllowUserToDeleteRows = false;
            this.dgvSupps.AllowUserToResizeColumns = false;
            this.dgvSupps.AllowUserToResizeRows = false;
            this.dgvSupps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSupps.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvSupps.Location = new System.Drawing.Point(21, 24);
            this.dgvSupps.MultiSelect = false;
            this.dgvSupps.Name = "dgvSupps";
            this.dgvSupps.ReadOnly = true;
            this.dgvSupps.RowHeadersVisible = false;
            this.dgvSupps.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSupps.Size = new System.Drawing.Size(494, 213);
            this.dgvSupps.TabIndex = 0;
            this.dgvSupps.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSupps_CellContentClick);
            // 
            // btnNewSupp
            // 
            this.btnNewSupp.Location = new System.Drawing.Point(440, 243);
            this.btnNewSupp.Name = "btnNewSupp";
            this.btnNewSupp.Size = new System.Drawing.Size(75, 33);
            this.btnNewSupp.TabIndex = 1;
            this.btnNewSupp.Text = "New";
            this.btnNewSupp.UseVisualStyleBackColor = true;
            this.btnNewSupp.Click += new System.EventHandler(this.btnNewSupp_Click);
            // 
            // SearchSuppliers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 289);
            this.Controls.Add(this.btnNewSupp);
            this.Controls.Add(this.dgvSupps);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchSuppliers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search";
            this.Load += new System.EventHandler(this.SearchSuppliers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupps)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSupps;
        private System.Windows.Forms.Button btnNewSupp;
    }
}