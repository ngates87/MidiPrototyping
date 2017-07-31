using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiWrapper
{
    class ChannelMessage : IChannelMessage
    {
        private ChannelCommand command;
        ChannelCommand IChannelMessage.Command
        {
            get
            {
                return command;
            }
        }

        private int midiChannel = 0;
        int IChannelMessage.MidiChannel
        {
            get
            {
                return midiChannel;
            }
        }

        private int data1;
        int IChannelMessage.Data1
        {
            get
            {
                return data1;
            }
        }

        private int data2;
        int IChannelMessage.Data2
        {
            get
            {
                return data2;
            }
        }

        MessageType IChannelMessage.MessageType => throw new NotImplementedException();

        public ChannelMessage(ChannelCommand command, int midiChannel, int data1)
        {
            this.command = command;
            this.midiChannel = midiChannel;
            this.data1 = data1;

        }

        public ChannelMessage(ChannelCommand command, int midiChannel, int data1, int data2) :
            this(command, midiChannel, data1)
        {
            this.data2 = data2;
        }

    }
}
