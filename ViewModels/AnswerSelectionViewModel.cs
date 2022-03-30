using QuizMachine.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizMachine.ViewModels
{
    public class AnswerSelectionViewModel
    {
        public string CORRECT_ANSWER; // would rewrite this to be const with make a constructor to assign it
        public int questionNumber;
        public HashSet<string> possibleAnswers = new HashSet<string>();
    }
}
