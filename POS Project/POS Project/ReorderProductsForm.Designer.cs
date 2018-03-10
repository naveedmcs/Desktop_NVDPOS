namespace POS_Project
{
    partial class ReorderProductsFrom
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvReorderProducts = new System.Windows.Forms.DataGridView();
            this.btnProductPrintList = new System.Windows.Forms.Button();
            this.btnProductExportExcel = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.lblTotalProducts = new MonoFlat.MonoFlat_HeaderLabel();
            this.monoFlat_HeaderLabel10 = new MonoFlat.MonoFlat_HeaderLabel();
            this.panel23 = new System.Windows.Forms.Panel();
            this.iTalk_Separator2 = new iTalk.iTalk_Separator();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReorderProducts)).BeginInit();
            this.panel23.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlHeader.Location = new System.Drawing.Point(0, 528);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(875, 10);
            this.pnlHeader.TabIndex = 2;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Supplier Phone";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column11.Width = 170;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "Supplier Name";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn11.Width = 170;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Remaining Units";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn10.Width = 150;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Weight";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column8.Width = 120;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn9.HeaderText = "Product Name";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "Sr.No";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn12.Width = 80;
            // 
            // dgvReorderProducts
            // 
            this.dgvReorderProducts.AllowUserToAddRows = false;
            this.dgvReorderProducts.AllowUserToDeleteRows = false;
            this.dgvReorderProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReorderProducts.BackgroundColor = System.Drawing.Color.Silver;
            this.dgvReorderProducts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvReorderProducts.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReorderProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReorderProducts.ColumnHeadersHeight = 30;
            this.dgvReorderProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvReorderProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn9,
            this.Column8,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.Column11});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReorderProducts.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReorderProducts.Location = new System.Drawing.Point(12, 131);
            this.dgvReorderProducts.MultiSelect = false;
            this.dgvReorderProducts.Name = "dgvReorderProducts";
            this.dgvReorderProducts.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReorderProducts.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvReorderProducts.RowHeadersVisible = false;
            this.dgvReorderProducts.RowHeadersWidth = 177;
            this.dgvReorderProducts.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(3);
            this.dgvReorderProducts.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvReorderProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReorderProducts.Size = new System.Drawing.Size(851, 386);
            this.dgvReorderProducts.TabIndex = 3;
            // 
            // btnProductPrintList
            // 
            this.btnProductPrintList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(181)))), ((int)(((byte)(158)))));
            this.btnProductPrintList.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(181)))), ((int)(((byte)(158)))));
            this.btnProductPrintList.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(114)))));
            this.btnProductPrintList.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(196)))), ((int)(((byte)(172)))));
            this.btnProductPrintList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductPrintList.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductPrintList.ForeColor = System.Drawing.Color.White;
            this.btnProductPrintList.Image = global::POS_Project.Properties.Resources.symbol1;
            this.btnProductPrintList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductPrintList.Location = new System.Drawing.Point(12, 92);
            this.btnProductPrintList.Name = "btnProductPrintList";
            this.btnProductPrintList.Size = new System.Drawing.Size(167, 33);
            this.btnProductPrintList.TabIndex = 4;
            this.btnProductPrintList.Text = "&Print Product List";
            this.btnProductPrintList.UseVisualStyleBackColor = false;
            // 
            // btnProductExportExcel
            // 
            this.btnProductExportExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(181)))), ((int)(((byte)(158)))));
            this.btnProductExportExcel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(181)))), ((int)(((byte)(158)))));
            this.btnProductExportExcel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(196)))), ((int)(((byte)(172)))));
            this.btnProductExportExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(114)))));
            this.btnProductExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductExportExcel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductExportExcel.ForeColor = System.Drawing.Color.White;
            this.btnProductExportExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductExportExcel.Location = new System.Drawing.Point(185, 92);
            this.btnProductExportExcel.Name = "btnProductExportExcel";
            this.btnProductExportExcel.Size = new System.Drawing.Size(148, 33);
            this.btnProductExportExcel.TabIndex = 5;
            this.btnProductExportExcel.Text = " &Export to Excel";
            this.btnProductExportExcel.UseVisualStyleBackColor = false;
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackgroundImage = global::POS_Project.Properties.Resources.darkminimizedefualt;
            this.btnMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMinimize.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Location = new System.Drawing.Point(815, 8);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Padding = new System.Windows.Forms.Padding(5);
            this.btnMinimize.Size = new System.Drawing.Size(35, 35);
            this.btnMinimize.TabIndex = 0;
            this.btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // lblTotalProducts
            // 
            this.lblTotalProducts.BackColor = System.Drawing.Color.Gray;
            this.lblTotalProducts.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalProducts.ForeColor = System.Drawing.Color.White;
            this.lblTotalProducts.Location = new System.Drawing.Point(12, 9);
            this.lblTotalProducts.Name = "lblTotalProducts";
            this.lblTotalProducts.Size = new System.Drawing.Size(80, 30);
            this.lblTotalProducts.TabIndex = 34;
            this.lblTotalProducts.Text = "0000";
            this.lblTotalProducts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // monoFlat_HeaderLabel10
            // 
            this.monoFlat_HeaderLabel10.AutoSize = true;
            this.monoFlat_HeaderLabel10.BackColor = System.Drawing.Color.Transparent;
            this.monoFlat_HeaderLabel10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monoFlat_HeaderLabel10.ForeColor = System.Drawing.Color.RoyalBlue;
            this.monoFlat_HeaderLabel10.Location = new System.Drawing.Point(337, 13);
            this.monoFlat_HeaderLabel10.Name = "monoFlat_HeaderLabel10";
            this.monoFlat_HeaderLabel10.Size = new System.Drawing.Size(229, 21);
            this.monoFlat_HeaderLabel10.TabIndex = 2;
            this.monoFlat_HeaderLabel10.Text = "LIST OF REORDER PRODUCTS";
            // 
            // panel23
            // 
            this.panel23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(201)))), ((int)(((byte)(190)))));
            this.panel23.Controls.Add(this.monoFlat_HeaderLabel10);
            this.panel23.Controls.Add(this.lblTotalProducts);
            this.panel23.Controls.Add(this.btnMinimize);
            this.panel23.Location = new System.Drawing.Point(12, 16);
            this.panel23.Name = "panel23";
            this.panel23.Size = new System.Drawing.Size(862, 49);
            this.panel23.TabIndex = 26;
            // 
            // iTalk_Separator2
            // 
            this.iTalk_Separator2.Location = new System.Drawing.Point(12, 71);
            this.iTalk_Separator2.Name = "iTalk_Separator2";
            this.iTalk_Separator2.Size = new System.Drawing.Size(862, 10);
            this.iTalk_Separator2.TabIndex = 35;
            this.iTalk_Separator2.Text = "iTalk_Separator2";
            // 
            // ReorderProductsFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 538);
            this.Controls.Add(this.iTalk_Separator2);
            this.Controls.Add(this.panel23);
            this.Controls.Add(this.btnProductExportExcel);
            this.Controls.Add(this.btnProductPrintList);
            this.Controls.Add(this.dgvReorderProducts);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReorderProductsFrom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReorderProductsFrom";
            this.Load += new System.EventHandler(this.ReorderProductsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReorderProducts)).EndInit();
            this.panel23.ResumeLayout(false);
            this.panel23.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridView dgvReorderProducts;
        private System.Windows.Forms.Button btnProductPrintList;
        private System.Windows.Forms.Button btnProductExportExcel;
        private System.Windows.Forms.Button btnMinimize;
        private MonoFlat.MonoFlat_HeaderLabel lblTotalProducts;
        private MonoFlat.MonoFlat_HeaderLabel monoFlat_HeaderLabel10;
        private System.Windows.Forms.Panel panel23;
        private iTalk.iTalk_Separator iTalk_Separator2;
    }
}