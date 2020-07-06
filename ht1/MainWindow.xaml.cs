using System;
using System.Windows;


namespace MailSender
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
            var letter = new EmailSendServiceClass();
            
            try
            {
                //var letter = new EmailSendServiceClass();
                if (UserNameTextBox.Text != "") letter.DefineMailFromTo(UserNameTextBox.Text, "antskos@gmail.com");
                letter.CreateMailText();
                letter.SendMail(UserPasswordBox.SecurePassword);
                MessageBox.Show("Почта успешно отправлена", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

    }
}
