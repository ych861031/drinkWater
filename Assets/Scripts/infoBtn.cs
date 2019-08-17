using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class infoBtn : MonoBehaviour
{
    Button btn;
    GameObject info;
    // Start is called before the first frame update
    void Start()
    {
        btn = this.gameObject.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);

        info = GameObject.Find("InfoImage");
        info.SetActive(false);
    }

    bool check = false;
    void OnClick()
    {
        if (!check)
        {
            check = true;
            info.SetActive(true);

        }
        else
        {
            check = false;
            info.SetActive(false);

        }
    }
   
}
