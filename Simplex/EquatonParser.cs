using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Simplex
{
    /// <summary>
    /// Класс, преобразующий строку в вектор значений
    /// </summary>
    public static class EquatonParser
    {
        static readonly Regex _mainFunctionRegex = new Regex(@"(([+\-]?((?:\d*[,\.])?\d+))[xXхХ](\d+))+");
        static readonly Regex _restrictionRegex = new Regex(@"((([+\-]?((?:\d*[,\.])?\d+))[xXхХ](\d+))+)=((?:\d*[,\.])?\d+)");
        static readonly Regex _memberRegex = new Regex(@"(([+\-]?((?:\d*[,\.])?\d+))[xXхХ](\d+))");

        /// <summary>
        /// Преобразует строку с функцией в вектор коэффициентов
        /// </summary>
        /// <param name="func">строка с функцией</param>
        /// <param name="unknowns">количество неизвестных</param>
        /// <returns>вектор коэффициентов</returns>
        public static double[] ParseMainFunction(string func, int unknowns = 0)
        {
            //убираем пробелы
            func = func.Replace(" ", "");
            //проверяем на соответсвие образцу
            if (!_mainFunctionRegex.IsMatch(func)) throw new Exception("Wrong main func format");
            //определяем пары индекс - коеффициент
            var members = _memberRegex.Matches(func);
            var coeffs = new Dictionary<int, double>();
            foreach (Match member in members)
            {
                coeffs.Add(int.Parse(member.Groups[4].Value), double.Parse(member.Groups[2].Value));
            }
            var MainCoefficient = new double[unknowns > 0 ? unknowns : coeffs.Keys.Max()];
            //заносим коэффициенты в вектор
            foreach (var coeff in coeffs) MainCoefficient[coeff.Key - 1] = coeff.Value;
            return MainCoefficient;
        }
        /// <summary>
        /// Преобразует строку ограничение
        /// </summary>
        /// <param name="restr">строка с ограничением</param>
        /// <param name="unknowns">количество неизвестных</param>
        /// <returns>кортеж с вектором коэффициентов и свободным членом</returns>
        public static Tuple<double[], double> ParseRestriction(string restr, int unknowns = 0)
        {
            //убираем пробелы
            restr = restr.Replace(" ", "");
            //проверка на образец
            if (!_restrictionRegex.IsMatch(restr)) throw new Exception("Wrong restriction format");
            //определение свободного члена
            var freeMember = double.Parse(_restrictionRegex.Match(restr).Groups[6].Value);
            //определение коэффициентов
            var coeffs = ParseMainFunction(_restrictionRegex.Match(restr).Groups[1].Value, unknowns);

            return new Tuple<double[], double>(coeffs, freeMember);
        }


    }
}
