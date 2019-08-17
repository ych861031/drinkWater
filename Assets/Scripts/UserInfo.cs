using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class UserInfo : MonoBehaviour
{
    static float weight;
    static int drink;

    static GameObject WeightPlaceholder;
    static GameObject DrinkPlaceholder;
    static GameObject WeightText;
    static GameObject DrinkText;

    static GameObject tree1;
    static GameObject tree2;
    static GameObject tree3;
    static GameObject tree4;


    // Start is called before the first frame update
    void Start()
    {
        WeightPlaceholder = GameObject.Find("WeightPlaceholder");
        DrinkPlaceholder = GameObject.Find("DrinkPlaceholder");
        WeightText = GameObject.Find("WeightInputField");
        DrinkText = GameObject.Find("DrinkInputField");
        var date = GetDate();

        //測試時重設數據用
        PlayerPrefs.SetInt(date + "DrinkScore", 0);

        //default calendaer use image level
        PlayerPrefs.SetInt("201981" + "DrinkScoreLevel", 2);
        PlayerPrefs.SetInt("201983" + "DrinkScoreLevel", 4);
        PlayerPrefs.SetInt("201988" + "DrinkScoreLevel", 1);
        PlayerPrefs.SetInt("2019815" + "DrinkScoreLevel", 3);
        PlayerPrefs.SetInt("2019818" + "DrinkScoreLevel", 2);
        PlayerPrefs.SetInt("2019819" + "DrinkScoreLevel", 4);
        PlayerPrefs.SetInt("2019825" + "DrinkScoreLevel", 1);
        PlayerPrefs.SetInt("2019831" + "DrinkScoreLevel", 3);


        UpdateInfo();

        //Tree object
        tree1 = GameObject.Find("樹01");
        tree2 = GameObject.Find("樹02");
        tree3 = GameObject.Find("樹03");
        tree4 = GameObject.Find("樹04");

        SetARTree();
    }

    public static void SetInfo()
    {
        print("set");
        var weightText = WeightText.GetComponent<InputField>().text;
        var drinkText = DrinkText.GetComponent<InputField>().text;
        print(weightText);
        print(drinkText);

        if(weightText != "")
        {
            PlayerPrefs.SetFloat("playerWeight", float.Parse(weightText));
        }

        if (drinkText != "")
        {
            PlayerPrefs.SetInt("playerDrink", int.Parse(drinkText));
        }
        
    }

    static string GetDate()
    {
        return DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
    }

    public static void UpdateInfo()
    {
        print("Update...");

        weight = PlayerPrefs.GetFloat("playerWeight", 60);
        print(weight);
        WeightPlaceholder.GetComponent<Text>().text = weight.ToString() + "kg";

        drink = PlayerPrefs.GetInt("playerDrink", 200);
        print(drink);

        DrinkPlaceholder.GetComponent<Text>().text = drink.ToString() + "cc";

        //Clear input text
        WeightText.GetComponent<InputField>().text = "";
        DrinkText.GetComponent<InputField>().text = "";
    }

    public static float GetTotalDrink()
    {
        var weight = PlayerPrefs.GetFloat("playerWeight", 60);

        return weight * 30;
    }

    public static string GetDrinkScoreStr()
    {
        var date = GetDate();
        var score = PlayerPrefs.GetInt(date + "DrinkScore", 0);
        string str = score.ToString() + "/" + GetTotalDrink().ToString();

        return str;
    }

    public static int GetDrinkScore()
    {
        var date = GetDate();
        var score = PlayerPrefs.GetInt(date + "DrinkScore", 0);
       

        return score;
    }

    public static void AddDrinkScore()
    {
        var date = GetDate();
        var addScore = PlayerPrefs.GetInt("playerDrink", 200);
        var score = PlayerPrefs.GetInt(date + "DrinkScore", 0);
        PlayerPrefs.SetInt(date + "DrinkScore", score + addScore);

        //set level
        score = PlayerPrefs.GetInt(date + "DrinkScore", 0);
        if (score<=800 && score >0)
        {
            PlayerPrefs.SetInt(date + "DrinkScoreLevel", 1);
        }
        if (score <= 1600 && score > 800)
        {
            PlayerPrefs.SetInt(date + "DrinkScoreLevel", 2);
        }
        if (score <= 2000 && score > 1600)
        {
            PlayerPrefs.SetInt(date + "DrinkScoreLevel", 3);
        }
        if (score >= 2000)
        {
            PlayerPrefs.SetInt(date + "DrinkScoreLevel", 4);
        }

        Basic.SetARBloodStripText();
        bloodstrip.SetBloodStrip();
    }

    void SetTodayScore()
    {

    }

    public static void SetARTree()
    {
        var t = GetTotalDrink();
        var s = GetDrinkScore();
        var user_blood = s / t;

        if (user_blood < 0.3)
        {
            tree1.SetActive(true);
            tree2.SetActive(false);
            tree3.SetActive(false);
            tree4.SetActive(false);

        }
        else if(user_blood < 0.5)
        {
            tree1.SetActive(false);
            tree2.SetActive(true);
            tree3.SetActive(false);
            tree4.SetActive(false);
        }
        else if(user_blood < 0.9)
        {
            tree1.SetActive(false);
            tree2.SetActive(false);
            tree3.SetActive(true);
            tree4.SetActive(false);
        }
        else
        {
            tree1.SetActive(false);
            tree2.SetActive(false);
            tree3.SetActive(false);
            tree4.SetActive(true);
        }
    }
}
