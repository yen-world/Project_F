using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphManager : MonoBehaviour
{
    GameManager theGM;

    [SerializeField] public GameObject dot;
    [SerializeField] public Transform dotGroup;
    [SerializeField] public bool dotSpawn;

    [SerializeField] public float []dotXPos = new float[20];
    [SerializeField] public List<Dot> dotList = new List<Dot>();

    //area
    [SerializeField] public RectTransform graphArea;
    [SerializeField] public float dotStep;

    // Start is called before the first frame update
    void Start()
    {
        theGM = FindObjectOfType<GameManager>();
        dotStep = graphArea.rect.width / dotXPos.Length;
        for(int i = 0;i<dotXPos.Length;i++){
            dotXPos[i] = ((graphArea.rect.width / -2) + (dotStep / 2)) + (dotStep * i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
