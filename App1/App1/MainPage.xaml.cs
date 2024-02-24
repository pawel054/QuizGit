using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        private int currentQuestionIndex = 0;
        private int currentScore = 0;
        private List<int> questions = new List<int>();
        private Stopwatch stopwatch = new Stopwatch();
        private List<double> times = new List<double>();

        public MainPage()
        {
            InitializeComponent();

            GenerateQuestions();
        }

        private void FinishQuiz()
        {
            double totalTime = times.Sum();
            SaveResult(userNameEntry.Text, totalTime, currentScore);
            DisplayFinalResults(totalTime);
        }

        private async void ViewScoresClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ScoresPage());
        }

        private void DisplayFinalResults(double totalTime)
        {
            finishGameView.IsVisible = true;
            gameView.IsVisible = false;
            questionLabel.IsVisible = false;
            answerEntry.IsVisible = false;
            submitAnswerButton.IsVisible = false;
            resultPoints.Text = currentScore.ToString();
            resultTime.Text = totalTime.ToString("F2");
        }

        private void SaveResult(string userName, double totalTime, int score)
        {
            App.Database.SaveResultAsync(new UserResult(userName, totalTime, score));

            GenerateQuestions();
        }

        private void GenerateQuestions()
        {
            Random random = new Random();
            questions = Enumerable.Range(0, 5).Select(_ => random.Next(1, 1001)).ToList();
        }
    }
}
