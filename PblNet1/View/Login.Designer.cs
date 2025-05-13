
namespace PblNet1
{
    partial class Login
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtUS = new System.Windows.Forms.TextBox();
            this.txtPW = new System.Windows.Forms.TextBox();
            this.btnDN = new System.Windows.Forms.Button();
            this.btnDK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FloralWhite;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(889, 294);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tài Khoản:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FloralWhite;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(889, 379);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 27);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mật Khẩu:";
            // 
            // txtUS
            // 
            this.txtUS.Location = new System.Drawing.Point(1084, 294);
            this.txtUS.Name = "txtUS";
            this.txtUS.Size = new System.Drawing.Size(187, 22);
            this.txtUS.TabIndex = 4;
            // 
            // txtPW
            // 
            this.txtPW.Location = new System.Drawing.Point(1084, 379);
            this.txtPW.Name = "txtPW";
            this.txtPW.Size = new System.Drawing.Size(187, 22);
            this.txtPW.TabIndex = 5;
            // 
            // btnDN
            // 
            this.btnDN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnDN.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDN.ForeColor = System.Drawing.Color.Black;
            this.btnDN.Location = new System.Drawing.Point(993, 487);
            this.btnDN.Name = "btnDN";
            this.btnDN.Size = new System.Drawing.Size(106, 33);
            this.btnDN.TabIndex = 6;
            this.btnDN.Text = "Đăng Nhập";
            this.btnDN.UseVisualStyleBackColor = false;
            this.btnDN.Click += new System.EventHandler(this.btnDN_Click);
            // 
            // btnDK
            // 
            this.btnDK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDK.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDK.Location = new System.Drawing.Point(1154, 487);
            this.btnDK.Name = "btnDK";
            this.btnDK.Size = new System.Drawing.Size(107, 33);
            this.btnDK.TabIndex = 7;
            this.btnDK.Text = "Đăng ký";
            this.btnDK.UseVisualStyleBackColor = false;
            this.btnDK.Click += new System.EventHandler(this.btnDK_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PblNet1.Properties.Resources.Cream_Colorful_Pastel_Cute_Illustration_Project_Presentation_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1413, 792);
            this.Controls.Add(this.btnDK);
            this.Controls.Add(this.btnDN);
            this.Controls.Add(this.txtPW);
            this.Controls.Add(this.txtUS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "Login";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUS;
        private System.Windows.Forms.TextBox txtPW;
        private System.Windows.Forms.Button btnDN;
        private System.Windows.Forms.Button btnDK;
        private System.Windows.Forms.Label label3;
    }
}

