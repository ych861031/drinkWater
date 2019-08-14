using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class bloodstrip : MonoBehaviour
{
    static GameObject strip;
    static GameObject HomeStrip;

    static float user_blood;
    static int basic_length = 450;


    // Start is called before the first frame update
    void Start()
    {
        strip = GameObject.Find("Bloodstrip");
        HomeStrip = GameObject.Find("BloodstripHome");
    }

    public static void SetBloodStrip()
    {
        var t = UserInfo.GetTotalDrink();
        var s = UserInfo.GetDrinkScore();
        user_blood = s / t;

        var blood_length = basic_length * user_blood - basic_length;
        print(blood_length);
        strip.GetComponent<Transform>().localPosition = new Vector2(blood_length, 0);

        if (user_blood < 1)
        {
            strip.GetComponent<Transform>().localPosition = new Vector2(blood_length, 0);
        }
        else
        {
            strip.GetComponent<Transform>().localPosition = new Vector2(0, 0);
        }
    }

    public static void SetHomeBloodStrip()
    {
        var t = UserInfo.GetTotalDrink();
        var s = UserInfo.GetDrinkScore();
        user_blood = s / t;

        var blood_length = basic_length * user_blood - basic_length;

        if (user_blood < 1)
        {
            HomeStrip.GetComponent<Transform>().localPosition = new Vector2(blood_length, 0);
        }
        else
        {
            HomeStrip.GetComponent<Transform>().localPosition = new Vector2(0, 0);
        }
        
    }
    
}
