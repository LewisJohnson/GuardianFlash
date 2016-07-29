using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FileHelpers;

namespace GuardianFlash
{
    /// <summary>
    /// Interaction logic for ReadWindow.xaml
    /// </summary>
    public partial class ReadWindow : Window
    {
        public static string FileName { get; private set; }
        List<FlashCard> FlashCardList = new List<FlashCard>();
        static FlashCard.Difficulty Difficulty;
        public ReadWindow()
        {
            InitializeComponent();
            FileName = "default.txt";
        }

        private void difficultyBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            string frontText = new TextRange(frontTextBox.Document.ContentStart, frontTextBox.Document.ContentEnd).Text;
            string backText = new TextRange(backTextBox.Document.ContentStart, backTextBox.Document.ContentEnd).Text;

            var engine = new FileHelperEngine<FlashCard>();
            
            switch (difficultyBox.SelectedIndex)
            {
                case 0:
                    Difficulty = FlashCard.Difficulty.easy;
                    break;
                case 1:
                    Difficulty = FlashCard.Difficulty.medium;
                    break;
                case 2:
                    Difficulty = FlashCard.Difficulty.hard;
                    break;
                case 3:
                    Difficulty = FlashCard.Difficulty.very;
                    break;
            }

            var newCard = new FlashCard() { Front = frontText, Back = backText, CardDifficulty = Difficulty };

            FlashCardList.Add(newCard);

            if (System.IO.Directory.Exists("cards") && System.IO.File.Exists("cards\\" + FileName))
            {
                engine.WriteFile("cards\\" + FileName, FlashCardList);
            }
            else
            {
                System.IO.Directory.CreateDirectory("cards");
                var cardsFile = System.IO.File.Create("cards\\" + FileName);
                cardsFile.Close();
                engine.WriteFile("cards\\" + FileName, FlashCardList);
            }

            frontTextBox.Document.Blocks.Clear();
            backTextBox.Document.Blocks.Clear();
              
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            FileName = nameBox.Text + ".txt";
            
            if (System.IO.File.Exists("cards\\" + FileName) && nameBox.IsEnabled == true)
            {
                string messageBoxText = "Card already exists. Overwrite?";
                string caption = "Duplicate Card";
                MessageBoxButton button = MessageBoxButton.YesNoCancel;

                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button);

                switch (result)
                {
                    case MessageBoxResult.Yes:
                        nameBox.IsEnabled = false;
                        
                        break;
                    case MessageBoxResult.No:
                        break;

                }
            }
            else
            {
                nameBox.IsEnabled = false;
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
