namespace NBRepair
{
    partial class BOM
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
            this.filePath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.importButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // filePath
            // 
            this.filePath.Font = new System.Drawing.Font("SimSun", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.filePath.Location = new System.Drawing.Point(12, 41);
            this.filePath.Name = "filePath";
            this.filePath.Size = new System.Drawing.Size(965, 71);
            this.filePath.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("SimSun", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(174, 196);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(203, 131);
            this.button1.TabIndex = 2;
            this.button1.Text = "选择文件";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // importButton
            // 
            this.importButton.Font = new System.Drawing.Font("SimSun", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.importButton.Location = new System.Drawing.Point(538, 196);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(204, 131);
            this.importButton.TabIndex = 3;
            this.importButton.Text = "确定导入";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // BOM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 432);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.filePath);
            this.Name = "BOM";
            this.Text = "BOM";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox filePath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}