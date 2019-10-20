using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class alarmSetting : MonoBehaviour
{
    Button btn;
    bool check;
    // Start is called before the first frame update
    void Start()
    {
        btn = this.gameObject.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
        if(PlayerPrefs.GetInt("nofication", 0) == 0)
        {
            check = false;
            print("close alarm");
            btn.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/alarm_off");
        }
        else
        {
            check = true;
            btn.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/alarm_on");
        }
    }

   
    void OnClick()
    {
        if (!check)
        {
            print("open alarm");
            check = true;
            btn.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/alarm_on");
            
        }
        else
        {
            print("close alarm");
            check = false;
            btn.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/alarm_off");
        }
    }
    
}
