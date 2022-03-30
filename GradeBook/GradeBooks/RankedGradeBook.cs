using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook:BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException();
            int betterStudents = 0;
            for(int i = 0; i < Students.Count; i++)
            {
                if (Students[i].AverageGrade > averageGrade)
                    betterStudents++;
            }
            double ranking = (double)(betterStudents + 1) / Students.Count;

            if (ranking <= .2) return 'A';
            if (ranking <= .4) return 'B';
            if (ranking <= .6) return 'C';
            if (ranking <= .8) return 'D';
            else return 'F';
        }
        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
                Console.WriteLine("Ranked grading at least 5 students.");
            else
            {
                base.CalculateStatistics();
            }
        }
    }
}
