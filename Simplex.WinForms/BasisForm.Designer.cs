namespace Simplex.WinForms
{
    partial class BasisForm
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
            this.lblBasis = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.boxBasis = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // lblBasis
            // 
            this.lblBasis.AutoSize = true;
            this.lblBasis.Location = new System.Drawing.Point(12, 9);
            this.lblBasis.Name = "lblBasis";
            this.lblBasis.Size = new System.Drawing.Size(177, 13);
            this.lblBasis.TabIndex = 0;
            this.lblBasis.Text = "Выберите базисные переменные";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(116, 153);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Далее";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // boxBasis
            // 
            this.boxBasis.CheckOnClick = true;
            this.boxBasis.FormattingEnabled = true;
            this.boxBasis.Location = new System.Drawing.Point(15, 40);
            this.boxBasis.MultiColumn = true;
            this.boxBasis.Name = "boxBasis";
            this.boxBasis.Size = new System.Drawing.Size(174, 94);
            this.boxBasis.TabIndex = 3;
            // 
            // BasisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(203, 188);
            this.Controls.Add(this.boxBasis);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.lblBasis);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "BasisForm";
            this.ShowIcon = false;
            this.Text = "Simplex";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBasis;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.CheckedListBox boxBasis;
    }
}