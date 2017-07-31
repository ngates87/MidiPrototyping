using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanford.Multimedia.Midi;

namespace WpfApplication1
{
    class MidiOutputDevice : InputDevice, IMidiInput
    {
        // public event EventHandler<ChannelMessageEventArgs> ChannelMessageReceived;
        public MidiOutputDevice(int deviceID) : base(deviceID)
        {
        }
    }
}
