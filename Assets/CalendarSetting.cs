using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CalendarSetting : MonoBehaviour
{
    string year;
    string month;
    Button btnLeft;
    Button btnRight;


    // Start is called before the first frame update
    void Start()
    {
        btnLeft = GameObject.Find("leftBtn").GetComponent<Button>();
        btnRight = GameObject.Find("rightBtn").GetComponent<Button>();
        btnLeft.onClick.AddListener(SubMonth);
        btnRight.onClick.AddListener(AddMonth);

        year = DateTime.Now.Year.ToString();
        month = DateTime.Now.Month.ToString();
        SetCalenderTitle();
        SetCalender(int.Parse(year), int.Parse(month));
    }

    void SetCalenderTitle()
    {
        GameObject.Find("DateTitle").GetComponent<Text>().text = year + "年" + month + "月";
    }

    public static void SetCalender(int year, int month)
    {
        DateTime dateValue = new DateTime(year, month, 1);
        print("date setting");
        print(dateValue.DayOfWeek);

        int startId = -1;
        switch (dateValue.DayOfWeek)
        {
            case DayOfWeek.Sunday:
                print("Sunday");
                startId = 0;
                break;
            case DayOfWeek.Monday:
                print("Monday");
                startId = 1;
                break;
            case DayOfWeek.Tuesday:
                print("Tuesday");
                startId = 2;
                break;
            case DayOfWeek.Wednesday:
                print("Wednesday");
                startId = 3;
                break;
            case DayOfWeek.Thursday:
                print("Thursday");
                startId = 4;
                break;
            case DayOfWeek.Friday:
                print("Friday");
                startId = 5;
                break;
            case DayOfWeek.Saturday:
                print("Saturday");
                startId = 6;
                break;
        }

        print("find Image" + startId.ToString());

        int date = 1;
        int i;
        for (i=startId;i< startId + DateTime.DaysInMonth(year, month); i++,date++)
        {
            //print("Image" + i.ToString());
            GameObject.Find("Image" + i.ToString()).transform.GetChild(0).GetComponent<Text>().text = date.ToString();
            SetDrinkLevelImage("Image" + i.ToString(), PlayerPrefs.GetInt(year.ToString() + month.ToString() + date.ToString() + "DrinkScoreLevel", 0));
        }

        //delete 後面
        for (; i <= 34; i++)
        {
            GameObject.Find("Image" + i.ToString()).transform.GetChild(0).GetComponent<Text>().text = "";
            //設定圖片
            GameObject.Find("Image" + i.ToString()).GetComponent<Image>().sprite = null;
        }

        //delete 前面
        print("delete 前面");
        for (i=0; i < startId; i++)
        {
            print(i);
            GameObject.Find("Image" + i.ToString()).transform.GetChild(0).GetComponent<Text>().text = "";
            //設定圖片
            GameObject.Find("Image" + i.ToString()).GetComponent<Image>().sprite = null;
        }

       

    }

    void AddMonth()
    {
        month = (int.Parse(month) + 1).ToString();
        if (int.Parse(month) > 12)
        {
            month = "1";
            year = (int.Parse(year) + 1).ToString();
        }

        SetCalenderTitle();
        SetCalender(int.Parse(year), int.Parse(month));
    }

    void SubMonth()
    {
        month = (int.Parse(month) - 1).ToString();
        if (int.Parse(month) < 1)
        {
            month = "12";
            year = (int.Parse(year) - 1).ToString();
        }

        SetCalenderTitle();
        SetCalender(int.Parse(year), int.Parse(month));
    }

    

    static void SetDrinkLevelImage(string id,int level)
    {
        switch (level)
        {
            case 1:
                GameObject.Find(id).GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/首頁日曆1");
                break;
            case 2:
                GameObject.Find(id).GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/首頁日曆2");
                break;
            case 3:
                GameObject.Find(id).GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/首頁日曆3");
                break;
            case 4:
                GameObject.Find(id).GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/首頁日曆4");
                break;
            default:
                GameObject.Find(id).GetComponent<Image>().sprite = null;
                break;
        }
    }
    
}
