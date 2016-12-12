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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                var mainCoefficients = EquatonParser.ParseMainFunction(boxMainFunction.Text);
                var unknowns = mainCoefficients.Length;

                var restrictionCoefficients = new List<double[]>();
                var freeMembers = new List<double>();
                foreach (var line in boxRestrictions.Lines)
                {
                    var restriction = EquatonParser.ParseRestriction(line, unknowns);
                    restrictionCoefficients.Add(restriction.Item1);
                    freeMembers.Add(restriction.Item2);
                }
                new BasisForm(unknowns, mainCoefficients, restrictionCoefficients.ToArray(), freeMembers.ToArray())
                    .Show();
            } catch (Exception ex)
            {
                MessageBox.Show("Ошибка! Повторите ввод.");

            }
        }
    }
}
