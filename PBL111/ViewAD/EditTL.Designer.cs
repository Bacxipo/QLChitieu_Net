namespace PBL111.ViewAD
{
    partial class EditTL
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSAVE = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMT = new System.Windows.Forms.TextBox();
            this.txtTL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(361, 404);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(88, 42);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSAVE
            // 
            this.btnSAVE.Location = new System.Drawing.Point(177, 404);
            this.btnSAVE.Name = "btnSAVE";
            this.btnSAVE.Size = new System.Drawing.Size(88, 42);
            this.btnSAVE.TabIndex = 13;
            this.btnSAVE.Text = "Lưu";
            this.btnSAVE.UseVisualStyleBackColor = true;
            this.btnSAVE.Click += new System.EventHandler(this.btnSAVE_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(71, 279);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 23);
            this.label3.TabIndex = 11;
            this.label3.Text = "Mô Tả :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(47, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 23);
            this.label2.TabIndex = 10;
            this.label2.Text = "Tên Thể Loại Giao Dịch :";
            // 
            // txtMT
            // 
            this.txtMT.Location = new System.Drawing.Point(258, 279);
            this.txtMT.Name = "txtMT";
            this.txtMT.Size = new System.Drawing.Size(191, 22);
            this.txtMT.TabIndex = 8;
            // 
            // txtTL
            // 
            this.txtTL.Location = new System.Drawing.Point(258, 176);
            this.txtTL.Name = "txtTL";
            this.txtTL.Size = new System.Drawing.Size(191, 22);
            this.txtTL.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(139, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 38);
            this.label1.TabIndex = 7;
            this.label1.Text = "Sửa Thể Loại Giao Dịch";
            // 
            // EditTL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 540);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSAVE);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMT);
            this.Controls.Add(this.txtTL);
            this.Controls.Add(this.label1);
            this.Name = "EditTL";
            this.Text = "Chỉnh Sửa Thể Loại";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSAVE;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMT;
        private System.Windows.Forms.TextBox txtTL;
        private System.Windows.Forms.Label label1;
    }
}