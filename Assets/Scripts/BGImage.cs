using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGImage : MonoBehaviour
{

    private Color randomColor;

    void Start()
    {
        GetComponent<SpriteRenderer>().color = DataManager.GetColor("bgColor");
    }
    
}
