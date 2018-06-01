namespace NBRepair
{
    partial class MakeDatabase
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
            this.MakeDB = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.MakeTable = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MakeDB
            // 
            this.MakeDB.Location = new System.Drawing.Point(150, 113);
            this.MakeDB.Name = "MakeDB";
            this.MakeDB.Size = new System.Drawing.Size(143, 72);
            this.MakeDB.TabIndex = 0;
            this.MakeDB.Text = "MakeDB";
            this.MakeDB.UseVisualStyleBackColor = true;
            this.MakeDB.Click += new System.EventHandler(this.MakeDB_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(150, 36);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(143, 21);
            this.textBox1.TabIndex = 1;
            // 
            // MakeTable
            // 
            this.MakeTable.Location = new System.Drawing.Point(395, 113);
            this.MakeTable.Name = "MakeTable";
            this.MakeTable.Size = new System.Drawing.Size(143, 72);
            this.MakeTable.TabIndex = 2;
            this.MakeTable.Text = "MakeTable";
            this.MakeTable.UseVisualStyleBackColor = true;
            // 
            // MakeDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1478, 818);
            this.Controls.Add(this.MakeTable);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.MakeDB);
            this.Name = "MakeDatabase";
            this.Text = "MakeDatabase";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button MakeDB;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button MakeTable;
    }
}