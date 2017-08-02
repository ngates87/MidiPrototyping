# MidiPrototyping
Just playing around with midi and OSC control of VPT7

this may end up a bit of dumping ground for some ideas..


Basically the situation is I have an ETC Express 48/96, that can send and recieve midi commands, so just for fun, expirementing with different apps I could do with this. 


The plan is to create an app (a couple ideas actually) 
  - using C# create a an app that maps a cue # to trigger an OSC command that set's VPT 7 source # or advances tot he next item in the cue list.
  - Using C++ and a Raspberry Pi, create a wireless remote, that can listen to OSC commands to advance the CUE or to serve up a simple web page,
   to allow less OSC knowledgeable user to advance the cue #
  
  
  
  Currently Using:
   - VPT7
   - Sanford Midi C#

One limitation I have learned is that the Express, or rather a likely limation of midi itslef, decimal cue #s are not processed as a ChannelMessage in the Sanford Library
