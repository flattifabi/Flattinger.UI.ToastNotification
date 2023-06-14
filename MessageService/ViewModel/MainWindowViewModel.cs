using Flattinger.Core.Interface.ToastMessage.Base;
using Flattinger.Core.MVVM;
using Flattinger.UI.ToastMessage;
using Flattinger.UI.ToastMessage.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace MessageService.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        public ICommand SendNotification { get; set; }
        private NotificationContainer _notificationContainer;
        private ToastProvider _toastProvider;
        public MainWindowViewModel(NotificationContainer notificationContainer)
        {
            this._notificationContainer = notificationContainer;
            _toastProvider = new ToastProvider(notificationContainer);
            SendNotification = new RelayCommand(param => ExecuteSendNotification());
        }
        public void ExecuteSendNotification()
        {
            _toastProvider.NotificationService.AddNotification(Flattinger.Core.Enums.ToastType.ERROR, "Fehler bei der Anmeldung", "Bei deiner automatischen Anmeldung ist etwas schief gelaufen. Möglicherweise hast du dein Passwort bei einem anderen Konto geändert", 400, new List<IToastButton>
            {
                new ToastButton() { Foreground=Brushes.Black, Content="Zur Anmeldung", OnButtonClick = new Action(() => ExecuteSendNotification())},
                new ToastButton() { Foreground=Brushes.Orange, Content="Später errinern"},
                new ToastButton() { Foreground=Brushes.Orange, Content="Später errinern"},
                new ToastButton() { Foreground=Brushes.Orange, Content="Später errinern"},
            });
            _toastProvider.NotificationService.AddNotification(Flattinger.Core.Enums.ToastType.INFO, "2FA Aktivierung", "Um dein Konto besser zu schützen haben wir für dich eine 2-Faktor Auth. implementiert", 10);
        }
    }
}
