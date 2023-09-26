using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GraphManager : MonoBehaviour
{
    GameManager theGM;


    //dot
    [SerializeField] public GameObject dot;
    [SerializeField] public Transform dotGroup;

    [SerializeField] public float []dotXPos = new float[20];
    [SerializeField] public List<Dot> dotList = new List<Dot>();

    //area
    [SerializeField] public RectTransform graphArea;
    [SerializeField] public float dotStep;
    public float areaHalfH;

    //text
    [SerializeField] Text HighPriceText, avgPriceText, lowPriceText;

    //Line
    [SerializeField] public GameObject line;
    [SerializeField] public Transform lineGroup;
    [SerializeField] public List<Line> lineList = new List<Line>();

    //etc
    [SerializeField] public int highPrice, lowprice, avgprice, areaRange;


    // Start is called before the first frame update
    void Start()
    {
        theGM = FindObjectOfType<GameManager>();
        areaHalfH = (graphArea.rect.height / 2) - 20; //-를 붙이면 최소값이 됨.
        dotStep = graphArea.rect.width / dotXPos.Length;
        for(int i = 0;i<dotXPos.Length;i++){
            dotXPos[i] = ((graphArea.rect.width / -2) + (dotStep / 2)) + (dotStep * i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        try{
            highPrice = (from value in dotList
                        select value).Max(item => item.price);
            avgprice = (int)(from value in dotList
                        select value).Average(item => item.price);
            lowprice = (from value in dotList
                        select value).Min(item => item.price);
            HighPriceText.text = highPrice.ToString();
            avgPriceText.text = avgprice.ToString();
            lowPriceText.text = lowprice.ToString();

            areaRange = highPrice - lowprice;

        }catch(InvalidOperationException){ //리스트가 비어있을경우 오류 메시지 출력하여서 잡아줬음. 딱히 뭘 더 해야하는건 아님.
            
        }
    }

}
