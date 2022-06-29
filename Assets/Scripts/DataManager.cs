using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DataManager
{

    public static int[] GetInt(string key)
    {
        // serialization
        // 1|2|12
        var rawData = PlayerPrefs.GetString(key, "");
        //Debug.Log(rawData);
        var stringPositions = rawData.Split('|');
        var array = new List<int>();
        for (int i = 0; i < stringPositions.Length; i++)
        {
            var stringValue = stringPositions[i];
            if (!string.IsNullOrEmpty(stringValue))
            {
                array.Add(int.Parse(stringValue));
            }
        }
        return array.ToArray();
    }
    public static float[] GetFloat(string key)
    {
        // serialization
        // 1|2|12
        var rawData = PlayerPrefs.GetString(key, "");
        //Debug.Log(rawData);
        var stringPositions = rawData.Split('|');
        var array = new List<float>();
        for (int i = 0; i < stringPositions.Length; i++)
        {
            var stringValue = stringPositions[i];
            if (!string.IsNullOrEmpty(stringValue))
            {
                array.Add(float.Parse(stringValue));
            }
        }
        return array.ToArray();
    }
    public static void SetInt(string key, int[] values)
    {
        var data = "";
        foreach (var item in values)
        {
            data += item + "|";
        }
        data = data.Trim('|');
        
        PlayerPrefs.SetString(key, data);
    }
    public static void SetFloat(string key, float[] values)
    {
        var data = "";
        foreach (var item in values)
        {
            data += item + "|";
        }
        data = data.Trim('|');
        
        PlayerPrefs.SetString(key, data);
    }

    public static void Clear()
    {
        PlayerPrefs.DeleteKey("level");
        PlayerPrefs.DeleteKey("bgColor");
        PlayerPrefs.DeleteKey("Ground");

    }
    public static Color GetColor(string key)
    {
        var rawColor = DataManager.GetFloat(key);
        if (rawColor.Length > 0)
        {
            return new Color(rawColor[0], rawColor[1], rawColor[2]);
        }
        var newColor = new Color(Random.Range(0.1f, 1), Random.Range(0.1f, 1), Random.Range(0.1f, 1));
        DataManager.SetFloat(key, new float[]
        {
            newColor.r,
            newColor.g,
            newColor.b
        });
        return newColor;
    }
}
