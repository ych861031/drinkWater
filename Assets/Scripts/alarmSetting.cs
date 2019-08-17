using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class alarmSetting : MonoBehaviour
{
    Button btn;
    // Start is called before the first frame update
    void Start()
    {
        btn = this.gameObject.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    bool check = false;
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
