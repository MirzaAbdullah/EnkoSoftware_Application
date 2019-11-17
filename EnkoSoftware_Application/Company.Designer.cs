namespace EnkoSoftware_Application
{
    partial class Company
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
            this.btnAddAddress = new System.Windows.Forms.Button();
            this.grdCompanyManagement = new System.Windows.Forms.DataGridView();
            this.lblMain = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdCompanyManagement)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddAddress
            // 
            this.btnAddAddress.Location = new System.Drawing.Point(712, 397);
            this.btnAddAddress.Name = "btnAddAddress";
            this.btnAddAddress.Size = new System.Drawing.Size(75, 23);
            this.btnAddAddress.TabIndex = 5;
            this.btnAddAddress.Text = "Add Address";
            this.btnAddAddress.UseVisualStyleBackColor = true;
            this.btnAddAddress.Click += new System.EventHandler(this.btnAddAddress_Click);
            // 
            // grdCompanyManagement
            // 
            this.grdCompanyManagement.AllowUserToAddRows = false;
            this.grdCompanyManagement.AllowUserToDeleteRows = false;
            this.grdCompanyManagement.AllowUserToOrderColumns = true;
            this.grdCompanyManagement.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdCompanyManagement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCompanyManagement.Location = new System.Drawing.Point(12, 76);
            this.grdCompanyManagement.Name = "grdCompanyManagement";
            this.grdCompanyManagement.ReadOnly = true;
            this.grdCompanyManagement.Size = new System.Drawing.Size(776, 315);
            this.grdCompanyManagement.TabIndex = 4;
            this.grdCompanyManagement.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCompanyManagement_CellDoubleClick);
            // 
            // lblMain
            // 
            this.lblMain.AutoSize = true;
            this.lblMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMain.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblMain.Location = new System.Drawing.Point(13, 30);
            this.lblMain.Name = "lblMain";
            this.lblMain.Size = new System.Drawing.Size(234, 25);
            this.lblMain.TabIndex = 3;
            this.lblMain.Text = "Company Management";
            // 
            // Company
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAddAddress);
            this.Controls.Add(this.grdCompanyManagement);
            this.Controls.Add(this.lblMain);
            this.Name = "Company";
            this.Text = "Company";
            this.Load += new System.EventHandler(this.Company_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdCompanyManagement)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddAddress;
        private System.Windows.Forms.DataGridView grdCompanyManagement;
        private System.Windows.Forms.Label lblMain;
    }
}