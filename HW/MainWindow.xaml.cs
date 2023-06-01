using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HW
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<string> style = new List<string>() { "Светлая тема", "Темная тема" };
            styleBox.ItemsSource = style;
            styleBox.SelectionChanged += ThemeChange;
            styleBox.SelectedIndex = 0;
        }

        private void ThemeChange(object sender, SelectionChangedEventArgs e)
        {
            int styleIndex = styleBox.SelectedIndex;
            Uri uri = new Uri("Light.xaml", UriKind.Relative);
            if (styleIndex == 1)
            {
                uri = new Uri("Dark.xaml", UriKind.Relative);
            }
            ResourceDictionary resource = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resource);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fontName = ((sender as ComboBox).SelectedItem as string);
            if (textbox != null)
            {
                textbox.FontFamily = new FontFamily(fontName);
            }

        }
        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (textbox != null)
            {
                double fontSize = Convert.ToDouble(((sender as ComboBox).SelectedItem as string));
                textbox.FontSize = fontSize;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (textbox.FontWeight == FontWeights.Normal)
            {
                textbox.FontWeight = FontWeights.Bold;
            }
            else
            {
                textbox.FontWeight = FontWeights.Normal;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            if (textbox.FontStyle == FontStyles.Normal)
            {
                textbox.FontStyle = FontStyles.Italic;
            }
            else
            {
                textbox.FontStyle = FontStyles.Normal;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (textbox.TextDecorations == null)
            {
                textbox.TextDecorations = TextDecorations.Underline;
            }
            else
            {
                textbox.TextDecorations = null;
            }
        }
        //private void Button_Click_2(object sender, RoutedEventArgs e)
        //{
        //    if (textbox.TextDecorations.Count ==0)
        //    {
        //        textbox.TextDecorations.Add(TextDecorations.Underline) ;
        //    }
        //    else
        //    {
        //        textbox.TextDecorations.Remove(TextDecorations.Underline[0]);
        //    }
        //}


        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (textbox != null)
            {
                textbox.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            }

        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            if (textbox != null)
            {
                textbox.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            }

        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы(*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                textbox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы(*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, textbox.Text);
            }
        }

        private void CloseExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
