using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    //graph
    GraphManager theGraph;
    public List<Dot> dot = new List<Dot>();
    public List<GameObject> dotObj = new List<GameObject>();

    public List<GameObject> lineObj = new List<GameObject>();
    [SerializeField] public float[] graphXPos = new float[20];

    private void Start() {
        theGraph = FindObjectOfType<GraphManager>();
        for(int i = 0;i<graphXPos.Length;i++){
            graphXPos[i] = theGraph.areaMinW + (theGraph.aeraStep * i);
        }
    }
    private void Update() {
        if(dot.Count > 20){
            dot.RemoveAt(0);
            theGraph.moveFlag = true;
        }
    }


    public int MaxPrice(){
        int maxPrice = 0;
        for(int i = 0;i < dot.Count;i++){
            if (dot[i].price > maxPrice)
                maxPrice = dot[i].price;
        }
        return maxPrice;
    }
    public int MinPirce(){
        int minPrice = 9999999;
        for(int i = 0;i < dot.Count;i++){
            if (dot[i].price < minPrice)
                minPrice = dot[i].price;
        }
        return minPrice;
    }

}
