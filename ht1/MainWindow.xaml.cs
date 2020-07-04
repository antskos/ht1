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

namespace ht1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CloseCmd_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



        private void SendMessageButton_Click(object sender, RoutedEventArgs e)
        {
            using (var letter = new EmailSendServiceClass())
            {
                try
                {
                    //var letter = new EmailSendServiceClass();
                    if (UserNameTextBox.Text != "") letter.DefineMailFromTo(UserNameTextBox.Text, "ant.sckosyrsckij@yandex.ru");
                    letter.CreateMailText();
                    letter.SendMail(PasswordEdit.Password.ToString());
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "При отправке сообщения возникла ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    //var dlg = new MessageSendCompletedDlg(exception.Message);
                    //dlg.ShowDialog();
                }
            }
        }

    }
}
