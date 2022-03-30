using QuizMachine.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizMachine.Services
{
    public class GradeQuiz
    {
        private QuizViewModel quiz;

        public GradeQuiz(QuizViewModel quiz)
        {
            this.quiz = quiz;
        }
    }
}
