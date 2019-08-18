using System;
using System.IO;
using UnityEngine;
#if UNITY_IOS
using System.Runtime.InteropServices;
#endif
using System.Collections.Generic;

public class LocalNotification
{
#if UNITY_ANDROID && !UNITY_EDITOR
   private static string fullClassName = "net.agasper.unitynotification.UnityNotificationManager";
   private static string actionClassName = "net.agasper.unitynotification.NotificationAction";
#endif

#if UNITY_5_6_OR_NEWER
    private static string bundleIdentifier { get { return Application.identifier; } }
#else
    private static string bundleIdentifier { get { return Application.bundleIdentifier; } }
#endif

    public static int SendNotification(int id, long delayMs, string title, string message, Color32 bgColor, bool sound = true, bool vibrate = true, bool lights = true, string bigIcon = "", String soundName = null, string channel = "default", params Action[] actions)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
       AndroidJavaClass pluginClass = new AndroidJavaClass(fullClassName);
       if (pluginClass != null)
       {
           pluginClass.CallStatic("SetNotification", id, delayMs, title, message, message,
               sound ? 1 : 0, soundName, vibrate ? 1 : 0, lights ? 1 : 0, bigIcon, "notify_icon_small",
               ToInt(bgColor), bundleIdentifier, channel, PopulateActions(actions));
       }
       return id;
#else
        return 0;
#endif
    }

    public static int SendRepeatingNotification(int id, long delayMs, long timeoutMs, string title, string message, Color32 bgColor, bool sound = true, bool vibrate = true, bool lights = true, string bigIcon = "", String soundName = null, string channel = "default", params Action[] actions)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
       AndroidJavaClass pluginClass = new AndroidJavaClass(fullClassName);
       if (pluginClass != null)
       {
           pluginClass.CallStatic("SetRepeatingNotification", id, delayMs, title, message, message, timeoutMs,
               sound ? 1 : 0, soundName, vibrate ? 1 : 0, lights ? 1 : 0, bigIcon, "notify_icon_small",
               ToInt(bgColor), bundleIdentifier, channel, PopulateActions(actions));
       }
       return id;
#else
        return 0;
#endif
    }

    public static void CancelNotification(int id)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
       AndroidJavaClass pluginClass = new AndroidJavaClass(fullClassName);
       if (pluginClass != null) {
           pluginClass.CallStatic("CancelPendingNotification", id);
       }
#endif
    }

    public static void ClearNotifications()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
       AndroidJavaClass pluginClass = new AndroidJavaClass(fullClassName);
       if (pluginClass != null) {
           pluginClass.CallStatic("ClearShowingNotifications");
       }
#endif
    }

    /// This allows you to create a custom channel for different kinds of notifications.
    /// Channels are required on Android Oreo and above. If you don't call this method, a channel will be created for you with the configuration you give to SendNotification.
    public static void CreateChannel(string identifier, string name, string description, Color32 lightColor, bool enableLights = true, string soundName = null, Importance importance = Importance.Default, bool vibrate = true, long[] vibrationPattern = null)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
       AndroidJavaClass pluginClass = new AndroidJavaClass(fullClassName);
       if (pluginClass != null)
       {
           pluginClass.CallStatic("CreateChannel", identifier, name, description, (int) importance, soundName, enableLights ? 1 : 0, ToInt(lightColor), vibrate ? 1 : 0, vibrationPattern, bundleIdentifier);
       }
#endif
    }

    public enum Importance
    {
        /// Default notification importance: shows everywhere, makes noise, but does not visually intrude.
        Default = 3,

        /// Higher notification importance: shows everywhere, makes noise and peeks. May use full screen intents.
        High = 4,

        /// Low notification importance: shows everywhere, but is not intrusive.
        Low = 2,

        /// Unused.
        Max = 5,

        /// Min notification importance: only shows in the shade, below the fold. This should not be used with Service.startForeground since a foreground service is supposed to be something the user cares about so it does not make semantic sense to mark its notification as minimum importance. If you do this as of Android version O, the system will show a higher-priority notification about your app running in the background.
        Min = 1,

        /// A notification with no importance: does not show in the shade.
        None = 0
    }

    public class Action
    {
        public Action(string identifier, string title, MonoBehaviour handler)
        {
            this.Identifier = identifier;
            this.Title = title;
            if (handler != null)
            {
                this.GameObject = handler.gameObject.name;
                this.HandlerMethod = "OnAction";
            }
        }

        public string Identifier;
        public string Title;
        public string Icon;
        public bool Foreground = true;
        public string GameObject;
        public string HandlerMethod;
    }

    private static int ToInt(Color32 color)
    {
        return color.r * 65536 + color.g * 256 + color.b;
    }

#if UNITY_ANDROID && !UNITY_EDITOR
   private static AndroidJavaObject PopulateActions(Action[] actions)
   {
       AndroidJavaObject actionList = null;
       if (actions.Length > 0)
       {
           actionList = new AndroidJavaObject("java.util.ArrayList");
           for (int i = 0; i < actions.Length; i++)
           {
               var action = actions[i];
               using (AndroidJavaObject notificationObject = new AndroidJavaObject(actionClassName))
               {
                   notificationObject.Call("setIdentifier", action.Identifier);
                   notificationObject.Call("setTitle", action.Title);
                   notificationObject.Call("setIcon", action.Icon);
                   notificationObject.Call("setForeground", action.Foreground);
                   notificationObject.Call("setGameObject", action.GameObject);
                   notificationObject.Call("setHandlerMethod", action.HandlerMethod);
                   actionList.Call<bool>("add", notificationObject);
               }
           }
       }
       return actionList;
   }
#endif
}