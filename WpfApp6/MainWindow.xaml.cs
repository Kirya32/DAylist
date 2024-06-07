using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using WpfApp6.Controllers;
using WpfApp6.Models;
using WpfApp6.Windows;

namespace WpfApp6;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
    {
        WindowNewTask windows = new WindowNewTask();
        windows.Show();
    }

    private void Calendar_OnSelectedDatesChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (e.AddedItems.Count == 0)
            return;

        TaskController taskController = new TaskController();
        foreach (DateTime dateTime in e.AddedItems)
        {
            LbData.ItemsSource = taskController.Get(DateOnly.FromDateTime(dateTime));
        }
    }

    private void BtnDelete_OnClick(object sender, RoutedEventArgs e)
    {
        Button buttom = (Button) e.Source;
        TaskController controller = new TaskController();
        controller.DeleteTask(buttom.Content.ToString());
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        
    }
}