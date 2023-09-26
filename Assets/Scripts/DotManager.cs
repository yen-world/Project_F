using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Mono.Cecil.Cil;
using UnityEngine;

public class DotManager : MonoBehaviour
{
    [SerializeField] public Dot dot;
    GraphManager theGP;
    // Start is called before the first frame update
    void Start()
    {
        theGP = FindObjectOfType<GraphManager>();
    }

    // Update is called once per frame
    void Update()
    {
        try{
            //xPos 작업...            
            dot.xPos = theGP.dotXPos[theGP.dotList.FindIndex(x => x == dot)];
            
            //yPos 작업...
            dot.yPos = (float)(dot.price - theGP.lowprice) / (theGP.areaRange);
            if(dot.yPos > 0.5f){
                dot.yPos = (dot.yPos - 0.5f) * 2;
                dot.yPos *= theGP.areaHalfH;
            }else if(dot.yPos == 0.5f){
                dot.yPos = 0f;
            }else{
                dot.yPos = (0.5f - dot.yPos) * 2;
                dot.yPos *= -theGP.areaHalfH;
            }
            
            this.transform.localPosition = new Vector3(dot.xPos, dot.yPos,this.transform.position.z);
        } catch(IndexOutOfRangeException){
            Destroy(this.gameObject);
        } catch(DivideByZeroException){
            
        } 
    }
}
