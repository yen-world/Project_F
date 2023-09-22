using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    public Line line;

    // Update is called once per frame
    void Update()
    {
        //선의 위치 여기서 계산
        float lineLength = Mathf.Sqrt(Mathf.Pow((line.nextDot.Xpos - line.perDot.Xpos),2) + Mathf.Pow((line.nextDot.Ypos - line.perDot.Ypos),2));
        float lineslope = Mathf.Atan2((line.nextDot.Ypos - line.perDot.Ypos),(line.nextDot.Xpos - line.perDot.Xpos)) * Mathf.Rad2Deg;
        // print(perDot+" "+nextDot+" "+lineLength + " " + lineslope);
        this.GetComponent<RectTransform>().sizeDelta = new Vector2(lineLength,1f);//y값이 선의 두께

        if(line.perDot == null){
            Destroy(this.gameObject);
        }
    }
    private void OnDestroy() {
        
    }
}
