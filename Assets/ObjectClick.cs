using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectClick : MonoBehaviour
{
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = cam.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
            if (hit)
            {
                if (hit.transform.CompareTag("fruits"))
                {
                    Debug.Log("과일가게");
                    GameObject.Find("ShopUI").transform.Find("FruitsUI").gameObject.SetActive(true);
                }

                else if (hit.transform.CompareTag("electronics"))
                    Debug.Log("전자제품가게");
                else if (hit.transform.CompareTag("luxury"))
                    Debug.Log("명품가게");
                else if (hit.transform.CompareTag("jewelry"))
                    Debug.Log("보석가게");
                else if (hit.transform.CompareTag("cars"))
                    Debug.Log("자동차가게");
            }
        }
    }
}
