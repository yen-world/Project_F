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
    [SerializeField] float[] graphXPos = new float[20];
    
    int maxRate;
    float areaMaxH,areaMinH,areaMinW,aeraStep;
    int maxPrice, minPirce;
    
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
    {//11번째 오류.. 다시 찾아볼것
        if(updateFlag){
            maxPrice = theGM.MaxPrice();
            minPirce = theGM.MinPirce();
            for(int i = 0;i < graphXPos.Length;i++){
                //위치 계산하여 저장하는 변수
                float dotPercent = (theGM.dot[i].price - minPirce) / (maxPrice - minPirce) * 100;
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
                var newDot = Instantiate(dot, dotPos, Quaternion.identity, dotGroup);
            }
           updateFlag = false;
        }
    }
}
