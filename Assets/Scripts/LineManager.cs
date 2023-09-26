using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.Mathematics;

public class LineManager : MonoBehaviour
{
    [SerializeField] public Line line;
    GraphManager theGP;
    private void Start() {
        theGP = FindObjectOfType<GraphManager>();
        //일단 점을 배정해야 함. pre, next 모두
        //생성된 line의 index를 먼저 구해서 라인에 해당하는 index의 점이 pre, 그다음이 next
        int lineIdx = theGP.lineList.IndexOf(line);
        print(this.gameObject.transform.GetSiblingIndex());
        try{
            line.preDot = theGP.dotList[lineIdx-1];
            line.nextDot = theGP.dotList[lineIdx];
        }catch(ArgumentOutOfRangeException){

        }
        
    }

    private void Update() {
        try{
            if(this.gameObject.transform.GetSiblingIndex() - 20 > 0){
                    Destroy(theGP.lineGroup.GetChild(gameObject.transform.GetSiblingIndex() - 20).gameObject);
                    if(line.preDot.xPos == line.preDot.yPos){
                        Destroy(this.gameObject);
                    }
            }
            if(line.preDot.xPos == line.preDot.yPos){
                        Destroy(this.gameObject);
            }
            this.gameObject.GetComponent<RectTransform>().localPosition = new Vector3(
                (line.preDot.xPos + line.nextDot.xPos) / 2,
                (line.preDot.yPos + line.nextDot.yPos) / 2,
                0f
            );
            this.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(
                Mathf.Sqrt((line.preDot.xPos - line.nextDot.xPos)*(line.preDot.xPos - line.nextDot.xPos)
                + (line.nextDot.yPos - line.preDot.yPos)*(line.nextDot.yPos - line.preDot.yPos))
                ,2f
            );
            this.gameObject.GetComponent<RectTransform>().localRotation = Quaternion.Euler(
                0f,0f,
                Mathf.Atan2((line.nextDot.yPos - line.preDot.yPos), (line.nextDot.xPos - line.preDot.xPos))
                * Mathf.Rad2Deg
            );
        } catch(NullReferenceException){
            
        } catch(ArgumentOutOfRangeException){

        }
        

        
    }
}
