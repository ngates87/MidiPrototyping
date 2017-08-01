using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanford.Multimedia.Midi;
using Rug.Osc;
using System.Net;
using System.Threading;

namespace MidiWrapper
{
    public class OSCMidiOutputDevice : IMidiOutput, IDisposable
    {
        private Rug.Osc.OscSender sender;

        public OSCMidiOutputDevice()
        {
            this.sender = new OscSender(IPAddress.Parse("127.0.0.1"), 1701);
        }

        public void Send(IChannelMessage message)
        {
            //new OscMessage("/midi", )
            sender.Send(new OscMessage("/midi",
                (int)message.Command,
                (int)message.MessageType,
                message.MidiChannel,
                message.Data1,
                message.Data2));
        }

        public void Dispose()
        {
            if (this.sender != null)
            {
                this.sender.Dispose();
                this.sender = null;
            }
        }
    }
}
