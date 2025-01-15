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

namespace Studienverlaufsplaner
{
    /// <summary>
    /// Interaktionslogik für ToDoEingabeDialog.xaml
    /// </summary>
    public partial class ToDoEingabeDialog : Window
    {
        public string InputText => TextInput.Text;
        public ToDoEingabeDialog(string prompt, string defaultText = "")
        {
            InitializeComponent();
            DialogPrompt.Text = prompt;
            TextInput.Text = defaultText;
            TextInput.Focus();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
