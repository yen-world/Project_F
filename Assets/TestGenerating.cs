using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//시간초 별로 점을 생성하는 테스트
//나중에 여기있는거 복사해서 쓰면 될듯
//일단 설명 필요한 부분에는 주석을 달아 둘 계획


public class TestGenerating : MonoBehaviour
{
    [SerializeField] float spawnTime;
    float time;
    GameManager theGM;
    GraphManager theGraph;
    private void Start() {
        theGM = FindObjectOfType<GameManager>();
        theGraph = FindObjectOfType<GraphManager>();
    }

    private void Update() {
        time += Time.deltaTime;
        if(time > spawnTime){//시간마다 dot을 gamemanager의 dot리스트에 추가한다.
            theGM.DotAddList(new Dot(0,Random.Range(0,10000)));
            time = 0f;
        }
    }
}
