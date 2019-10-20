using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;
using System;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Android;

public class getCount : MonoBehaviour
{
    private string url;
    private JsonData gpsdata;
    public string gps1;
    public string[] gps2;
    public double lng;
    public double lat;
    public double nowlng;
    public double nowlat;
    public string temp;

    string GetGps = "";

    public double minimum = 10000.0000;
    public string miniadd;

    public Text text;

    private const double EARTH_RADIUS = 6378137;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        url = "http://140.134.26.3:8889/out1";
        print("d++++++++++_________");
        WWW www = new WWW(url);
        yield return www;
        gpsdata = JsonMapper.ToObject<JsonData>(www.text);
        ReapeTes();
        InvokeRepeating("ReapeTes", 1.0f,5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    ///公尺
    ///
    public void ReapeTes()
    {

        //jsonString = File.ReadAllText(Application.dataPath + "/StreamingAssets/out1.json");
        minimum = 10000.0000;
        //gpsdata = JsonMapper.ToObject(jsonString);

        StartCoroutine(StartGPS());
        //逢甲資電門口GPS  24.179015 120.649675
        nowlat = 24.179015;
        nowlng = 120.649675;

        //print(Input.location.lastData.latitude);
        double latem = Input.location.lastData.latitude;
        double lntem = Input.location.lastData.longitude;
        if (latem == 0 | lntem ==0)
        {
            nowlat = 24.179015;
            nowlng = 120.649675;
        }
        else
        {
            nowlat = latem;
            nowlng = lntem;
        }


        for (int i = 0; i < 495; i++)
        {
            try
            {
                gps1 = (string)gpsdata["ROOT"]["RECORD"][i]["GPS"];
                gps2 = gps1.Split(',');

                lng = double.Parse(gps2[0]);
                lat = double.Parse(gps2[1]);
            }
            catch (Exception e)
            {
                //Debug.Log(e);
                continue;
            }

            //print(GetDistance(nowlat, nowlng, lat, lng));
            if (GetDistance(nowlat, nowlng, lat, lng) < minimum)
            {
                //print((string)gpsdata["ROOT"]["RECORD"][i]["機關單位"]);
                minimum = GetDistance(nowlat, nowlng, lat, lng);
                miniadd = (string)gpsdata["ROOT"]["RECORD"][i]["機關單位"];
                //print(GetDistance(nowlat, nowlng, lat, lng));
                //temp += (string)gpsdata["ROOT"]["RECORD"][i]["機關單位"]+'\n';
                
            }
            //print(i);
        }
        temp = miniadd + '\n';
        temp += "距離";
        temp += System.Math.Round(minimum,4) + "公尺";
        text.text = temp;
    }
    public static double GetDistance(double lat1, double lng1, double lat2, double lng2)
    {
        double radLat1 = Rad(lat1);
        double radLng1 = Rad(lng1);
        double radLat2 = Rad(lat2);
        double radLng2 = Rad(lng2);
        double a = radLat1 - radLat2;
        double b = radLng1 - radLng2;
        double result = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) + Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2))) * EARTH_RADIUS;
        return result;
    }

    /// <summary>
    /// 經緯度轉化成弧度
    /// </summary>
    /// <param name="d"></param>
    /// <returns></returns>
    private static double Rad(double d)
    {
        return (double)d * Math.PI / 180d;
    }

    IEnumerable wwwgetgps()
    {
        WWW www = new WWW("http://140.134.26.3:8889/out1");

        yield return www;

        JsonData jsonData2 = JsonMapper.ToObject<JsonData>(www.text);

        //print(www.text);
        
    }

    IEnumerator StartGPS()
    {
        // Input.location 用于访问设备的位置属性（手持设备）, 静态的LocationService位置  
        // LocationService.isEnabledByUser 用户设置里的定位服务是否启用  
        if (!Input.location.isEnabledByUser)
        {
            Permission.RequestUserPermission(Permission.FineLocation);
            Input.location.Start();
            GetGps = "isEnabledByUser value is:" + Input.location.isEnabledByUser.ToString() + " Please turn on the GPS";
            yield return false;
        }

        // LocationService.Start() 启动位置服务的更新,最后一个位置坐标会被使用  
        Input.location.Start(10.0f, 10.0f);

        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            // 暂停协同程序的执行(1秒)  
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (maxWait < 1)
        {
            GetGps = "Init GPS service time out";
            yield return false;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            GetGps = "Unable to determine device location";
            yield return false;
        }
        else
        {
            GetGps = "N:" + Input.location.lastData.latitude + " E:" + Input.location.lastData.longitude;
            GetGps = GetGps + " Time:" + Input.location.lastData.timestamp;
            yield return new WaitForSeconds(1);
        }
    }
}
