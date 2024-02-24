using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScoresPage : ContentPage
    {
        public ScoresPage()
        {
            InitializeComponent();
            LoadScores();
        }

        private async void LoadScores()
        {
            var scores = await.Database.GetResultsAsync();

            var sortedScores = scores.OrderByDescending(score => scores.Score).ThenBy(score => score.TotalTime).ToList();

            var groupedScores = sortedScores.GroupBy(score => scores.Score).SelectMany(group => group.OrderBy(score => scores.TotalTime)).ToList();

            for(int i=0; i < groupedScores.Count; i++)
            {
                groupedScores[i].RankingPosition = i + 1;
            }

            scoresCollectionView.ItemsSource = groupedScores;
        }
    }
}