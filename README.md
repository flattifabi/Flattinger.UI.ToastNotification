# Flattinger.UI.ToastNotification

For using this Service add the Namespace at your MainWindow:
```
xmlns:toast="clr-namespace:Flattinger.UI.ToastMessage.Controls;assembly=Flattinger.UI.ToastMessage"
...
<Grid>
  <toast:NotificationContainer x:Name="NotificationContainer" HorizontalAlignment="Right" VerticalAlignment="Bottom" Margin="10"/>
</Grid>
```

if you use MVVM pass this container to your ViewModel

Here how to use
```c#
public class MainWindowViewModel : BaseViewModel
    {
        public ICommand SendNotification { get; set; }
        private NotificationContainer _notificationContainer;
        private ToastProvider _toastProvider;
        private AppTheme _themeManager;
        public MainWindowViewModel(NotificationContainer notificationContainer)
        {
            this._notificationContainer = notificationContainer;
            _toastProvider = new ToastProvider(notificationContainer);
            SendNotification = new RelayCommand(param => ExecuteSendNotification());
            _themeManager = new AppTheme();
            _themeManager.ChangeTheme(Flattinger.Core.Enums.Theme.LIGHT);
        }
        public void ExecuteSendNotification()
        {
            _toastProvider.NotificationService.AddNotification(Flattinger.Core.Enums.ToastType.ERROR, "Fehler bei der Anmeldung", "Bei deiner automatischen Anmeldung ist etwas schief gelaufen. Möglicherweise hast du dein Passwort bei einem anderen Konto geändert", 400, new List<IToastButton>
            {
                new ToastButton() { Foreground=Brushes.Black, Content="Zur Anmeldung", OnButtonClick = new Action(() => ExecuteSendNotification())},
            });
            
            _toastProvider.NotificationService.AddNotification(Flattinger.Core.Enums.ToastType.SUCCESS, "Erfolgreich", "Die Aktion war erfolgreich", 3);
        }
    }
```c#
