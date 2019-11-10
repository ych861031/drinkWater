using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;



public class BackToHome : MonoBehaviour
{

    Button btn;
    // Start is called before the first frame update
    void Start()
    {
        btn = this.gameObject.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        Basic.ARCanvas.SetActive(false);
        Basic.HomeCanvas.SetActive(true);
        Basic.SetHomeBloodStripText();
        Basic.SetHomeBloodStrip();

        Basic.SetHomeBloodStrip2();
        Basic.UpdateHomeBar2Text();
        //update calender
        CalendarSetting.SetCalender(DateTime.Now.Year,DateTime.Now.Month);
    }
    
}
