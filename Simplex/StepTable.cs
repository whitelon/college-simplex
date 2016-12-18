using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplex
{
    /// <summary>
    /// Класс, описывающий таблицу, определяющую один шаг решения
    /// </summary>
    public class StepTable
    {   
        /// <summary>
        /// Количество неизвестных
        /// </summary>
        public int UnknownQuantity {
            get
            {
                return MainCoefficient.Length;
            }
        }
        /// <summary>
        /// Количество ограничений
        /// </summary>
        public int RestrictionQuantity {
            get
            {
                return BasisIndex.Length;
            }
        }

        /// <summary>
        /// Вектор коэффициентов главной функции
        /// </summary>
        public double[] MainCoefficient { get; set; }
        /// <summary>
        /// Вектор свободных членов ограничений
        /// </summary>
        public double[] FreeMember { get; set; }
        /// <summary>
        /// Вектор, хранящий индексы базисных переменных
        /// </summary>
        public int[] BasisIndex { get; set; }
        /// <summary>
        /// Матрица коэффициентов при ограничениях
        /// </summary>
        public double[][] RestrictionCoefficient { get; set; }
        /// <summary>
        /// Значение функции при данном базисе
        /// </summary>
        public double Value { get; private set; }
        /// <summary>
        /// Оценки дельта
        /// </summary>
        public double[] Delta { get; private set; }
        /// <summary>
        /// Индекс главного столбца
        /// </summary>
        public int P { get; private set; } = -1;
        /// <summary>
        /// Оценки тета
        /// </summary>
        public double[] Theta { get; private set; }
        /// <summary>
        /// Индекс главной строки
        /// </summary>
        public int Q { get; private set; } = -1;
        /// <summary>
        /// Флаг, показывающий является ли текущая таблица последней
        /// </summary>
        public bool FinalTable { get; private set; } = false;


        public StepTable(double[] mainCoefficient, int[] basisIndex, double[] freeMember, double[][] restrictionCoefficient)
        {
            //Заполняем таблицу входными данными
            MainCoefficient = mainCoefficient;
            BasisIndex = basisIndex;
            FreeMember = freeMember;
            RestrictionCoefficient = restrictionCoefficient;
            //Вычисляем значение
            Value = FindValue();
            //Вычисляем оценки дельта
            Delta = CalculateDelta();
            //Заканчиваем вычисления, если все оценки дельта <= 0
            FinalTable = Delta.All(e => e <= 0);
            if (FinalTable) return;
            //Рассчитываем индексы главного элемента 
            P = Array.IndexOf(Delta, Delta.Max());
            Theta = CalculateTheta(P);
            Q = Array.IndexOf(Theta, Theta.Where(e => e >= 0).Min());
        }
        /// <summary>
        /// Находит значение главной функции при данном базисе
        /// </summary>
        /// <returns>Значение глаыной функции</returns>
        private double FindValue()
        {
            return FreeMember
                .Select((e, i) =>  e * MainCoefficient[BasisIndex[i]])
                .Aggregate((f, s) => f + s);
        }
        /// <summary>
        /// Считает оценки дельта по формуле
        /// </summary>
        /// <returns>Вектор оценок дельта</returns>
        private double[] CalculateDelta()
        {
            return MainCoefficient.Select
                (
                    (c, j) =>
                    {
                        var sum = c;
                        for (int i = 0; i < RestrictionQuantity; i++)
                            sum -= RestrictionCoefficient[i][j] * MainCoefficient[BasisIndex[i]];
                        return sum;
                    }
                ).ToArray();
        }
        /// <summary>
        /// Считает оценки тета для главного столбца по формуле
        /// </summary>
        /// <param name="p">Индекс главного столбца</param>
        /// <returns>вектор оценок тета</returns>
        private double[] CalculateTheta(int p)
        {
            if (FinalTable) return null;

            var result = new double[RestrictionQuantity];
            
            for (int i = 0; i < RestrictionQuantity; i++)
            {
                if (RestrictionCoefficient[i][p] <= 0) result[i] = -1;
                else result[i] = FreeMember[i] / RestrictionCoefficient[i][p];
            }
            
            return result;
        }

        
    }
}
