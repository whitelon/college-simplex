using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simplex.WinForms
{
    public partial class AnswerForm : Form
    {
        public AnswerForm(StepTable zeroTable)
        {
            InitializeComponent();
            var solution = new Solution(zeroTable);

            boxValue.Text = solution.Value.ToString();

            listUnknowns.Items.Clear();
            for(int i = 0; i< solution.Unknowns.Length; i++)
            {
                listUnknowns.Items.Add(new ListViewItem(new string[] { $"x{i + 1}", $"{solution.Unknowns[i]}" }));
            }
        }
    }
}
