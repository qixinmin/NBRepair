namespace NBRepair
{
    partial class NBShouLiao
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
            this.NBID = new System.Windows.Forms.TextBox();
            this.vendor = new System.Windows.Forms.ComboBox();
            this.customer = new System.Windows.Forms.ComboBox();
            this.NBSerial = new System.Windows.Forms.TextBox();
            this.Model = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.AdapterSN = new System.Windows.Forms.TextBox();
            this.PowerCodeSN = new System.Windows.Forms.TextBox();
            this.CheckMan = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ConfigDesc = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.FunctionOK = new System.Windows.Forms.ComboBox();
            this.UUID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.declearNumbeTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // NBID
            // 
            this.NBID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NBID.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NBID.Location = new System.Drawing.Point(174, 87);
            this.NBID.Name = "NBID";
            this.NBID.Size = new System.Drawing.Size(435, 35);
            this.NBID.TabIndex = 0;
            this.NBID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NBID_KeyPress);
            // 
            // vendor
            // 
            this.vendor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vendor.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.vendor.FormattingEnabled = true;
            this.vendor.Items.AddRange(new object[] {
            "联宝"});
            this.vendor.Location = new System.Drawing.Point(174, 5);
            this.vendor.Name = "vendor";
            this.vendor.Size = new System.Drawing.Size(435, 32);
            this.vendor.TabIndex = 1;
            this.vendor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.vendor_KeyPress);
            // 
            // customer
            // 
            this.customer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customer.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.customer.FormattingEnabled = true;
            this.customer.Items.AddRange(new object[] {
            "联想"});
            this.customer.Location = new System.Drawing.Point(174, 46);
            this.customer.Name = "customer";
            this.customer.Size = new System.Drawing.Size(435, 32);
            this.customer.TabIndex = 2;
            this.customer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.customer_KeyPress);
            // 
            // NBSerial
            // 
            this.NBSerial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NBSerial.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NBSerial.Location = new System.Drawing.Point(174, 128);
            this.NBSerial.Name = "NBSerial";
            this.NBSerial.Size = new System.Drawing.Size(435, 35);
            this.NBSerial.TabIndex = 3;
            this.NBSerial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NBSerial_KeyPress);
            // 
            // Model
            // 
            this.Model.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Model.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Model.FormattingEnabled = true;
            this.Model.Location = new System.Drawing.Point(174, 169);
            this.Model.Name = "Model";
            this.Model.Size = new System.Drawing.Size(435, 32);
            this.Model.TabIndex = 4;
            this.Model.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Model_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(5, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "厂商";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(5, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "客户别";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(5, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "收料ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(5, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "机器序号";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(5, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 24);
            this.label5.TabIndex = 9;
            this.label5.Text = "机器型号";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.Lime;
            this.button1.Font = new System.Drawing.Font("SimSun", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(166, 530);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(292, 197);
            this.button1.TabIndex = 10;
            this.button1.Text = "确认";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(627, 513);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(738, 231);
            this.dataGridView1.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(5, 248);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(106, 24);
            this.label11.TabIndex = 22;
            this.label11.Text = "电源序号";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(5, 289);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 24);
            this.label12.TabIndex = 24;
            this.label12.Text = "电源线";
            // 
            // AdapterSN
            // 
            this.AdapterSN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AdapterSN.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AdapterSN.Location = new System.Drawing.Point(174, 251);
            this.AdapterSN.Name = "AdapterSN";
            this.AdapterSN.Size = new System.Drawing.Size(435, 35);
            this.AdapterSN.TabIndex = 25;
            this.AdapterSN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AdapterSN_KeyPress);
            // 
            // PowerCodeSN
            // 
            this.PowerCodeSN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PowerCodeSN.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PowerCodeSN.Location = new System.Drawing.Point(174, 292);
            this.PowerCodeSN.Name = "PowerCodeSN";
            this.PowerCodeSN.Size = new System.Drawing.Size(435, 35);
            this.PowerCodeSN.TabIndex = 26;
            this.PowerCodeSN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PowerCodeSN_KeyPress);
            // 
            // CheckMan
            // 
            this.CheckMan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CheckMan.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CheckMan.FormattingEnabled = true;
            this.CheckMan.Location = new System.Drawing.Point(174, 415);
            this.CheckMan.Name = "CheckMan";
            this.CheckMan.Size = new System.Drawing.Size(435, 32);
            this.CheckMan.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(5, 412);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 24);
            this.label6.TabIndex = 28;
            this.label6.Text = "检验人";
            // 
            // ConfigDesc
            // 
            this.ConfigDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfigDesc.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ConfigDesc.Location = new System.Drawing.Point(174, 374);
            this.ConfigDesc.Name = "ConfigDesc";
            this.ConfigDesc.Size = new System.Drawing.Size(435, 35);
            this.ConfigDesc.TabIndex = 30;
            this.ConfigDesc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ConfigDesc_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(5, 371);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 24);
            this.label7.TabIndex = 29;
            this.label7.Text = "配置说明";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(5, 330);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 24);
            this.label8.TabIndex = 32;
            this.label8.Text = "功能OKFAIL";
            // 
            // FunctionOK
            // 
            this.FunctionOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FunctionOK.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FunctionOK.FormattingEnabled = true;
            this.FunctionOK.Location = new System.Drawing.Point(174, 333);
            this.FunctionOK.Name = "FunctionOK";
            this.FunctionOK.Size = new System.Drawing.Size(435, 32);
            this.FunctionOK.TabIndex = 31;
            this.FunctionOK.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FunctionOK_KeyPress);
            // 
            // UUID
            // 
            this.UUID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UUID.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UUID.Location = new System.Drawing.Point(174, 210);
            this.UUID.Name = "UUID";
            this.UUID.Size = new System.Drawing.Size(435, 35);
            this.UUID.TabIndex = 34;
            this.UUID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UUID_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(5, 207);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 24);
            this.label9.TabIndex = 33;
            this.label9.Text = "UUID";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(627, 5);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(738, 500);
            this.dataGridView2.TabIndex = 35;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(5, 453);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 24);
            this.label10.TabIndex = 29;
            this.label10.Text = "报关单号";
            // 
            // declearNumbeTextBox
            // 
            this.declearNumbeTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.declearNumbeTextBox.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.declearNumbeTextBox.Location = new System.Drawing.Point(174, 456);
            this.declearNumbeTextBox.Name = "declearNumbeTextBox";
            this.declearNumbeTextBox.Size = new System.Drawing.Size(435, 35);
            this.declearNumbeTextBox.TabIndex = 30;
            this.declearNumbeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ConfigDesc_KeyPress);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.46783F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.53217F));
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.13922F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.86078F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1370, 749);
            this.tableLayoutPanel1.TabIndex = 36;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.61438F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.38562F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.declearNumbeTextBox, 1, 11);
            this.tableLayoutPanel2.Controls.Add(this.FunctionOK, 1, 8);
            this.tableLayoutPanel2.Controls.Add(this.label10, 0, 11);
            this.tableLayoutPanel2.Controls.Add(this.ConfigDesc, 1, 9);
            this.tableLayoutPanel2.Controls.Add(this.CheckMan, 1, 10);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 10);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.UUID, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.vendor, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.customer, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.NBID, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.PowerCodeSN, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.NBSerial, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label12, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.AdapterSN, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.Model, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.label11, 0, 6);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 12;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(614, 500);
            this.tableLayoutPanel2.TabIndex = 36;
            // 
            // NBShouLiao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "NBShouLiao";
            this.Text = "NBShouLiao";
            this.Load += new System.EventHandler(this.NBShouLiao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox NBID;
        private System.Windows.Forms.ComboBox vendor;
        private System.Windows.Forms.ComboBox customer;
        private System.Windows.Forms.TextBox NBSerial;
        private System.Windows.Forms.ComboBox Model;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox AdapterSN;
        private System.Windows.Forms.TextBox PowerCodeSN;
        private System.Windows.Forms.ComboBox CheckMan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ConfigDesc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox FunctionOK;
        private System.Windows.Forms.TextBox UUID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox declearNumbeTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}