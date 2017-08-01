using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanford.Multimedia.Midi;

namespace MidiWrapper
{
    //
    // Summary:
    //     Defines constants for ChannelMessage types.
    public enum ChannelCommand
    {
        //
        // Summary:
        //     Represents the note-off command type.
        NoteOff = 128,
        //
        // Summary:
        //     Represents the note-on command type.
        NoteOn = 144,
        //
        // Summary:
        //     Represents the poly pressure (aftertouch) command type.
        PolyPressure = 160,
        //
        // Summary:
        //     Represents the controller command type.
        Controller = 176,
        //
        // Summary:
        //     Represents the program change command type.
        ProgramChange = 192,
        //
        // Summary:
        //     Represents the channel pressure (aftertouch) command type.
        ChannelPressure = 208,
        //
        // Summary:
        //     Represents the pitch wheel command type.
        PitchWheel = 224
    }

    //
    // Summary:
    //     Defines constants representing MIDI message types.
    public enum MessageType
    {
        Channel = 0,
        SystemExclusive = 1,
        SystemCommon = 2,
        SystemRealtime = 3,
        Meta = 4,
        Short = 5
    }

    public interface IMidiInput
    {
        event EventHandler<ChannelMessageEventArgs> ChannelMessageReceived;
      //  int DeviceCount { get; set; }
        void StartListening();
        void StopListening();
    }

    public interface IMidiOutput
    {
        void Send(IChannelMessage message);
    }

    public interface IChannelMessage
    {

        //
        // Summary:
        //     Gets the channel command value.
        ChannelCommand Command { get; }
        //
        // Summary:
        //     Gets the MIDI channel.
        int MidiChannel { get; }
        //
        // Summary:
        //     Gets the first data value.
        int Data1 { get; }
        //
        // Summary:
        //     Gets the second data value.
        int Data2 { get; }
        //
        // Summary:
        //     Gets the EventType.
        MessageType MessageType { get; }
    }
}
