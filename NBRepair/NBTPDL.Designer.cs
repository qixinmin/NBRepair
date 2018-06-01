namespace NBRepair
{
    partial class NBTPDL
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
            this.TNBSerial = new System.Windows.Forms.TextBox();
            this.TPORT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SPORT = new System.Windows.Forms.TextBox();
            this.SNBSerial = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TNBSerial
            // 
            this.TNBSerial.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TNBSerial.Location = new System.Drawing.Point(195, 170);
            this.TNBSerial.Name = "TNBSerial";
            this.TNBSerial.Size = new System.Drawing.Size(287, 29);
            this.TNBSerial.TabIndex = 0;
            this.TNBSerial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TNBSerial_KeyPress);
            // 
            // TPORT
            // 
            this.TPORT.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TPORT.Location = new System.Drawing.Point(195, 104);
            this.TPORT.Name = "TPORT";
            this.TPORT.Size = new System.Drawing.Size(287, 29);
            this.TPORT.TabIndex = 1;
            this.TPORT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TPORT_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(21, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "PORT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(21, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "机器序列号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SimSun", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(152, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 56);
            this.label3.TabIndex = 4;
            this.label3.Text = "TPDL";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("SimSun", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(152, 437);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 56);
            this.label4.TabIndex = 9;
            this.label4.Text = "SWDL";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(21, 614);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "机器序列号";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(21, 548);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 19);
            this.label6.TabIndex = 7;
            this.label6.Text = "PORT";
            // 
            // SPORT
            // 
            this.SPORT.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SPORT.Location = new System.Drawing.Point(195, 545);
            this.SPORT.Name = "SPORT";
            this.SPORT.Size = new System.Drawing.Size(287, 29);
            this.SPORT.TabIndex = 6;
            this.SPORT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SPORT_KeyPress);
            // 
            // SNBSerial
            // 
            this.SNBSerial.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SNBSerial.Location = new System.Drawing.Point(195, 611);
            this.SNBSerial.Name = "SNBSerial";
            this.SNBSerial.Size = new System.Drawing.Size(287, 29);
            this.SNBSerial.TabIndex = 5;
            this.SNBSerial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SNBSerial_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1149, 170);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 89);
            this.button1.TabIndex = 10;
            this.button1.Text = "初始创建Port口目录";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1223, 83);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(1145, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 19);
            this.label7.TabIndex = 12;
            this.label7.Text = "盘符：";
            // 
            // NBTPDL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1533, 821);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.SPORT);
            this.Controls.Add(this.SNBSerial);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TPORT);
            this.Controls.Add(this.TNBSerial);
            this.Name = "NBTPDL";
            this.Text = "NBTPDL";
            this.Load += new System.EventHandler(this.NBTPDL_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TNBSerial;
        private System.Windows.Forms.TextBox TPORT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox SPORT;
        private System.Windows.Forms.TextBox SNBSerial;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
    }
}