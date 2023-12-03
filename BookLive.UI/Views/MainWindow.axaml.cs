using System.Reactive.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using BookLive.UI.ViewModels;
using ReactiveUI;
using System.Windows.Input;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;

namespace BookLive.UI.Views
{
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddBook(object? sender, RoutedEventArgs routedEventArgs)
        {
            var window = new AddBookWindow()
            {
                DataContext = new AddBookViewModel()
            };

            window.ShowDialog(this);
        }
    }
}