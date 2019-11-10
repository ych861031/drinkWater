using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Confirm : MonoBehaviour
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
        UserInfo.AddDrinkScore();
        UserInfo.SetARTree();

        getTime.setTime();

        GameObject.Find("ConfirmButton").SetActive(false);
    }

   
}
