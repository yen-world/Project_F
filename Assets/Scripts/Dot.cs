using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[System.Serializable]
public class Dot
{   
    [SerializeField] public int cnt;//몇번째 생성된 점인지;
    [SerializeField] public float xPos, yPos;
    [SerializeField] public int price;
}
