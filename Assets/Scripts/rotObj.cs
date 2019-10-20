using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotObj : MonoBehaviour
{
    GameObject CanObj;
    // Start is called before the first frame update
    void Start()
    {
        CanObj = GameObject.Find("CanOBJ");
        InvokeRepeating("control",0,1);
    }

    public static bool check = false;
    void control()
    {
        print("control rot obj");
        if (!check)
        {
            Down();
            check = true;
        }
        else
        {
            Up();
            check = false;
        }
    }

    void Up()
    {
        //CanObj.transform.Rotate(0, 0, 70,Space.Self);
        CanObj.transform.rotation = Quaternion.Euler(-90f, -90f, -90f);

    }

    void Down()
    {
        //CanObj.transform.Rotate(0, 0, -70,Space.Self);
        CanObj.transform.rotation = Quaternion.Euler(-55f, -90f, -90f);

    }
}
