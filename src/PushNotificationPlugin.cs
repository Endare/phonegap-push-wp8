using System;
using WPCordovaClassLib.Cordova;
using WPCordovaClassLib.Cordova.Commands;
using WPCordovaClassLib.Cordova.JSON;
using Microsoft.Phone.Notification;
using System.Diagnostics;

namespace WPCordovaClassLib.Cordova.Commands
{
    public class PushNotificationPlugin : BaseCommand
    {
        public PushNotificationPlugin()
        {
            Debug.WriteLine("construct");
        }

        public override void OnInit() 
        {
            Debug.WriteLine("Init");
        }

        public PushNotificationPlugin()
        {
            Debug.WriteLine("construct");
        }
    }
}