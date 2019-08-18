using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

namespace Assets.SimpleAndroidNotifications
{
    public class NotificationScript : MonoBehaviour
    {
        Button btn;
        void Start()
        {
            print("nofication start");
            btn = GameObject.Find("AlarmButton").GetComponent<Button>();
            btn.onClick.AddListener(SendNotification);
        }


        public void SendNotification()
        {
            print("喝水通知");
            NotificationManager.Send(TimeSpan.FromSeconds(2),
                "喝水通知",
                "設定的喝水時間到了~記得喝水唷~",
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

