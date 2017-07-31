using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanford.Multimedia.Midi;
using System.Net;
using System.Threading;
using Rug.Osc;

namespace MidiWrapper
{
    class OSCMidiInputDevice : IMidiInput
    {
        public event EventHandler<ChannelMessageEventArgs> ChannelMessageReceived;
        private static Rug.Osc.OscReceiver receiver = new Rug.Osc.OscReceiver(IPAddress.Parse("127.0.0.1"), 1701);
        private static System.Threading.Thread thread;

        public OSCMidiInputDevice()
        {
            thread = new Thread(new ThreadStart(ListenLoop));

            // Connect the receiver
            receiver.Connect();

            // Start the listen thread
            thread.Start();
        }

        public void StartListening()
        {
            receiver.Connect();
        }

        public void StopListening()
        {
            receiver.Close();
        }

        static void ListenLoop()
        {
            try
            {
                while (receiver.State != OscSocketState.Closed)
                {
                    // if we are in a state to recieve
                    if (receiver.State == OscSocketState.Connected)
                    {
                        // get the next message 
                        // this will block until one arrives or the socket is closed
                        OscPacket packet = receiver.Receive();

                        // Write the packet to the console 
                        Console.WriteLine(packet.ToString());

                        
                        // DO SOMETHING HERE!
                    }
                }
            }
            catch (Exception ex)
            {
                // if the socket was connected when this happens
                // then tell the user
                if (receiver.State == OscSocketState.Connected)
                {
                    Console.WriteLine("Exception in listen loop");
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
