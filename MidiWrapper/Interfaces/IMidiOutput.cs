using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanford.Multimedia.Midi;

namespace MidiWrapper
{
    interface IMidiInput
    {
        event EventHandler<ChannelMessageEventArgs> ChannelMessageReceived;

        void StartListening();
        void StopListening();
    }

    interface IMidiOutput
    {

    }
}
