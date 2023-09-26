using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    
    GraphManager theGP;
    private void Start() {
        theGP = FindObjectOfType<GraphManager>();
        
    }
}
