using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotGenerating : MonoBehaviour
{
    [SerializeField] float maxtime = 1f, time = 0f;
    GameManager theGM;
    GraphManager theGP;
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
            newDot.SetActive(false);
            if(theGP.dotList.Count != 20){
                theGP.dotList.Add(newDot.GetComponent<DotManager>().dot);
            }else{
                theGP.dotList.RemoveAt(0);
                theGP.dotList.Add(newDot.GetComponent<DotManager>().dot);
            }
            newDot.SetActive(true);
            time = 0f;
        }
    }
}
