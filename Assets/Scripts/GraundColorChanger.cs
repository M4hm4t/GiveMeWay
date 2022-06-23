using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraundColorChanger : MonoBehaviour
{

    private Color randomColor;

    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = DataManager.GetColor("Ground");
    }
}
