using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Unity.Mathematics;
using UnityEngine;

public class GraphManager : MonoBehaviour
{
    [SerializeField] RectTransform graphArea;
    [SerializeField] GameObject dot;
    [SerializeField] Transform dotGroup;
    [SerializeField] GameObject line;
    [SerializeField] Transform lineGroup;
    [SerializeField] float[] graphXPos = new float[20];
    
    int maxRate;
    [SerializeField] float areaMaxH,areaMinH,areaMinW,aeraStep;
    [SerializeField] int maxPrice, minPirce;
    
    public bool updateFlag = false;

    GameManager theGM;
    // Start is called before the first frame update
    void Start()
    {
        theGM = FindObjectOfType<GameManager>();
        areaMaxH = (graphArea.rect.height / 2) - 20;
        areaMinH = (graphArea.rect.height / -2) + 20;
        aeraStep = graphArea.rect.width/20;
        areaMinW = -(graphArea.rect.width / 2) + (aeraStep / 2);
        
        for(int i = 0;i<graphXPos.Length;i++){
            graphXPos[i] = areaMinW + (aeraStep * i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(updateFlag){
            maxPrice = theGM.MaxPrice();
            minPirce = theGM.MinPirce();
            print(maxPrice +" "+ minPirce);
            for(int i = 0;i < theGM.dot.Count;i++){//점 그리기
                //위치 계산하여 저장하는 변수
                // print(theGM.dot[i].price + " " + (theGM.dot[i].price - minPirce) + " " +(maxPrice - minPirce) +" "+((theGM.dot[i].price - minPirce) / (maxPrice - minPirce)));
                float dotPercent = (float)(theGM.dot[i].price - minPirce)/ (maxPrice - minPirce);
                // print(dotPercent);
                float dotYPos;
                if(dotPercent > 0.5){//중간보다 위
                    dotPercent = (dotPercent - 0.5f) * 2;
                    dotYPos = areaMaxH * dotPercent;
                }
                else if(dotPercent == 0.5){//중간
                    dotYPos = 0f;
                }
                else{//아래
                    dotPercent = dotPercent * 2;
                    dotYPos = areaMinH * dotPercent;
                }
                Vector3 dotPos = new Vector3(graphXPos[i],dotYPos,0);
                var newDot = Instantiate(dot, Vector3.zero, Quaternion.identity,dotGroup);
                newDot.GetComponent<RectTransform>().localPosition = dotPos;
                theGM.DotObjAddList(newDot);
            }
            if(theGM.dot.Count > 1){//점이 1개 이하일경우는 그리지 않아도 된다.
                for(int i=0; i< theGM.dot.Count - 1;i++){//선 그리기
                    Vector3 perDot = theGM.dotObj[i].transform.localPosition;
                    Vector3 nextDot = theGM.dotObj[i + 1].transform.localPosition;
                    var newLine = Instantiate(line, Vector3.zero, Quaternion.identity, lineGroup);
                    float lineLength = Mathf.Sqrt(Mathf.Pow((nextDot.x - perDot.x),2) + Mathf.Pow((nextDot.y - perDot.y),2));
                    float lineslope = Mathf.Atan2((nextDot.y - perDot.y),(nextDot.x - perDot.x)) * Mathf.Rad2Deg;
                    // print(perDot+" "+nextDot+" "+lineLength + " " + lineslope);
                    newLine.GetComponent<RectTransform>().sizeDelta = new Vector2(lineLength,1f);//y값이 선의 두께
                    newLine.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0f,0f, lineslope);
                    newLine.GetComponent<RectTransform>().localPosition = new Vector3((nextDot.x + perDot.x)/2, (nextDot.y + perDot.y)/2,0f);
                }
            }
           updateFlag = false;
        }
    }
}
