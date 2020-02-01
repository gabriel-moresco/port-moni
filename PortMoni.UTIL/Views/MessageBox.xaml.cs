using System;
using System.Media;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace PortMoni.UTIL.Views
{
    public partial class MessageBox : Window
    {
        MessageBoxCustom.Images _imageType;
        Exception _exception;

        internal MessageBoxCustom.ButtonResult Result { get; set; }

        public MessageBox(string title, string message, MessageBoxCustom.Images images, MessageBoxCustom.ButtonOptions buttonOptions, string auxiliaryButtonText, Exception exception)
        {
            InitializeComponent();

            if (exception == null)
            {
                btn_seeMore.Visibility = Visibility.Hidden;
            }

            this._exception = exception;

            txt_Message.Text = message;
            lbl_Title.Content = title;
            btn_Auxiliary.Content = auxiliaryButtonText;

            _imageType = images;

            SetButtonsConfig(buttonOptions);
            SetImagesConfig();
        }

        void SetImagesConfig()
        {
            switch (_imageType)
            {
                case MessageBoxCustom.Images.None:
                    imageColunm.Width = new GridLength(30);
                    break;
                case MessageBoxCustom.Images.Checked:
                    image.Source = new BitmapImage(new Uri(@"Images\checked.png", UriKind.Relative));
                    break;
                case MessageBoxCustom.Images.Error:
                    image.Source = new BitmapImage(new Uri(@"Images\error.png", UriKind.Relative));
                    break;
                case MessageBoxCustom.Images.Info:
                    image.Source = new BitmapImage(new Uri(@"Images\warning.png", UriKind.Relative));
                    break;
            }
        }

        void SetButtonsConfig(MessageBoxCustom.ButtonOptions buttonOptions)
        {
            if (buttonOptions == MessageBoxCustom.ButtonOptions.OkCancelAuxiliary)
            {

            }
            else if (buttonOptions == MessageBoxCustom.ButtonOptions.OkCancel)
            {
                btn_Auxiliary.Visibility = Visibility.Hidden;
                btn_OkYes.Margin = new Thickness(0, 0, 150, 0);
                btn_CancelNo.Margin = new Thickness(0, 0, 50, 0);
            }
            else if (buttonOptions == MessageBoxCustom.ButtonOptions.Ok)
            {
                btn_CancelNo.Visibility = Visibility.Hidden;
                btn_Auxiliary.Visibility = Visibility.Hidden;
                btn_OkYes.Margin = new Thickness(0, 0, 50, 0);
            }
            else if (buttonOptions == MessageBoxCustom.ButtonOptions.OkAuxiliary)
            {
                btn_CancelNo.Visibility = Visibility.Hidden;
                btn_OkYes.Margin = new Thickness(0, 0, 150, 0);
            }
            else if (buttonOptions == MessageBoxCustom.ButtonOptions.YesNo)
            {
                btn_Auxiliary.Visibility = Visibility.Hidden;
                btn_OkYes.Margin = new Thickness(0, 0, 150, 0);
                btn_CancelNo.Margin = new Thickness(0, 0, 50, 0);

                btn_OkYes.Content = "Sim";
                btn_CancelNo.Content = "Não";
            }
            else if (buttonOptions == MessageBoxCustom.ButtonOptions.YesNoAuxiliary)
            {
                btn_OkYes.Content = "Sim";
                btn_CancelNo.Content = "Não";
            }
        }

        private void Btn_OkYes_Click(object sender, RoutedEventArgs e)
        {
            Result = MessageBoxCustom.ButtonResult.Positive;
            this.Close();
        }

        private void Btn_CancelNo_Click(object sender, RoutedEventArgs e)
        {
            Result = MessageBoxCustom.ButtonResult.Negative;
            this.Close();
        }

        private void Btn_Auxiliary_Click(object sender, RoutedEventArgs e)
        {
            Result = MessageBoxCustom.ButtonResult.Auxiliary;
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            switch (_imageType)
            {
                case MessageBoxCustom.Images.Checked:
                    SystemSounds.Asterisk.Play();
                    break;
                case MessageBoxCustom.Images.Error:
                    SystemSounds.Hand.Play();
                    break;
                case MessageBoxCustom.Images.Info:
                    SystemSounds.Exclamation.Play();
                    break;
            }
        }

        private void Btn_seeMore_Click(object sender, RoutedEventArgs e)
        {
            new ExceptionDetailsWindow(_exception.StackTrace).Show();
        }
    }
}
