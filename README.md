# SimplePlugin
Simple plugin architecture demo. Demonstrates using a simple protocol to load an 
assembly dynamically, resolve a known bootstrap interface to add the plugin 
implementation to an IoC container, then use that plugin implementation directly. 

I purposely used multiple different techniques to implement the plugin, to show 
that the actual implementation is essentially opaque to the end user. The important 
part is the conventions are being adhered to.

## Usage
To use this demo, you need to first let nuget resolve the dependencies, then build 
all the projects. The code is set-up so that everything is using relative paths. The
plugins are set to automagically copy to the bin\debug folder for the test app. At
the moment we can only load one plugin at a time - it would be trivial to make 
multiples load, but the limitations of usin the IoC container would make resolving the
correct plugin a little more involved, so that is left as an exercide to the user.

To alter which plugin is being loaded - edit the app.config for the main test app. All 
you will need to do is change the referenced assembly (dll) name. Make sure you add the 
".dll" extension, as we don't handle that in code (again, trivial to add.)

## Why?
I threw this together one evening at home as a quick tech demo for a project at work. 
It seemed like a nice example so I threw it up here. Hopefully it'll help someone.


