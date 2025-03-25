using AppInocoop.ViewModels;
using AppInocoop.Core.Models;

namespace AppInocoop
{
    public partial class MainPage : ContentPage
    {
        private Label scoreTeam1;
        private Label scoreTeam2;
        private GameState gameState;
        public MainPage()
        {
            InitializeComponent();
            //BindingContext = new MainViewModel(DependencyService.Get<IBluetoothService>());

            gameState = new GameState();

            scoreTeam1 = new Label
            {
                Text = gameState.Time_A_Score.ToString(),
                FontSize = 72,
                TextColor = Colors.White,
                HorizontalOptions = LayoutOptions.Center
            };

            scoreTeam2 = new Label
            {
                Text = gameState.Time_B_Score.ToString(),
                FontSize = 72,
                TextColor = Colors.White,
                HorizontalOptions = LayoutOptions.Center
            };

            var increaseTeam1 = new Button
            {
                Text = "+",
                FontSize = 32,
                BackgroundColor = Colors.Yellow
            };
            increaseTeam1.Clicked += (s, e) =>
            {
                gameState.Time_A_Score++;
                scoreTeam1.Text = gameState.Time_A_Score.ToString();
            };

            var decreaseTeam1 = new Button
            {
                Text = "-",
                FontSize = 32,
                BackgroundColor = Colors.Yellow
            };
            decreaseTeam1.Clicked += (s, e) =>
            {
                if (gameState.Time_A_Score > 0) gameState.Time_A_Score--;
                scoreTeam1.Text = gameState.Time_A_Score.ToString();
            };

            var increaseTeam2 = new Button
            {
                Text = "+",
                FontSize = 32,
                BackgroundColor = Colors.Yellow
            };
            increaseTeam2.Clicked += (s, e) =>
            {
                gameState.Time_B_Score++;
                scoreTeam2.Text = gameState.Time_B_Score.ToString();
            };

            var decreaseTeam2 = new Button
            {
                Text = "-",
                FontSize = 32,
                BackgroundColor = Colors.Yellow
            };
            decreaseTeam2.Clicked += (s, e) =>
            {
                if (gameState.Time_B_Score > 0) gameState.Time_B_Score--;
                scoreTeam2.Text = gameState.Time_B_Score.ToString();
            };

            var resetButton = new Button
            {
                Text = "Zerar placar",
                BackgroundColor = Colors.Gray,
                TextColor = Colors.White
            };
            resetButton.Clicked += (s, e) =>
            {
                gameState.ResetScores();
                scoreTeam1.Text = gameState.Time_A_Score.ToString();
                scoreTeam2.Text = gameState.Time_B_Score.ToString();
            };

            var grid = new Grid
            {
                ColumnDefinitions = new ColumnDefinitionCollection
                {
                    new ColumnDefinition { Width = GridLength.Star },
                    new ColumnDefinition { Width = GridLength.Star }
                },
                RowDefinitions = new RowDefinitionCollection
                {
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto }
                },
                RowSpacing = 20,
                ColumnSpacing = 30
            };

            increaseTeam1.WidthRequest = 100;
            increaseTeam1.Margin = new Thickness(10);
            increaseTeam1.HorizontalOptions = LayoutOptions.Center;

            decreaseTeam1.WidthRequest = 100;
            decreaseTeam1.Margin = new Thickness(10);
            decreaseTeam1.HorizontalOptions = LayoutOptions.Center;

            increaseTeam2.WidthRequest = 100;
            increaseTeam2.Margin = new Thickness(10);
            increaseTeam2.HorizontalOptions = LayoutOptions.Center;

            decreaseTeam2.WidthRequest = 100;
            decreaseTeam2.Margin = new Thickness(10);
            decreaseTeam2.HorizontalOptions = LayoutOptions.Center;

            grid.Children.Add(increaseTeam1);
            Grid.SetColumn(increaseTeam1, 0);
            Grid.SetRow(increaseTeam1, 0);

            grid.Children.Add(scoreTeam1);
            Grid.SetColumn(scoreTeam1, 0);
            Grid.SetRow(scoreTeam1, 1);
            scoreTeam1.FontSize = 80;
            scoreTeam1.Margin = new Thickness(10);
            scoreTeam1.HorizontalOptions = LayoutOptions.Center;

            grid.Children.Add(decreaseTeam1);
            Grid.SetColumn(decreaseTeam1, 0);
            Grid.SetRow(decreaseTeam1, 2);

            grid.Children.Add(increaseTeam2);
            Grid.SetColumn(increaseTeam2, 1);
            Grid.SetRow(increaseTeam2, 0);

            grid.Children.Add(scoreTeam2);
            Grid.SetColumn(scoreTeam2, 1);
            Grid.SetRow(scoreTeam2, 1);
            scoreTeam2.FontSize = 80;
            scoreTeam2.Margin = new Thickness(10);
            scoreTeam2.HorizontalOptions = LayoutOptions.Center;

            grid.Children.Add(decreaseTeam2);
            Grid.SetColumn(decreaseTeam2, 1);
            Grid.SetRow(decreaseTeam2, 2);

            resetButton.Margin = new Thickness(20, 40, 20, 0);
            resetButton.HorizontalOptions = LayoutOptions.Center;
            resetButton.WidthRequest = 200;

            Content = new StackLayout
            {
                Padding = 20,
                Spacing = 20,
                Children =
                {
                    grid,
                    resetButton
                }
            };
        }
    }

}
