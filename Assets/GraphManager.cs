using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class GraphManager : MonoBehaviour
{
    [SerializeField] RectTransform graphArea;
    [SerializeField] GameObject dot;
    [SerializeField] Transform dotGroup;
    [SerializeField] GameObject line;
    [SerializeField] Transform lineGroup;
    
    
    int maxRate;
    [SerializeField] public float areaMaxH,areaMinH,areaMinW,aeraStep;
    [SerializeField] public int maxPrice, minPrice;
    
    public bool dotSpawnFlag = false;
    public bool moveFlag = false;
    GameManager theGM;
    // Start is called before the first frame update
    void Start()
    {
        theGM = FindObjectOfType<GameManager>();
        areaMaxH = (graphArea.rect.height / 2) - 20;
        areaMinH = (graphArea.rect.height / -2) + 20;
        aeraStep = graphArea.rect.width/20;
        areaMinW = -(graphArea.rect.width / 2) + (aeraStep / 2);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        maxPrice = theGM.MaxPrice();
        minPrice = theGM.MinPirce();
        if(dotSpawnFlag){
            Instantiate(dot,dotGroup);
            dotSpawnFlag = false;
        }
    }
}
