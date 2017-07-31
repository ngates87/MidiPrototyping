﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanford.Multimedia.Midi;

namespace WpfApplication1
{
    interface IMidiInput
    {
        event EventHandler<ChannelMessageEventArgs> ChannelMessageReceived;
    }
}