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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace EarTrumpet.Actions.Views
{

    /// <summary>
    /// Interaction logic for AppVolumeDialog.xaml
    /// </summary>
    public partial class AppVolumeDialog : Window
    {
        private DispatcherTimer _dialogTimer = new DispatcherTimer();

        public AppVolumeDialog()
        {
            InitializeComponent();

            DataContextChanged += DialogOpened;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var desktopWorkingArea = SystemParameters.WorkArea;
            Left = desktopWorkingArea.Right / 2 - (Width / 2);
            Top = desktopWorkingArea.Bottom - Height;
        }

        private void DialogOpened(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(DataContext == null)
            {
                return;
            }
            Visibility = Visibility.Visible;
            Opacity = 1;
            BeginAnimation(Window.OpacityProperty, null);
            _dialogTimer.Interval = TimeSpan.FromSeconds(2);
            _dialogTimer.Start();
            _dialogTimer.Tick += CloseDialog;
        }
    

        public void CloseDialog(object sender, EventArgs e)
        {
            _dialogTimer.Stop();

            var anim = new DoubleAnimation(0, (Duration)TimeSpan.FromSeconds(0.5))
            {
                FillBehavior = FillBehavior.Stop
            };
            anim.Completed += (s, _) =>
            {
                if(Opacity != 1)
                {
                    Visibility = Visibility.Hidden;
                }                
            };

            BeginAnimation(Window.OpacityProperty, anim);
        }

        public void RestartTimer()
        {
            _dialogTimer.Stop();
            _dialogTimer.Start();
        }
    }
}
