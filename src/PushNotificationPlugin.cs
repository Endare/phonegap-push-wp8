using System;
using WPCordovaClassLib.Cordova;
using WPCordovaClassLib.Cordova.Commands;
using WPCordovaClassLib.Cordova.JSON;

namespace WPCordovaClassLib.Cordova.Commands
{
    public class PushNotificationPlugin : BaseCommand
    {
        public void add(String test) 
        {
            DispatchCommandResult(new PluginResult(PluginResult.Status.OK, "Everything went as planned, this is a result that is passed to the success handler."));
        }
    }
}