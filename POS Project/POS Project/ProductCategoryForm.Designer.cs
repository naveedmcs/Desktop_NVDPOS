namespace POS_Project
{
    partial class ProductCategoryForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel28 = new System.Windows.Forms.Panel();
            this.txtCategorySearch = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.dgvCategories = new System.Windows.Forms.DataGridView();
            this.panel26 = new System.Windows.Forms.Panel();
            this.label35 = new System.Windows.Forms.Label();
            this.txtCategoryComments = new System.Windows.Forms.TextBox();
            this.btnPreviusCategory = new System.Windows.Forms.Button();
            this.btnCategoryDelete = new System.Windows.Forms.Button();
            this.btnCategoryUpdate = new System.Windows.Forms.Button();
            this.btnCategorySave = new System.Windows.Forms.Button();
            this.txtProductCategory = new System.Windows.Forms.Label();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.lbCategoryId = new System.Windows.Forms.Label();
            this.txtCategoryID = new System.Windows.Forms.TextBox();
            this.panel27 = new System.Windows.Forms.Panel();
            this.btnCategoryAddNew = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.iTalk_Separator11 = new iTalk.iTalk_Separator();
            this.lblTotalCategories = new MonoFlat.MonoFlat_HeaderLabel();
            this.monoFlat_HeaderLabel15 = new MonoFlat.MonoFlat_HeaderLabel();
            this.iTalk_Separator10 = new iTalk.iTalk_Separator();
            this.monoFlat_HeaderLabel13 = new MonoFlat.MonoFlat_HeaderLabel();
            this.CategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel28.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();
            this.panel26.SuspendLayout();
            this.panel27.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel26);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(934, 406);
            this.panel1.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(226)))), ((int)(((byte)(211)))));
            this.panel3.Controls.Add(this.iTalk_Separator11);
            this.panel3.Controls.Add(this.panel28);
            this.panel3.Controls.Add(this.dgvCategories);
            this.panel3.Location = new System.Drawing.Point(392, 66);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(532, 329);
            this.panel3.TabIndex = 7;
            // 
            // panel28
            // 
            this.panel28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(201)))), ((int)(((byte)(190)))));
            this.panel28.Controls.Add(this.lblTotalCategories);
            this.panel28.Controls.Add(this.monoFlat_HeaderLabel15);
            this.panel28.Controls.Add(this.txtCategorySearch);
            this.panel28.Controls.Add(this.label30);
            this.panel28.Location = new System.Drawing.Point(11, 11);
            this.panel28.Name = "panel28";
            this.panel28.Size = new System.Drawing.Size(506, 44);
            this.panel28.TabIndex = 63;
            // 
            // txtCategorySearch
            // 
            this.txtCategorySearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategorySearch.Location = new System.Drawing.Point(367, 11);
            this.txtCategorySearch.Name = "txtCategorySearch";
            this.txtCategorySearch.Size = new System.Drawing.Size(130, 22);
            this.txtCategorySearch.TabIndex = 1;
            this.txtCategorySearch.TextChanged += new System.EventHandler(this.txtCategorySearch_TextChanged);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.Gray;
            this.label30.Location = new System.Drawing.Point(308, 15);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(53, 16);
            this.label30.TabIndex = 23;
            this.label30.Text = "Search";
            // 
            // dgvCategories
            // 
            this.dgvCategories.AllowUserToAddRows = false;
            this.dgvCategories.AllowUserToDeleteRows = false;
            this.dgvCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCategories.BackgroundColor = System.Drawing.Color.Silver;
            this.dgvCategories.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCategories.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCategories.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCategories.ColumnHeadersHeight = 30;
            this.dgvCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCategories.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CategoryName,
            this.dataGridViewTextBoxColumn21});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCategories.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCategories.Location = new System.Drawing.Point(11, 90);
            this.dgvCategories.MultiSelect = false;
            this.dgvCategories.Name = "dgvCategories";
            this.dgvCategories.ReadOnly = true;
            this.dgvCategories.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCategories.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCategories.RowHeadersVisible = false;
            this.dgvCategories.RowHeadersWidth = 177;
            this.dgvCategories.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(3);
            this.dgvCategories.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategories.Size = new System.Drawing.Size(506, 222);
            this.dgvCategories.TabIndex = 62;
            this.dgvCategories.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategories_CellClick);
            // 
            // panel26
            // 
            this.panel26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(226)))), ((int)(((byte)(211)))));
            this.panel26.Controls.Add(this.label35);
            this.panel26.Controls.Add(this.txtCategoryComments);
            this.panel26.Controls.Add(this.btnPreviusCategory);
            this.panel26.Controls.Add(this.btnCategoryDelete);
            this.panel26.Controls.Add(this.btnCategoryUpdate);
            this.panel26.Controls.Add(this.btnCategorySave);
            this.panel26.Controls.Add(this.txtProductCategory);
            this.panel26.Controls.Add(this.txtCategoryName);
            this.panel26.Controls.Add(this.lbCategoryId);
            this.panel26.Controls.Add(this.txtCategoryID);
            this.panel26.Controls.Add(this.iTalk_Separator10);
            this.panel26.Controls.Add(this.panel27);
            this.panel26.Location = new System.Drawing.Point(9, 66);
            this.panel26.Margin = new System.Windows.Forms.Padding(0);
            this.panel26.Name = "panel26";
            this.panel26.Size = new System.Drawing.Size(380, 329);
            this.panel26.TabIndex = 6;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.ForeColor = System.Drawing.Color.Gray;
            this.label35.Location = new System.Drawing.Point(12, 173);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(75, 16);
            this.label35.TabIndex = 63;
            this.label35.Text = "Comments";
            // 
            // txtCategoryComments
            // 
            this.txtCategoryComments.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategoryComments.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCategoryComments.Location = new System.Drawing.Point(12, 192);
            this.txtCategoryComments.Multiline = true;
            this.txtCategoryComments.Name = "txtCategoryComments";
            this.txtCategoryComments.Size = new System.Drawing.Size(356, 41);
            this.txtCategoryComments.TabIndex = 64;
            // 
            // btnPreviusCategory
            // 
            this.btnPreviusCategory.BackColor = System.Drawing.Color.Transparent;
            this.btnPreviusCategory.BackgroundImage = global::POS_Project.Properties.Resources.previous1;
            this.btnPreviusCategory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPreviusCategory.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnPreviusCategory.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnPreviusCategory.FlatAppearance.BorderSize = 0;
            this.btnPreviusCategory.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPreviusCategory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPreviusCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreviusCategory.ForeColor = System.Drawing.Color.Transparent;
            this.btnPreviusCategory.Location = new System.Drawing.Point(14, 549);
            this.btnPreviusCategory.Name = "btnPreviusCategory";
            this.btnPreviusCategory.Padding = new System.Windows.Forms.Padding(5);
            this.btnPreviusCategory.Size = new System.Drawing.Size(35, 35);
            this.btnPreviusCategory.TabIndex = 62;
            this.btnPreviusCategory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPreviusCategory.UseVisualStyleBackColor = false;
            // 
            // btnCategoryDelete
            // 
            this.btnCategoryDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(59)))), ((int)(((byte)(44)))));
            this.btnCategoryDelete.FlatAppearance.BorderColor = System.Drawing.Color.Crimson;
            this.btnCategoryDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Firebrick;
            this.btnCategoryDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(76)))), ((int)(((byte)(61)))));
            this.btnCategoryDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategoryDelete.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategoryDelete.ForeColor = System.Drawing.Color.White;
            this.btnCategoryDelete.Image = global::POS_Project.Properties.Resources.delete;
            this.btnCategoryDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategoryDelete.Location = new System.Drawing.Point(186, 279);
            this.btnCategoryDelete.Name = "btnCategoryDelete";
            this.btnCategoryDelete.Size = new System.Drawing.Size(89, 33);
            this.btnCategoryDelete.TabIndex = 59;
            this.btnCategoryDelete.Text = "  Delete";
            this.btnCategoryDelete.UseVisualStyleBackColor = false;
            this.btnCategoryDelete.Click += new System.EventHandler(this.btnCategoryDelete_Click);
            // 
            // btnCategoryUpdate
            // 
            this.btnCategoryUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(127)))), ((int)(((byte)(34)))));
            this.btnCategoryUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this.btnCategoryUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrange;
            this.btnCategoryUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Goldenrod;
            this.btnCategoryUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategoryUpdate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategoryUpdate.ForeColor = System.Drawing.Color.White;
            this.btnCategoryUpdate.Image = global::POS_Project.Properties.Resources.edit_;
            this.btnCategoryUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategoryUpdate.Location = new System.Drawing.Point(281, 279);
            this.btnCategoryUpdate.Name = "btnCategoryUpdate";
            this.btnCategoryUpdate.Size = new System.Drawing.Size(89, 33);
            this.btnCategoryUpdate.TabIndex = 58;
            this.btnCategoryUpdate.Text = "  Update ";
            this.btnCategoryUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCategoryUpdate.UseVisualStyleBackColor = false;
            this.btnCategoryUpdate.Click += new System.EventHandler(this.btnCategoryUpdate_Click);
            // 
            // btnCategorySave
            // 
            this.btnCategorySave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(171)))), ((int)(((byte)(79)))));
            this.btnCategorySave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(187)))), ((int)(((byte)(95)))));
            this.btnCategorySave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(65)))));
            this.btnCategorySave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(187)))), ((int)(((byte)(95)))));
            this.btnCategorySave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategorySave.ForeColor = System.Drawing.Color.White;
            this.btnCategorySave.Image = global::POS_Project.Properties.Resources.savebutton;
            this.btnCategorySave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategorySave.Location = new System.Drawing.Point(14, 279);
            this.btnCategorySave.Name = "btnCategorySave";
            this.btnCategorySave.Size = new System.Drawing.Size(86, 33);
            this.btnCategorySave.TabIndex = 57;
            this.btnCategorySave.Text = "  Save ";
            this.btnCategorySave.UseVisualStyleBackColor = false;
            this.btnCategorySave.Click += new System.EventHandler(this.btnCategorySave_Click);
            // 
            // txtProductCategory
            // 
            this.txtProductCategory.AutoSize = true;
            this.txtProductCategory.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductCategory.ForeColor = System.Drawing.Color.Gray;
            this.txtProductCategory.Location = new System.Drawing.Point(12, 90);
            this.txtProductCategory.Name = "txtProductCategory";
            this.txtProductCategory.Size = new System.Drawing.Size(106, 16);
            this.txtProductCategory.TabIndex = 43;
            this.txtProductCategory.Text = "Category Name";
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategoryName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCategoryName.Location = new System.Drawing.Point(15, 109);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(175, 22);
            this.txtCategoryName.TabIndex = 42;
            // 
            // lbCategoryId
            // 
            this.lbCategoryId.AutoSize = true;
            this.lbCategoryId.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCategoryId.ForeColor = System.Drawing.Color.Gray;
            this.lbCategoryId.Location = new System.Drawing.Point(278, 90);
            this.lbCategoryId.Name = "lbCategoryId";
            this.lbCategoryId.Size = new System.Drawing.Size(82, 16);
            this.lbCategoryId.TabIndex = 41;
            this.lbCategoryId.Text = "Category ID";
            // 
            // txtCategoryID
            // 
            this.txtCategoryID.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategoryID.Location = new System.Drawing.Point(280, 109);
            this.txtCategoryID.Name = "txtCategoryID";
            this.txtCategoryID.ReadOnly = true;
            this.txtCategoryID.Size = new System.Drawing.Size(88, 22);
            this.txtCategoryID.TabIndex = 40;
            // 
            // panel27
            // 
            this.panel27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(201)))), ((int)(((byte)(190)))));
            this.panel27.Controls.Add(this.btnCategoryAddNew);
            this.panel27.Controls.Add(this.monoFlat_HeaderLabel13);
            this.panel27.Location = new System.Drawing.Point(15, 11);
            this.panel27.Name = "panel27";
            this.panel27.Size = new System.Drawing.Size(355, 44);
            this.panel27.TabIndex = 34;
            // 
            // btnCategoryAddNew
            // 
            this.btnCategoryAddNew.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnCategoryAddNew.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnCategoryAddNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue;
            this.btnCategoryAddNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.btnCategoryAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategoryAddNew.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategoryAddNew.ForeColor = System.Drawing.Color.White;
            this.btnCategoryAddNew.Image = global::POS_Project.Properties.Resources.addnew;
            this.btnCategoryAddNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategoryAddNew.Location = new System.Drawing.Point(12, 7);
            this.btnCategoryAddNew.Name = "btnCategoryAddNew";
            this.btnCategoryAddNew.Size = new System.Drawing.Size(102, 30);
            this.btnCategoryAddNew.TabIndex = 0;
            this.btnCategoryAddNew.Text = "    Add New ";
            this.btnCategoryAddNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCategoryAddNew.UseVisualStyleBackColor = false;
            this.btnCategoryAddNew.Click += new System.EventHandler(this.btnCategoryAddNew_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel2.Controls.Add(this.lblHeader);
            this.panel2.Controls.Add(this.btnMinimize);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(934, 58);
            this.panel2.TabIndex = 8;
            // 
            // lblHeader
            // 
            this.lblHeader.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(12, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.lblHeader.Size = new System.Drawing.Size(367, 38);
            this.lblHeader.TabIndex = 8;
            this.lblHeader.Text = "Product Categories";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.btnMinimize.Location = new System.Drawing.Point(889, 9);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Padding = new System.Windows.Forms.Padding(5);
            this.btnMinimize.Size = new System.Drawing.Size(35, 35);
            this.btnMinimize.TabIndex = 1;
            this.btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // iTalk_Separator11
            // 
            this.iTalk_Separator11.Location = new System.Drawing.Point(11, 57);
            this.iTalk_Separator11.Name = "iTalk_Separator11";
            this.iTalk_Separator11.Size = new System.Drawing.Size(506, 12);
            this.iTalk_Separator11.TabIndex = 64;
            this.iTalk_Separator11.Text = "iTalk_Separator11";
            // 
            // lblTotalCategories
            // 
            this.lblTotalCategories.BackColor = System.Drawing.Color.Gray;
            this.lblTotalCategories.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalCategories.ForeColor = System.Drawing.Color.White;
            this.lblTotalCategories.Location = new System.Drawing.Point(8, 7);
            this.lblTotalCategories.Name = "lblTotalCategories";
            this.lblTotalCategories.Size = new System.Drawing.Size(68, 30);
            this.lblTotalCategories.TabIndex = 0;
            this.lblTotalCategories.Text = "0000";
            this.lblTotalCategories.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // monoFlat_HeaderLabel15
            // 
            this.monoFlat_HeaderLabel15.AutoSize = true;
            this.monoFlat_HeaderLabel15.BackColor = System.Drawing.Color.Transparent;
            this.monoFlat_HeaderLabel15.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.monoFlat_HeaderLabel15.ForeColor = System.Drawing.Color.RoyalBlue;
            this.monoFlat_HeaderLabel15.Location = new System.Drawing.Point(82, 13);
            this.monoFlat_HeaderLabel15.Name = "monoFlat_HeaderLabel15";
            this.monoFlat_HeaderLabel15.Size = new System.Drawing.Size(155, 20);
            this.monoFlat_HeaderLabel15.TabIndex = 24;
            this.monoFlat_HeaderLabel15.Text = "LIST OF CATEGORIES";
            // 
            // iTalk_Separator10
            // 
            this.iTalk_Separator10.Location = new System.Drawing.Point(15, 58);
            this.iTalk_Separator10.Name = "iTalk_Separator10";
            this.iTalk_Separator10.Size = new System.Drawing.Size(355, 10);
            this.iTalk_Separator10.TabIndex = 35;
            this.iTalk_Separator10.Text = "iTalk_Separator10";
            // 
            // monoFlat_HeaderLabel13
            // 
            this.monoFlat_HeaderLabel13.AutoSize = true;
            this.monoFlat_HeaderLabel13.BackColor = System.Drawing.Color.Transparent;
            this.monoFlat_HeaderLabel13.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.monoFlat_HeaderLabel13.ForeColor = System.Drawing.Color.RoyalBlue;
            this.monoFlat_HeaderLabel13.Location = new System.Drawing.Point(120, 13);
            this.monoFlat_HeaderLabel13.Name = "monoFlat_HeaderLabel13";
            this.monoFlat_HeaderLabel13.Size = new System.Drawing.Size(197, 20);
            this.monoFlat_HeaderLabel13.TabIndex = 2;
            this.monoFlat_HeaderLabel13.Text = "CATEGORY INFORMATION";
            // 
            // CategoryName
            // 
            this.CategoryName.HeaderText = "Category Name";
            this.CategoryName.Name = "CategoryName";
            this.CategoryName.ReadOnly = true;
            this.CategoryName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CategoryName.Width = 130;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn21.HeaderText = "Comments";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.ReadOnly = true;
            this.dataGridViewTextBoxColumn21.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ProductCategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(934, 406);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProductCategoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProductCategoryForm";
            this.Load += new System.EventHandler(this.ProductCategoryForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel28.ResumeLayout(false);
            this.panel28.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).EndInit();
            this.panel26.ResumeLayout(false);
            this.panel26.PerformLayout();
            this.panel27.ResumeLayout(false);
            this.panel27.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private iTalk.iTalk_Separator iTalk_Separator11;
        private System.Windows.Forms.Panel panel28;
        private MonoFlat.MonoFlat_HeaderLabel lblTotalCategories;
        private MonoFlat.MonoFlat_HeaderLabel monoFlat_HeaderLabel15;
        private System.Windows.Forms.TextBox txtCategorySearch;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.DataGridView dgvCategories;
        private System.Windows.Forms.Panel panel26;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox txtCategoryComments;
        private System.Windows.Forms.Button btnPreviusCategory;
        private System.Windows.Forms.Button btnCategoryDelete;
        private System.Windows.Forms.Button btnCategoryUpdate;
        private System.Windows.Forms.Button btnCategorySave;
        private System.Windows.Forms.Label txtProductCategory;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.Label lbCategoryId;
        private System.Windows.Forms.TextBox txtCategoryID;
        private iTalk.iTalk_Separator iTalk_Separator10;
        private System.Windows.Forms.Panel panel27;
        private System.Windows.Forms.Button btnCategoryAddNew;
        private MonoFlat.MonoFlat_HeaderLabel monoFlat_HeaderLabel13;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
    }
}