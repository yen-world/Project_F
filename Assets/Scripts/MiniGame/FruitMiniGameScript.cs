using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitMiniGameScript : MonoBehaviour
{
    [SerializeField] List<GameObject> spawnList = new List<GameObject>();
    [SerializeField] GameObject wormPrefabs, furitPrefabs, prefabsGroup;
    [SerializeField] Text timeText, scoreText;
    [SerializeField] float time, maxTime;
    [SerializeField] public int remainTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >maxTime){
            if(Random.Range(0,2) == 0){
                Instantiate(furitPrefabs,
                spawnList[Random.Range(0,spawnList.Count)].transform.position,
                Quaternion.identity, prefabsGroup.transform);
            } else{
                Instantiate(wormPrefabs,
                spawnList[Random.Range(0,spawnList.Count)].transform.position,
                Quaternion.identity, prefabsGroup.transform);
            } 

            remainTime -= 1;
            time = 0f;
        }

        timeText.text = remainTime.ToString();
    }
}
