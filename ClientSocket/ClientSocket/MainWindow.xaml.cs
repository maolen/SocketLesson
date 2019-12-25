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
using System.Net.Sockets;
using System.Net;

namespace ClientSocket
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SendNetMessage(object sender, RoutedEventArgs e)
        {
            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                var endPoint = new IPEndPoint(IPAddress.Parse("10.1.4.46"), 3132);
                socket.Connect(endPoint);

                var buffer = Encoding.UTF8.GetBytes(messageTextBox.Text);
                messageTextBox.Text = string.Empty;
                socket.Send(buffer);
                socket.Shutdown(SocketShutdown.Both);
            }
        }
    }
}
