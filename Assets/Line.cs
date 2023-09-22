using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Line
{
    [SerializeField] public Dot perDot;
    [SerializeField] public Dot nextDot;
}
