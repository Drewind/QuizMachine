using QuizMachine.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizMachine.ViewModels
{
    public class QuizViewModel
    {
        //public HashSet<string> questions;
        public HashSet<string> questions = new HashSet<string>();
        public HashSet<AnswerSelectionViewModel> answerPool = new HashSet<AnswerSelectionViewModel>(); // LinkedList style
    }
}
