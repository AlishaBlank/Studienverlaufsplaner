using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        public class ToDoItem : INotifyPropertyChanged
        {
            private string task = string.Empty; //wegen nullable standardwert geben, darf nicht NULL sein
            public string Task
            {
                get => task;
                set
                {
                    if (task != value)
                    {
                        task = value;
                        OnPropertyChanged(nameof(Task));
                    }
                }
            }

            private bool isCompleted;
            public bool IsCompleted
            {
                get => isCompleted;
                set
                {
                    if (isCompleted != value)
                    {
                        isCompleted = value;
                        OnPropertyChanged(nameof(IsCompleted));
                    }
                }
            }

            public event PropertyChangedEventHandler? PropertyChanged;

            protected void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
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
            var dialog = new ToDoEingabeDialog("Neue Aufgabe hinzufügen:");
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
                MessageBox.Show("Bitte wähle eine Aufgabe aus, die gelöscht werden soll.", "Keine Aufgabe ausgewählt",
                                MessageBoxButton.OK, MessageBoxImage.Information);
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
                }
            }
            else
            {
                MessageBox.Show("Bitte wähle eine Aufgabe aus, die bearbeitet werden soll.", "Keine Aufgabe ausgewählt",
                                MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
