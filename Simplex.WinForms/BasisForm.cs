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
    public partial class BasisForm : Form
    {
        public BasisForm(int unknowns, double[] mainCoefficients, double[][] restrictionCoefficients, double[] freeMembers)
        {
            InitializeComponent();
            lblBasis.Text = $"Выберите {restrictionCoefficients.Length} базисные переменные";

            for (int i = 0; i < unknowns; i++)
            {
                boxBasis.Items.Add("x" + (i + 1));
            }

            


            btnNext.Click += (s, a) =>
            {
                var basisIndex = boxBasis.CheckedIndices.Cast<int>().ToArray();
                if (basisIndex.Length != restrictionCoefficients.Length)
                {
                    MessageBox.Show("Выбрано неверное количество базисных переменных");
                    return;
                }
                var firstTable = new StepTable(mainCoefficients, basisIndex, freeMembers, restrictionCoefficients);
                new AnswerForm(firstTable).Show();
            };
        }
    }
}
