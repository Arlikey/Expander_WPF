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
using System.Windows.Shapes;

namespace Expander_WPF
{
    /// <summary>
    /// Interaction logic for AdditionalTask1.xaml
    /// </summary>
    public partial class AdditionalTask1 : Window
    {
        private TaskViewModel viewModel;
        public AdditionalTask1()
        {
            InitializeComponent();
            viewModel = new TaskViewModel();
            DataContext = viewModel;
            
        }

        private void addTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if(ValidateFields())
            {
                Task task = new Task() { Title = nameTextBox.Text, Description = descriptionTextBox.Text };
                viewModel.Tasks.Add(task);
                ClearFields();
            }
         
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Не было введено название задачи!", "Проверка ввода");
                return false;
            }
            if (string.IsNullOrEmpty(descriptionTextBox.Text))
            {
                MessageBox.Show("Не было введено описание задачи!", "Проверка ввода");
                return false;
            }
            return true;
        }

        private void ClearFields()
        {
            nameTextBox.Text = string.Empty;
            descriptionTextBox.Text = string.Empty;
        }
    }

    public class TaskViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Task> tasks;

        public ObservableCollection<Task> Tasks
        {
            get { return tasks; }
            set
            {
                tasks = value;
                OnPropertyChanged("Tasks");
            }
        }

        public TaskViewModel()
        {
            Tasks = new ObservableCollection<Task>
            {
                new Task { Title = "Задача №1", Description = "Описание задачи №1", Priority = Priority.Low },
                new Task { Title = "Задача №2", Description = "Описание задачи №2", Priority = Priority.High },
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
    public class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
    }

    public enum Priority
    {
        Low,
        Medium,
        High
    }
}
