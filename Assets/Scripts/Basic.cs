using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Basic : MonoBehaviour
{
    public static GameObject HomeCanvas;
    public static GameObject SettingCanvas;
    public static GameObject ARCanvas;

    Button settingBtn;
    Button ARBtn;

    // Start is called before the first frame update
    void Start()
    {
        HomeCanvas = GameObject.Find("HomeCanvas");

        SettingCanvas = GameObject.Find("SettingCanvas");

        ARCanvas = GameObject.Find("ARCanvas");
        

        settingBtn = GameObject.Find("SettingButton").GetComponent<Button>();
        settingBtn.onClick.AddListener(MoveSetting);

        ARBtn = GameObject.Find("ARButton").GetComponent<Button>();
        ARBtn.onClick.AddListener(MoveAR);

        Invoke("CloseCanvas", (float)1);

        SetHomeBloodStripText();
        SetHomeBloodStrip();
    }

    void CloseCanvas()
    {
        print("close basic canvas");
        SettingCanvas.SetActive(false);
        ARCanvas.SetActive(false);
    }

    void MoveSetting()
    {
        SettingCanvas.SetActive(true);
        HomeCanvas.SetActive(false);
    }

    void MoveAR()
    {
        print("open AR");
        ARCanvas.SetActive(true);
        SetARBloodStripText();
        bloodstrip.SetBloodStrip();
        HomeCanvas.SetActive(false);
    }

    public static void SetHomeBloodStripText()
    {
        print(UserInfo.GetDrinkScoreStr());
        GameObject.Find("HomeStripStatus").GetComponent<Text>().text = UserInfo.GetDrinkScoreStr();
    }

    public static void SetARBloodStripText()
    {
        GameObject.Find("ARStripStatus").GetComponent<Text>().text = UserInfo.GetDrinkScoreStr();
    }

    public static void SetHomeBloodStrip()
    {
        bloodstrip.SetHomeBloodStrip();
    }
}
