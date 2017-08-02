using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanford.Multimedia.Midi;
using MidiWrapper;

namespace WpfApplication1
{
    class MidiInputDevice : InputDevice, IMidiInput
    {
        // public event EventHandler<ChannelMessageEventArgs> ChannelMessageReceived;
        public MidiInputDevice(int deviceID) : base(deviceID)
        {
        }

        //int IMidiInput.DeviceCount {
        //    get => throw new NotImplementedException();
        //    set => throw new NotImplementedException();
        //}

        public void StartListening()
        {
            this.StartRecording();
        }

        public void StopListening()
        {
            this.StopRecording();
        }
    }
}
