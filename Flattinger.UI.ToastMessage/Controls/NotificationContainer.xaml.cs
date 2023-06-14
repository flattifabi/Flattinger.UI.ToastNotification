using Flattinger.Core.Enums;
using Flattinger.Core.Interface.ToastMessage;
using Flattinger.Core.Interface.ToastMessage.Base;
using Flattinger.Core.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Flattinger.UI.ToastMessage.Controls
{
    /// <summary>
    /// Interaktionslogik für NotificationContainer.xaml
    /// </summary>
    public partial class NotificationContainer : UserControl
    {
        public NotificationContainer()
        {
            InitializeComponent();
        }
        public void AddNotification(ToastType type, string message, string title, int delay)
        {
            var notification = new NotificationControl();
            notification.Message = message;
            notification.ToastType = type;
            notification.Title = title;

            notificationGrid.Children.Insert(0, notification);

            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(delay);

            notification.CloseButtonClicked += (sender, args) =>
            {
                AnimateNotificationHoverDown(notification);
                timer.Stop();
                return;
            };

            timer.Tick += (sender, e) =>
            {
                AnimateNotificationHoverDown(notification);
                timer.Stop();   
            };
            timer.Start();
        }

        public void AddNotification(ToastType type, string message, string title, int delay, List<IToastButton> buttons)
        {
            var notification = new NotificationControl();
            notification.Message = message;
            notification.ToastType = type;
            notification.Title = title;
            if(buttons == null) buttons = new List<IToastButton>();
            notification.ActionButtons = buttons;

            foreach (var buttonData in buttons)
            {
                Button button = new Button();
                button.Content = buttonData.Content;
                button.Background = buttonData.HasBackground ? buttonData.Background : Brushes.Transparent;
                button.Foreground = buttonData.Foreground;
                button.Command = new RelayCommand(param => buttonData.OnButtonClick());
                buttonData.NotificationControl = notification;
                buttonData.CloseCurrentNotification = new Action(() => AnimateNotificationFlyOut(notification));

                button.Style = FindResource("HoverButtonStyle") as Style;

                notification.actionButtonsContainer.Children.Add(button);
            }
            notificationGrid.Children.Insert(0, notification);

            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(delay);

            notification.CloseButtonClicked += (sender, args) =>
            {
                AnimateNotificationHoverDown(notification);
                timer.Stop();
                return;
            };

            timer.Tick += (sender, e) =>
            {
                AnimateNotificationHoverDown(notification);
                timer.Stop();
            };
            timer.Start();
        }
        #region animations
        private void AnimateNotificationHoverDown(NotificationControl notification)
        {
            DoubleAnimation opacityAnimation = new DoubleAnimation();
            opacityAnimation.From = 1.0;
            opacityAnimation.To = 0.0;
            opacityAnimation.Duration = TimeSpan.FromSeconds(0.3);

            DoubleAnimation heightAnimation = new DoubleAnimation();
            heightAnimation.From = notification.ActualHeight;
            heightAnimation.To = 0;
            heightAnimation.Duration = TimeSpan.FromSeconds(0.3);

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(opacityAnimation);
            storyboard.Children.Add(heightAnimation);

            Storyboard.SetTarget(opacityAnimation, notification);
            Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath(UIElement.OpacityProperty));

            Storyboard.SetTarget(heightAnimation, notification);
            Storyboard.SetTargetProperty(heightAnimation, new PropertyPath(FrameworkElement.HeightProperty));

            storyboard.Completed += (sender, e) =>
            {
                notificationGrid.Children.Remove(notification);
            };
            storyboard.Begin();
        }
        private void AnimateNotificationFlyOut(NotificationControl notification)
        {
            DoubleAnimation opacityAnimation = new DoubleAnimation();
            opacityAnimation.From = 1.0;
            opacityAnimation.To = 0.0;
            opacityAnimation.Duration = TimeSpan.FromSeconds(0.3);

            DoubleAnimation widthAnimation = new DoubleAnimation();
            widthAnimation.From = notification.ActualWidth;
            widthAnimation.To = 0;
            widthAnimation.Duration = TimeSpan.FromSeconds(0.3);

            DoubleAnimation translateAnimation = new DoubleAnimation();
            translateAnimation.From = 0;
            translateAnimation.To = -notification.ActualWidth;
            translateAnimation.Duration = TimeSpan.FromSeconds(0.3);

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(opacityAnimation);
            storyboard.Children.Add(widthAnimation);
            storyboard.Children.Add(translateAnimation);

            Storyboard.SetTarget(opacityAnimation, notification);
            Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath(UIElement.OpacityProperty));

            Storyboard.SetTarget(widthAnimation, notification);
            Storyboard.SetTargetProperty(widthAnimation, new PropertyPath(FrameworkElement.WidthProperty));

            Storyboard.SetTarget(translateAnimation, notification);
            Storyboard.SetTargetProperty(translateAnimation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.X)"));

            storyboard.Completed += (sender, e) =>
            {
                notificationGrid.Children.Remove(notification);
            };

            // Dynamisch RenderTransform hinzufügen
            TranslateTransform translateTransform = new TranslateTransform();
            notification.RenderTransform = translateTransform;

            storyboard.Begin(notification);
        }
        #endregion
    }
}
