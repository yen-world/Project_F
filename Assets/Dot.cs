using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
[System.Serializable]
public class Dot
{
    [SerializeField] public float Ypos;
    [SerializeField] public float Xpos; 
    [SerializeField] public int price;

    public Dot(int _price, float _x = 0f, float _y = 0f){
        Xpos = _x;
        Ypos = _y;
        price = _price;
    }
}
