namespace NBRepair
{
    partial class NBPack
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
            this.NBSerial = new System.Windows.Forms.TextBox();
            this.NewAdapterSN = new System.Windows.Forms.TextBox();
            this.NewPowerCodeSN = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // NBSerial
            // 
            this.NBSerial.Font = new System.Drawing.Font("SimSun", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NBSerial.Location = new System.Drawing.Point(258, 46);
            this.NBSerial.Name = "NBSerial";
            this.NBSerial.Size = new System.Drawing.Size(405, 47);
            this.NBSerial.TabIndex = 0;
            this.NBSerial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NBSerial_KeyPress);
            // 
            // NewAdapterSN
            // 
            this.NewAdapterSN.Font = new System.Drawing.Font("SimSun", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NewAdapterSN.Location = new System.Drawing.Point(258, 111);
            this.NewAdapterSN.Name = "NewAdapterSN";
            this.NewAdapterSN.Size = new System.Drawing.Size(405, 47);
            this.NewAdapterSN.TabIndex = 1;
            this.NewAdapterSN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NewAdapterSN_KeyPress);
            // 
            // NewPowerCodeSN
            // 
            this.NewPowerCodeSN.Font = new System.Drawing.Font("SimSun", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NewPowerCodeSN.Location = new System.Drawing.Point(258, 181);
            this.NewPowerCodeSN.Name = "NewPowerCodeSN";
            this.NewPowerCodeSN.Size = new System.Drawing.Size(405, 47);
            this.NewPowerCodeSN.TabIndex = 2;
            this.NewPowerCodeSN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NewPowerCodeSN_KeyPress);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("SimSun", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(167, 376);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(270, 154);
            this.button1.TabIndex = 3;
            this.button1.Text = "确认";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(32, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 35);
            this.label1.TabIndex = 4;
            this.label1.Text = "机器序号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SimSun", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(32, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 35);
            this.label2.TabIndex = 5;
            this.label2.Text = "电源序号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SimSun", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(32, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 35);
            this.label3.TabIndex = 6;
            this.label3.Text = "电源线序号";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(719, 46);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1039, 742);
            this.dataGridView1.TabIndex = 7;
            // 
            // NBPack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.NewPowerCodeSN);
            this.Controls.Add(this.NewAdapterSN);
            this.Controls.Add(this.NBSerial);
            this.Name = "NBPack";
            this.Text = "NBPack";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NBPack_FormClosing);
            this.Load += new System.EventHandler(this.NBPack_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NBSerial;
        private System.Windows.Forms.TextBox NewAdapterSN;
        private System.Windows.Forms.TextBox NewPowerCodeSN;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}