using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Studienverlaufsplaner
{
    /// <summary>
    /// Interaktionslogik für ToDo.xaml
    /// </summary>
    public partial class ToDo : Page
    {
        public class ToDoItem
        {
            public string Task { get; set; }
            public bool IsCompleted { get; set; }
        }

        public ObservableCollection<ToDoItem> ToDoTask { get; set; }
        public ToDo()
        {
            InitializeComponent();
            ToDoTask = new ObservableCollection<ToDoItem>();
            //Liste mit Elementen verknüpfen
            ToDoList.ItemsSource = ToDoTask;
        }

        private void ToDosHinzufuegen(object sender, RoutedEventArgs e)
        {
            var dialog = new ToDoEingabeDialog("Neue Aufgabe Hinzufügen:");
            if (dialog.ShowDialog() == true)
            {
                ToDoTask.Add(new ToDoItem { Task = dialog.InputText, IsCompleted = false });
            }
        }


        private void ToDosLoeschen(object sender, RoutedEventArgs e)
        {
            if (ToDoList.SelectedItem is ToDoItem selectedItem)
            {
                ToDoTask.Remove(selectedItem);
            }
            else
            {
                MessageBox.Show("Bitte wähle eine Aufgabe aus, die gelöscht werden soll.", "Hinweis", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }


        private void ToDosBearbeiten(object sender, RoutedEventArgs e)
        {
            if (ToDoList.SelectedItem is ToDoItem selectedItem)
            {
                var dialog = new ToDoEingabeDialog("Aufgabe bearbeiten:", selectedItem.Task);
                if (dialog.ShowDialog() == true)
                {
                    selectedItem.Task = dialog.InputText;
                    ToDoList.Items.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Bitte wähle eine Aufgabe aus, die bearbeitet werden soll.", "Hinweis", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
