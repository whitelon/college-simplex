using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplex
{
    /// <summary>
    /// Описывает решение задачи линейного программирования
    /// </summary>
    public class Solution
    {
        /// <summary>
        /// Список таблиц-шагов решения
        /// </summary>
        public List<StepTable> Steps { get; private set; } = new List<Simplex.StepTable>();
        /// <summary>
        /// Оптимальное значение главной функции
        /// </summary>
        public double Value { get; private set; }
        /// <summary>
        /// Вектор значений неизвестных, при которых достигается оптимальное значение
        /// </summary>
        public double[] Unknowns { get; private set; }


        public Solution(double[] mainCoefficient, int[] basisIndex, double[] freeMember, double[][] restrictionCoefficient)
            : this(new StepTable(mainCoefficient, basisIndex, freeMember, restrictionCoefficient))
        {

        }

        public Solution(StepTable zeroTable)
        {
            //добавляем нулевую таблицу в список
            Steps.Add(zeroTable);
            //рассчитываем новые таблицы, пока не достигнем оптимального решения
            while (!Steps.Last().FinalTable) Steps.Add(NextTable(Steps.Last()));

            var lastTable = Steps.Last();
            //Заполняем значение функции и переменных
            Value = lastTable.Value;

            Unknowns = new double[lastTable.UnknownQuantity];
            int i = 0;
            foreach (var basisIndex in lastTable.BasisIndex)
                Unknowns[basisIndex] = lastTable.FreeMember[i++];
        }
        /// <summary>
        /// Рассчитывает новую таблицу
        /// </summary>
        /// <param name="oldTable">Предыдущая таблица</param>
        /// <returns>Новая таблица</returns>
        private StepTable NextTable(StepTable oldTable)
        {
            var n = oldTable.UnknownQuantity;
            var m = oldTable.RestrictionQuantity;
            var q = oldTable.Q;
            var p = oldTable.P;
            var mainElement = oldTable.RestrictionCoefficient[q][p];

            //Копирование значений
            var c = new double[n];
            oldTable.MainCoefficient.CopyTo(c, 0);
            var basis = new int[m];
            oldTable.BasisIndex.CopyTo(basis, 0);
            var b = new double[m];
            oldTable.FreeMember.CopyTo(b, 0);
            var a = new double[m][];
            var i = 0;
            foreach (var row in oldTable.RestrictionCoefficient)
                row.CopyTo(a[i++] = new double[n], 0);

            //Изменение значений по формулам
            basis[q] = p;
            a[q] = a[q].Select(e => e / mainElement).ToArray();
            b[q] = oldTable.FreeMember[q] / mainElement;
            for (i = 0; i < m; i++)
            {
                if (i == q) continue;
                b[i] = b[i] - b[q] * oldTable.RestrictionCoefficient[i][p];
                for(int j = 0; j < n; j++)
                {
                    a[i][j] = a[i][j] - a[q][j] * oldTable.RestrictionCoefficient[i][p]; 
                }
            }

            return new StepTable(c, basis, b, a);
        }
    }
}

