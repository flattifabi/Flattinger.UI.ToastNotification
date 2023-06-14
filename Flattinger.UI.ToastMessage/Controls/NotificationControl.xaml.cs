using Flattinger.Core.Enums;
using Flattinger.Core.Interface.ToastMessage.Base;
using MahApps.Metro.IconPacks;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Flattinger.UI.ToastMessage.Controls
{
    /// <summary>
    /// Interaktionslogik für NotificationControl.xaml
    /// </summary>
    public partial class NotificationControl : UserControl
    {
        public event EventHandler CloseButtonClicked;

        public static readonly DependencyProperty IconProperty =
        DependencyProperty.Register("Icon", typeof(PackIconMaterialDesignKind), typeof(NotificationControl), new PropertyMetadata(PackIconMaterialDesignKind.None));

        public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register("Title", typeof(string), typeof(NotificationControl), new PropertyMetadata(""));

        public static readonly DependencyProperty MessageProperty =
        DependencyProperty.Register("Message", typeof(string), typeof(NotificationControl), new PropertyMetadata(""));

        public static readonly DependencyProperty ToastTypeProperty =
        DependencyProperty.Register("ToastType", typeof(ToastType), typeof(NotificationControl), new PropertyMetadata(ToastType.INFO));

        public static readonly DependencyProperty CloseCommandProperty =
        DependencyProperty.Register("CloseCommand", typeof(ICommand), typeof(NotificationControl), new PropertyMetadata(null));

        public static readonly DependencyProperty ActionButtonsProperty =
        DependencyProperty.Register("ActionButtons", typeof(List<IToastButton>), typeof(NotificationControl), new PropertyMetadata(null));

        public PackIconMaterialDesignKind Icon
        {
            get { return (PackIconMaterialDesignKind)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        public ToastType ToastType
        {
            get { return (ToastType)GetValue(ToastTypeProperty);}
            set { SetValue(ToastTypeProperty, value); }
        }
        public ICommand CloseCommand
        {
            get { return (ICommand)GetValue(CloseCommandProperty); }
            set { SetValue(CloseCommandProperty, value); }
        }
        public List<IToastButton> ActionButtons
        {
            get { return (List<IToastButton>)GetValue(ActionButtonsProperty); }
            set { SetValue(ActionButtonsProperty, value); }
        }

        private void OnCloseButtonClicked()
        {
            CloseButtonClicked?.Invoke(this, EventArgs.Empty);
        }
        public NotificationControl()
        {
            InitializeComponent();
            DataContext = this;

            closeButton.Click += CloseButton_Click;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            OnCloseButtonClicked();
        }
    }
}
