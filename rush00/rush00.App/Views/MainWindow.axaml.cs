using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

//Content="{Binding Content}"
namespace rush00.App.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}