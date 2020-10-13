using System;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double avgGrade)
        {
            int allStudents = Students.Count;

            if (allStudents < 5)
            {
                throw new InvalidOperationException();
            }

            int studentsWithHigherAverageGrade =
                Students
                .Select(a => a)
                .Where(a => a.AverageGrade >= avgGrade)
                .Count();
            var percentOFStudentsWithHighAverage = Decimal.Divide(studentsWithHigherAverageGrade, allStudents) * 100;
            var percent = (100 - percentOFStudentsWithHighAverage);

            switch (percent)
            {
                case decimal percentage when (percent >= 80):
                    return 'A';
                case decimal percentage when (percent < 80 && percent >= 60):
                    return 'B';
                case decimal percentage when (percent < 60 && percent >= 40):
                    return 'C';
                case decimal percentage when (percent < 40 && percent >= 20):
                    return 'D';
                default:
                    return 'F';
            }
        }
    }
}