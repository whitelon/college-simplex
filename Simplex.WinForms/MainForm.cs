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
                //определяем коэффициенты главной функции и количество неизвестных
                var mainCoefficients = EquatonParser.ParseMainFunction(boxMainFunction.Text);
                var unknowns = mainCoefficients.Length;
                //определяем коэффициенты и свободные члены ограничений
                var restrictionCoefficients = new List<double[]>();
                var freeMembers = new List<double>();
                foreach (var line in boxRestrictions.Lines)
                {
                    var restriction = EquatonParser.ParseRestriction(line, unknowns);
                    restrictionCoefficients.Add(restriction.Item1);
                    freeMembers.Add(restriction.Item2);
                }
                //передаем данные дальше
                new BasisForm(unknowns, mainCoefficients, restrictionCoefficients.ToArray(), freeMembers.ToArray())
                    .Show();
            } catch (Exception ex)
            {
                MessageBox.Show("Ошибка! Повторите ввод.");

            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            new HelpForm().Show();
        }
    }
}
