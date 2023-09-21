using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    public List<Dot> dot = new List<Dot>();
    public List<GameObject> dotObj = new List<GameObject>();

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
    public void DotAddList(Dot d){
        if(dot.Count > 20){
            //맨 앞의 요소를 제거
            dot.RemoveAt(0);
            //맨 마지막에 요소 추가
            dot.Add(d);
        }
        else{//리스트 길이가 20을 넘어가지 않는다면 그냥 추가해도 됨.
            dot.Add(d);
        }
    }
    public void DotObjAddList(GameObject d){
        if(dotObj.Count > 20){
            //맨 앞의 요소를 제거
            dotObj.RemoveAt(0);
            //맨 마지막에 요소 추가
            dotObj.Add(d);
        }
        else{//리스트 길이가 20을 넘어가지 않는다면 그냥 추가해도 됨.
            dotObj.Add(d);
        }
    }
}
