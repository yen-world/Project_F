using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.UI;

public class GraphMaker : MonoBehaviour
{
    public Dictionary<int, int[]> AllTeamTotalGold = new Dictionary<int, int[]>{};

    public int SAMPLE_RATE = 10;

    public GameObject Dot;
    public Transform DotGroup;
    public Color BlueTeamColor;
    public Color PurpleTeamColor;

    public RectTransform GraphArea;

    private float graph_Width;
    private float graph_Height;

    public Transform LineGroup;
    public GameObject Line;
    public GameObject MaskPanel;

    // Start is called before the first frame update
    void Start()
    {
        var rand = new System.Random();
        int BlueTeamGold = 0, PurpleTeamGold = 0;
        for(int time = 0; time < 100; time ++){
            BlueTeamGold = BlueTeamGold + rand.Next(0,1000);
            PurpleTeamGold = PurpleTeamGold + rand.Next(0,1000);
            AllTeamTotalGold.Add(time, new[] {BlueTeamGold, PurpleTeamGold});
        }

        graph_Width = GraphArea.rect.width;
        graph_Height = GraphArea.rect.height;

        DrawGoldGraph();
    }

    private void DrawGoldGraph(){
        float startPosition = -graph_Width / 2;
        float maxYPosition = graph_Height / 2;
        var comparisonValue = new Dictionary<int,int>();
        Vector2 prevDotPos = Vector2.zero;
        foreach (var pair in AllTeamTotalGold)
            comparisonValue.Add(pair.Key, pair.Value[0] - pair.Value[1]);

        int MaxValue = comparisonValue.Max(x=> Mathf.Abs(x.Value));

        for (int i=0;i<SAMPLE_RATE;i++){
            GameObject dot = Instantiate(Dot, DotGroup, true);
            dot.transform.localScale = Vector3.one;

            RectTransform dotRT = dot.GetComponent<RectTransform>();
            Image dotImage  = dot.GetComponent<Image>();

            int tick = SAMPLE_RATE - 1 == i ? AllTeamTotalGold.Count - 1 : AllTeamTotalGold.Count / (SAMPLE_RATE - 1) * i;

            float yPosOffset = comparisonValue[tick] / MaxValue;
            
            dotImage.color = yPosOffset >= 0f ? BlueTeamColor : PurpleTeamColor;
            // 위 결과에 따라 격차가 0이여도 점은 BlueTeam색상을 하게 된다.
            // 이것도 엄격하게 0일때는 중립색으로 하겠다면 바꾸면 된다.
        
            dotRT.anchoredPosition = new Vector2(startPosition + (graph_Width / (SAMPLE_RATE - 1) * i), maxYPosition * yPosOffset);
            // 가로는 startPosition부터 각 격차마다 늘어나며 일정간격으로 찍히게 하였고
            // 세로는 격차/격차최대값에 따라 점이 찍힐 최대 높이에서 비율에 맞게 찍히게 하였다.
            if (i == 0)
            {
                prevDotPos = dotRT.anchoredPosition;
                continue;
            }
             GameObject line = Instantiate(Line, LineGroup, true);
            line.transform.localScale = Vector3.one;

            RectTransform lineRT = line.GetComponent<RectTransform>();
            Image lineImage = line.GetComponent<Image>();

            float lineWidth = Vector2.Distance(prevDotPos, dotRT.anchoredPosition);
            float xPos = (prevDotPos.x + dotRT.anchoredPosition.x) / 2;
            float yPos = (prevDotPos.y + dotRT.anchoredPosition.y) / 2;
            // 그림으로 설명..

            Vector2 dir = (dotRT.anchoredPosition - prevDotPos).normalized;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            lineRT.anchoredPosition = new Vector2(xPos, yPos);
            lineRT.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, lineWidth);
            lineRT.localRotation = Quaternion.Euler(0f, 0f, angle);
            // 두 점 사이의 각도를 tan를 이용하여 구한다.
            // atan를 이용해 라디안 값을 구하고 Rad2Deg를 이용해 라디안을 각도로 변환해준다.

            GameObject maskPanel = Instantiate(MaskPanel, Vector3.zero, Quaternion.identity);
            maskPanel.transform.SetParent(LineGroup);
            maskPanel.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            maskPanel.transform.SetParent(line.transform);
            // 마스크 패널 생성

            prevDotPos = dotRT.anchoredPosition;
        }
    }

}
