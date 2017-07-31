//using Midi;
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
using Sanford.Multimedia.Midi;
using Rug.Osc;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IDisposable
    {
        public Sanford.Multimedia.Midi.InputDevice inputDevice = null;
        public Sanford.Multimedia.Midi.OutputDevice sanfordOutputDevice = null;
        public Rug.Osc.OscSender oscSender = new Rug.Osc.OscSender(System.Net.IPAddress.Parse("127.0.0.1"), 6666);

        public MainWindow()
        {
            InitializeComponent();

            try
            {
                this.sanfordOutputDevice = new Sanford.Multimedia.Midi.OutputDevice(2);

                var count = Sanford.Multimedia.Midi.InputDevice.DeviceCount;

                inputDevice = new Sanford.Multimedia.Midi.InputDevice(0);
                inputDevice.StartRecording();
                inputDevice.ChannelMessageReceived += InputDevice_ChannelMessageReceived;
                inputDevice.SysExMessageReceived += InputDevice_SysExMessageReceived;
                inputDevice.ShortMessageReceived += InputDevice_ShortMessageReceived;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }

            this.oscSender.Connect();

        }

        private void InputDevice_ShortMessageReceived(object sender, ShortMessageEventArgs e)
        {
            Console.WriteLine(e);
        }

        private void InputDevice_SysExMessageReceived(object sender, SysExMessageEventArgs e)
        {
            Console.WriteLine(e);
        }

        private void InputDevice_ChannelMessageReceived(object sender, ChannelMessageEventArgs e)
        {
            if (e != null)
            {
                var offset = 0;

                switch (e.Message.Data1)
                {
                    case 78:
                        offset = 128;
                        break;
                    case 79:
                        offset = 256;
                        break;
                    case 80:
                        offset = 384;
                        break;
                    case 81:
                        offset = 512;
                        break;
                    case 82:
                        offset = 640;
                        break;
                    case 83:
                        offset = 768;
                        break;
                    case 84:
                        offset = 896;
                        break;
                    case 77:
                    default:
                        break;
                }

                this.CurrentCue.Content = e.Message.Data2 + offset;
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sanfordOutputDevice.Send(new Sanford.Multimedia.Midi.ChannelMessage(ChannelCommand.Controller, 0, 77, 0));

            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int cue;
            if (int.TryParse(this.cueN.Text, out cue))
            {
                sanfordOutputDevice.Send(new Sanford.Multimedia.Midi.ChannelMessage(ChannelCommand.Controller, 0, 77, cue));
            }
        }

        public void Dispose()
        {
            if (this.inputDevice != null)
            {
                this.inputDevice.StopRecording();
                this.inputDevice.Dispose();
                this.inputDevice = null;
            }

            if (this.sanfordOutputDevice != null)
            {
                this.sanfordOutputDevice.Dispose();
                this.sanfordOutputDevice = null;
            }
        }

        private void sendOSCMessage_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.oscMessage.Text))
                return;
            //var packet = Rug.Osc.OscPacket.Parse(this.oscMessage.Text);
            // var parsed = OscMessage.Parse(this.oscMessage.Text);

            var message = this.oscMessage.Text.Split(' ');

            if (message.Length <= 0)
                return;

            var address = message[0];

            if(message.Length <= 1)
            {
                oscSender.Send(new OscMessage(message[0]));

            }
            else
            {
                // oscSender.Send(new OscMessage(message[0], message.Skip(1).Cast<int>().ToArray()));
                oscSender.Send(new OscMessage("/sourcepreset", 1));
            }
        }
    }
}
