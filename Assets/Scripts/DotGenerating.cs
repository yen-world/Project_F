using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotGenerating : MonoBehaviour
{
    [SerializeField] float maxtime = 0.5f, time = 0f;
    GameManager theGM;
    GraphManager theGP;
    LineManager newline = new LineManager();
    // Start is called before the first frame update
    void Start()
    {
        theGM = FindObjectOfType<GameManager>();
        theGP = FindObjectOfType<GraphManager>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > maxtime){
            var newDot = Instantiate(theGP.dot, theGP.dotGroup);
            newline = Instantiate(theGP.line,theGP.lineGroup).GetComponent<LineManager>();

            //값에 대한 생성은 여기서 일단 임시로 하는중. 나중에 수정 필요
            newDot.GetComponent<DotManager>().dot.price = Random.Range(0,10000);

            newDot.SetActive(false);
            if(theGP.dotList.Count != 20){
                theGP.dotList.Add(newDot.GetComponent<DotManager>().dot);
            }else{
                theGP.dotList.RemoveAt(0);
                theGP.dotList.Add(newDot.GetComponent<DotManager>().dot);
            }

            if(theGP.lineList.Count != 20){
                theGP.lineList.Add(newline.line);
            }else{
                theGP.lineList.RemoveAt(0);
                theGP.lineList.Add(newline.line);
            }
            newDot.SetActive(true);

            time = 0f;
        }
    }
}
