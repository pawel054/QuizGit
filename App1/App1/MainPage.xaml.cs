﻿using System;
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
        private int currentQuestionIndex = 1;
        private int currentScore = 0;
        private List<int> questions = new List<int>();
        private Stopwatch stopwatch = new Stopwatch();
        private List<double> times = new List<double>();

        public MainPage()
        {
            InitializeComponent();
            GenerateQuestions();
        }

        private void GenerateQuestions()
        {
            Random random = new Random();
            questions = Enumerable.Range(0,5).Select(_=> random.Next(1,1001)).ToList();
        }

        private void StartQuiz(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(userNameEntry.Text))
            {
                DisplayAlert("Alert", "pole nie może być puste!", "OK");
            }
            else
            {
                currentScore = 0;
                currentQuestionIndex = 0;
                times.Clear();
                startGameView.IsVisible = false;
                finishGameView.IsVisible = false;
                gameView.IsVisible = true;
                ShowNextQuestion();
            }
        }

        private void PlayAgainButon(object sender, EventArgs e)
        {
            finishGameView.IsVisible = false;
            startGameView.IsVisible = false;
            GenerateQuestions();
        }

        private void ShowNextQuestion()
        {
            submitAnswerButton.IsEnabled = true;
            if(currentQuestionIndex < questions.Count)
            {
                questionLabel.IsVisible = true;
                questionLabel.Text = $"Podwojona wartość {questions{currentQuestionIndex}} to :"; 
                answerEnntry.IsVisible = true;
                submitAnswerButton.IsVisible = false;
                feedbackFrame.IsVisible = false;
                stopwatch.Restart();
            }
            else
            {
                FinishQuiz();
            }
        }

        private async void SubmitAnswer(object sender, EventArgs)
        {
            
        }
    }
}
