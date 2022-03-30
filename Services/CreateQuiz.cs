using QuizMachine.Models;
using QuizMachine.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizMachine.Services
{
    public class CreateQuiz
    {
        private readonly int NUM_QUESTIONS;
        private QuizViewModel model = new QuizViewModel();
        private readonly VeridocsStatesCapitalsContext _context;

        public CreateQuiz(int questions, VeridocsStatesCapitalsContext context)
        {
            NUM_QUESTIONS = questions;
            _context = context;
        }

        public QuizViewModel GenerateQuiz()
        {
            State questionSelected = SelectQuestion();
            while (model.questions.Count != NUM_QUESTIONS)
            {
                if (!model.questions.Contains(questionSelected.State1))
                {
                    model.questions.Add(questionSelected.State1);
                    model.answerPool.Add(AnswerSelection(questionSelected, model.questions.Count));
                } else
                {
                    questionSelected = SelectQuestion();
                }
            }

            return model;
        }

        private State SelectQuestion()
        {
            var rand = new Random();
            var questionPool = _context.States.ToList();
            var question = questionPool[rand.Next(questionPool.Count)];
            return question;
        }

        private AnswerSelectionViewModel AnswerSelection(State state, int questionNumber)
        {
            AnswerSelectionViewModel selection = new AnswerSelectionViewModel();
            selection.CORRECT_ANSWER = state.Capital;
            selection.possibleAnswers.Add(state.Capital);
            selection.questionNumber = questionNumber;
            var rand = new Random();
            var answerPool = _context.States.ToList();
            
            for (int i = 0; i < 3; i++)
            {
                selection.possibleAnswers.Add(answerPool[rand.Next(answerPool.Count)].Capital);
            }

            return selection;
        }
    }
}
