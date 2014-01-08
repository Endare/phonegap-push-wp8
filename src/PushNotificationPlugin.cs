using System;
using System.Diagnostics;
using System.Net;
using System.Text;
using Microsoft.Phone.Notification;
using WPCordovaClassLib.CordovaLib;

namespace WPCordovaClassLib.Cordova.Commands
{
    public class PushNotificationPlugin : BaseCommand
    {
        private HttpNotificationChannel pushChannel;
        private ConfigHandler configHandler = new ConfigHandler();

        private WebClient webClient = new WebClient();

        public override void OnInit() 
        {
            configHandler.LoadAppPackageConfig();

            string channelName = "UAPush";

            // Try to find the push channel.
            pushChannel = HttpNotificationChannel.Find(channelName);

            // If the channel was not found, then create a new connection to the push service.
            if (pushChannel == null)
            {
                pushChannel = new HttpNotificationChannel(channelName);

                // Register for all the events before attempting to open the channel.
                pushChannel.ChannelUriUpdated += new EventHandler<NotificationChannelUriEventArgs>(PushChannel_ChannelUriUpdated);
                pushChannel.ErrorOccurred += new EventHandler<NotificationChannelErrorEventArgs>(PushChannel_ErrorOccurred);

                pushChannel.Open();

                // Bind this new channel for toast events.
                pushChannel.BindToShellToast();
            }
            else
            {
                // The channel was already open, so just register for all the events.
                pushChannel.ChannelUriUpdated += new EventHandler<NotificationChannelUriEventArgs>(PushChannel_ChannelUriUpdated);
                pushChannel.ErrorOccurred += new EventHandler<NotificationChannelErrorEventArgs>(PushChannel_ErrorOccurred);

                this.RegisterDevice(pushChannel.ChannelUri);
            }
        }

        public void GetIncoming(string notused) 
        {
            DispatchCommandResult(new PluginResult(PluginResult.Status.OK, "{}"));
        }

        #region event listeners
        void PushChannel_ChannelUriUpdated(object sender, NotificationChannelUriEventArgs e)
        {
            this.RegisterDevice(e.ChannelUri);
        }

        void PushChannel_ErrorOccurred(object sender, NotificationChannelErrorEventArgs e)
        {
            Debug.WriteLine(String.Format("A push notification {0} error occurred.  {1} ({2}) {3}", e.ErrorType, e.Message, e.ErrorCode, e.ErrorAdditionalData));
        }
        #endregion

        #region registration process
        /// <summary>
        /// This method will register the device at Urban Airship.
        /// </summary>
        /// <param name="uri">The URI of the channel</param>
        private void RegisterDevice(Uri uri)
        {
            string token = uri.Segments[uri.Segments.Length-1];

            string registrationUri = configHandler.GetPreference("eu.endare.push.registration_uri");
            string key = configHandler.GetPreference("eu.endare.push.app_key");
            string secret = configHandler.GetPreference("eu.endare.push.app_secret");

            string json = "{\"platform\": \"Windows Phone 8\", \"token\": \"" + token + "\"}";

            webClient.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(key + ":" + secret));
            webClient.Headers["Content-Type"] = "application/json";
            webClient.UploadStringCompleted += webClient_UploadStringCompleted;
            webClient.UploadStringAsync(new Uri(registrationUri), "POST", json);
        }

        void webClient_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            
        }
        #endregion
    }
}