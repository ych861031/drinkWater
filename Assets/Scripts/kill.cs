using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kill : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("check",0,1);

    }

    void check()
    {
        if(this.transform.localPosition.y < -100)
        {
            print("kill");
            Destroy(this);
        }
    }
}
