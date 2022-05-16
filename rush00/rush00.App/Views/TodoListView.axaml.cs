using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace rush00.App.Views
{
    public partial class TodoListView : UserControl
    {
        public TodoListView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}