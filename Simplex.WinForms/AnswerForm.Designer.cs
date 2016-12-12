namespace Simplex.WinForms
{
    partial class AnswerForm
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
            this.boxValue = new System.Windows.Forms.TextBox();
            this.listUnknowns = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.unknownColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.valueColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ответ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "max f(x) = ";
            // 
            // boxValue
            // 
            this.boxValue.Location = new System.Drawing.Point(70, 38);
            this.boxValue.Name = "boxValue";
            this.boxValue.ReadOnly = true;
            this.boxValue.Size = new System.Drawing.Size(193, 20);
            this.boxValue.TabIndex = 2;
            // 
            // listUnknowns
            // 
            this.listUnknowns.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.unknownColumn,
            this.valueColumn});
            this.listUnknowns.Location = new System.Drawing.Point(15, 77);
            this.listUnknowns.Name = "listUnknowns";
            this.listUnknowns.Size = new System.Drawing.Size(248, 130);
            this.listUnknowns.TabIndex = 3;
            this.listUnknowns.UseCompatibleStateImageBehavior = false;
            this.listUnknowns.View = System.Windows.Forms.View.Details;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(188, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Решение";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // unknownColumn
            // 
            this.unknownColumn.Text = "Неизвестная";
            this.unknownColumn.Width = 113;
            // 
            // valueColumn
            // 
            this.valueColumn.Text = "Значение";
            this.valueColumn.Width = 118;
            // 
            // AnswerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listUnknowns);
            this.Controls.Add(this.boxValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AnswerForm";
            this.ShowIcon = false;
            this.Text = "Simplex";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox boxValue;
        private System.Windows.Forms.ListView listUnknowns;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColumnHeader unknownColumn;
        private System.Windows.Forms.ColumnHeader valueColumn;
    }
}