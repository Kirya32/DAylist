using System.Windows;
using WpfApp6.Controllers;
using WpfApp6.Models;

namespace WpfApp6.Windows;

public partial class WindowNewTask : Window
{
    public WindowNewTask()
    {
        InitializeComponent();
    }

    private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
    {
        TaskController taskController = new TaskController();
        DayTask task = new DayTask()
        {
            Id = Guid.NewGuid(),
            Date = DateOnly.FromDateTime(Calendar.SelectedDate ?? DateTime.Today ),
            Name = TbName.Text,
            Description = TbDescription.Text
        };
        taskController.AddNewTask(task);
        Close();
    }
}