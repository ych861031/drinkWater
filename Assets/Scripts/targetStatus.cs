using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class targetStatus : MonoBehaviour
{
    Image image;
    GameObject btn;
    GameObject CanOBJ;

    // Start is called before the first frame update
    void Start()
    {
        image = GameObject.Find("FindBottleImage").GetComponent<Image>();
        btn = GameObject.Find("ConfirmButton");
        InvokeRepeating("Check", 0, (float)0.01);

        CanOBJ = GameObject.Find("CanOBJ");

    }
    public static bool Target1_found;
    public static bool Target2_found;

    void Check()
    {
        if (Target1_found)
        {
            image.enabled = false;
            btn.SetActive(true);
        }
        else
        {
            image.enabled = true;
            btn.SetActive(false);
        }

        if (Target2_found)
        {
            CanOBJ.SetActive(true);
        }
        else
        {
            CanOBJ.SetActive(false);
        }
    }
}
