using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class click : MonoBehaviour
{
    Button btn;
    // Start is called before the first frame update
    void Start()
    {
        btn = GameObject.Find("SaveButton").GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClick()
    {
        print("Save Info");
        UserInfo.SetInfo();
        UserInfo.UpdateInfo();
        Back();
    }

    void Back()
    {
        print("back");
        Basic.SettingCanvas.SetActive(false);
        Basic.HomeCanvas.SetActive(true);
        Basic.SetHomeBloodStripText();
    }

}
