﻿using UnityEngine;
using System.Collections;

public class NotificationTest : MonoBehaviour
{
    void Awake()
    {
        LocalNotification.ClearNotifications();
    }

    public void OneTimeWithActions()
    {
        LocalNotification.Action action1 = new LocalNotification.Action("background", "In Background", this);
        action1.Foreground = false;
        LocalNotification.Action action2 = new LocalNotification.Action("foreground", "In Foreground", this);
        LocalNotification.SendNotification(1, 5000, "記得喝水", null, new Color32(0x42, 0xfc, 0x4e, 255), true, true, true, "app_icon", "laugh", "default", action1, action2);
        print("OneTimeWithActions");
    }

    public void Repeating()
    {
        LocalNotification.SendRepeatingNotification(1, 2000, 60000, "Title", "repeating", new Color32(0x42, 0xfc, 0x4e, 255), true, true, true, null, "laugh");
        print("Repeating");
    }

    public void Stop()
    {
        LocalNotification.CancelNotification(1);
        print("Stop");
    }

    public void OnAction(string identifier)
    {
        Debug.Log("Got action " + identifier);
    }
}
