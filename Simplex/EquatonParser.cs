using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Simplex
{
    public static class EquatonParser
    {
        static readonly Regex _mainFunctionRegex = new Regex(@"(([+\-]?((?:\d*[,\.])?\d+))[xXхХ](\d+))+");
        static readonly Regex _restrictionRegex = new Regex(@"((([+\-]?((?:\d*[,\.])?\d+))[xXхХ](\d+))+)=((?:\d*[,\.])?\d+)");
        static readonly Regex _memberRegex = new Regex(@"(([+\-]?((?:\d*[,\.])?\d+))[xXхХ](\d+))");

        
        public static double[] ParseMainFunction(string func, int unknowns = 0)
        {
            func = func.Replace(" ", "");
            if (!_mainFunctionRegex.IsMatch(func)) throw new Exception("Wrong main func format");
            var members = _memberRegex.Matches(func);
            var coeffs = new Dictionary<int, double>();
            foreach (Match member in members)
            {
                coeffs.Add(int.Parse(member.Groups[4].Value), double.Parse(member.Groups[2].Value));
            }
            var MainCoefficient = new double[unknowns > 0 ? unknowns : coeffs.Keys.Max()];
            foreach (var coeff in coeffs) MainCoefficient[coeff.Key - 1] = coeff.Value;
            return MainCoefficient;
        }
        public static Tuple<double[], double> ParseRestriction(string restr, int unknowns = 0)
        {
            restr = restr.Replace(" ", "");
            if (!_restrictionRegex.IsMatch(restr)) throw new Exception("Wrong restriction format");

            var freeMember = double.Parse(_restrictionRegex.Match(restr).Groups[6].Value);
            var coeffs = ParseMainFunction(_restrictionRegex.Match(restr).Groups[1].Value, unknowns);

            return new Tuple<double[], double>(coeffs, freeMember);
        }


    }
}
