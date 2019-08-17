using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Watering : MonoBehaviour
{
    GameObject position;
    GameObject cube;
    GameObject canObj;
    GameObject image;
    // Start is called before the first frame update
    void Start()
    {
        canObj = GameObject.Find("CanOBJ");
        cube = Resources.Load<GameObject>("UI/Cube").gameObject;
        position = GameObject.Find("basicposition");
        print(position.transform.position);
        InvokeRepeating("CreateWater",0,(float)0.01);

        image = GameObject.Find("FindBottleImage");

    }

    

    void CreateWater()
    {
        print(rotObj.check);
        
        if (rotObj.check & canObj.activeSelf & !image.GetComponent<Image>().enabled)
        {
            print("create");
            Instantiate(cube, new Vector3(position.transform.position.x, position.transform.position.y, position.transform.position.z),new Quaternion(0,0,0,0));
        }
    }
}
