using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Assets.SimpleAndroidNotifications
{
    public class NotificationScript : MonoBehaviour
    {
        public void SendNotification()
        {
            NotificationManager.Send(TimeSpan.FromSeconds(2),
                "Notification",
                "Ring!Ring!Ring!",
                Color.white);
        }

        public void ScheduleCustom()
        {
            var notificationParams = new NotificationParams
            {
                Id = UnityEngine.Random.Range(0, int.MaxValue),
                Delay = TimeSpan.FromSeconds(2),
                Title = "Custom notification",
                Message = "Rember Drink Water",
                Ticker = "Ticker",
                Sound = true,
                Vibrate = true,
                Light = true,
                SmallIcon = NotificationIcon.Heart,
                SmallIconColor = new Color(0, 0.5f, 0),
                LargeIcon = "app_icon"
            };

            NotificationManager.SendCustom(notificationParams);
        }

        public void Sleep()
        {
            NotificationManager.Send(TimeSpan.FromSeconds(5),
                "Notification",
                "After 5 Seconds",
                Color.white);
        }

        public void Stop()
        {
            NotificationManager.CancelAll();
        }
    }
}

