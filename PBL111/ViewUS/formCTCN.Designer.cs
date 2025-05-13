namespace PBL111.View
{
    partial class formCTCN
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
            this.dgvGD = new System.Windows.Forms.DataGridView();
            this.lbTCT = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnMainUS = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbDate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbnameUS = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpBD = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpKT = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGD)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvGD
            // 
            this.dgvGD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGD.Location = new System.Drawing.Point(24, 180);
            this.dgvGD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvGD.Name = "dgvGD";
            this.dgvGD.RowHeadersWidth = 51;
            this.dgvGD.RowTemplate.Height = 24;
            this.dgvGD.Size = new System.Drawing.Size(901, 318);
            this.dgvGD.TabIndex = 21;
            // 
            // lbTCT
            // 
            this.lbTCT.AutoSize = true;
            this.lbTCT.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbTCT.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTCT.Location = new System.Drawing.Point(45, 52);
            this.lbTCT.Name = "lbTCT";
            this.lbTCT.Size = new System.Drawing.Size(48, 20);
            this.lbTCT.TabIndex = 3;
            this.lbTCT.Text = "label6";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tổng chi tiêu tháng :";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.lbTCT);
            this.panel3.Location = new System.Drawing.Point(24, 63);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(323, 86);
            this.panel3.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 23);
            this.label4.TabIndex = 22;
            this.label4.Text = "Giao dịch: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.CausesValidation = false;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(427, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 23);
            this.label5.TabIndex = 24;
            this.label5.Text = "Tìm kiếm giao dịch :";
            // 
            // btnAdd
            // 
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(121, 508);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 39);
            this.btnAdd.TabIndex = 25;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(379, 508);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(93, 39);
            this.btnEdit.TabIndex = 26;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(647, 508);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(86, 39);
            this.btnDelete.TabIndex = 27;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnMainUS
            // 
            this.btnMainUS.Location = new System.Drawing.Point(813, 509);
            this.btnMainUS.Name = "btnMainUS";
            this.btnMainUS.Size = new System.Drawing.Size(112, 39);
            this.btnMainUS.TabIndex = 29;
            this.btnMainUS.Text = "Trang chủ";
            this.btnMainUS.UseVisualStyleBackColor = true;
            this.btnMainUS.Click += new System.EventHandler(this.btnMainUS_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.lbDate);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lbnameUS);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(-7, -5);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(973, 50);
            this.panel2.TabIndex = 10;
            // 
            // lbDate
            // 
            this.lbDate.AutoSize = true;
            this.lbDate.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDate.Location = new System.Drawing.Point(831, 12);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(53, 23);
            this.lbDate.TabIndex = 3;
            this.lbDate.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(699, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hôm nay là :";
            // 
            // lbnameUS
            // 
            this.lbnameUS.AutoSize = true;
            this.lbnameUS.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbnameUS.Location = new System.Drawing.Point(104, 12);
            this.lbnameUS.Name = "lbnameUS";
            this.lbnameUS.Size = new System.Drawing.Size(53, 23);
            this.lbnameUS.TabIndex = 1;
            this.lbnameUS.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Xin Chào,";
            // 
            // dtpBD
            // 
            this.dtpBD.Location = new System.Drawing.Point(525, 90);
            this.dtpBD.Name = "dtpBD";
            this.dtpBD.Size = new System.Drawing.Size(249, 22);
            this.dtpBD.TabIndex = 30;
            this.dtpBD.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(828, 102);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 31;
            this.button1.Text = "Tìm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(428, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 20);
            this.label6.TabIndex = 32;
            this.label6.Text = "Từ ngày :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(428, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 20);
            this.label7.TabIndex = 33;
            this.label7.Text = "Đến ngày :";
            // 
            // dtpKT
            // 
            this.dtpKT.Location = new System.Drawing.Point(525, 130);
            this.dtpKT.Name = "dtpKT";
            this.dtpKT.Size = new System.Drawing.Size(249, 22);
            this.dtpKT.TabIndex = 34;
            // 
            // formCTCN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 559);
            this.Controls.Add(this.dtpKT);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtpBD);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnMainUS);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.dgvGD);
            this.Name = "formCTCN";
            this.Text = "Chi Tiêu Cá Nhân";
            ((System.ComponentModel.ISupportInitialize)(this.dgvGD)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGD;
        private System.Windows.Forms.Label lbTCT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnMainUS;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbnameUS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpBD;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpKT;
    }
}