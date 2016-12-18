namespace Simplex.WinForms
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.boxMainFunction = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.boxRestrictions = new System.Windows.Forms.TextBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите главную функцию \r\n(со всеми дополнительными переменными)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "max f(x) = ";
            // 
            // boxMainFunction
            // 
            this.boxMainFunction.Location = new System.Drawing.Point(70, 61);
            this.boxMainFunction.Name = "boxMainFunction";
            this.boxMainFunction.Size = new System.Drawing.Size(173, 20);
            this.boxMainFunction.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 26);
            this.label3.TabIndex = 3;
            this.label3.Text = "Введите ограничения\r\nОдно ограничение на одной строке";
            // 
            // boxRestrictions
            // 
            this.boxRestrictions.Location = new System.Drawing.Point(15, 133);
            this.boxRestrictions.Multiline = true;
            this.boxRestrictions.Name = "boxRestrictions";
            this.boxRestrictions.Size = new System.Drawing.Size(228, 81);
            this.boxRestrictions.TabIndex = 4;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(87, 226);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 5;
            this.btnHelp.Text = "Помощь";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(168, 226);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = "Далее";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 261);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.boxRestrictions);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.boxMainFunction);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Simplex";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox boxMainFunction;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox boxRestrictions;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnNext;
    }
}

