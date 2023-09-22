using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotManager : MonoBehaviour
{
    public Dot dot;
    GraphManager theGraph;
    GameManager theGM;
    private void Start() {
        theGraph = FindObjectOfType<GraphManager>();
        theGM = FindObjectOfType<GameManager>();
        //오브젝트가 생성됐을 때, x와 y 값을 정해준다.
        //xpos
        // if(theGM.dot.Count < 20){
        //     dot.Xpos = theGM.graphXPos[theGM.dot.Count];
        // }
        // else{//갯수가 20개라면 추가만 해야됨.
        //     dot.Xpos = theGM.graphXPos[]
        // }
        dot.Xpos = theGM.graphXPos[theGM.dot.Count];
        //ypos
        float dotPercent = (float)(dot.price - theGraph.minPrice)/ (theGraph.maxPrice - theGraph.minPrice);
        if(dotPercent > 0.5){//중간보다 위
            dotPercent = (dotPercent - 0.5f) * 2;
            dot.Ypos = theGraph.areaMaxH * dotPercent;
        }
        else if(dotPercent == 0.5){//중간
            dot.Ypos = 0f;
        }
        else{//아래
            dotPercent = dotPercent * 2;
            dot.Ypos = theGraph.areaMinH * dotPercent;
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.localPosition = new Vector3(dot.Xpos, dot.Ypos, 0);

        if(dot.Xpos < -400f){
            Destroy(this.gameObject);
        }
        if(theGraph.moveFlag){
            dot.Xpos -= 20f;
            theGraph.moveFlag = false;
        }
    }
}
