using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Show(RaycastHit2D hit)
    {
        if (hit.transform.CompareTag("fruits"))
        {
            Debug.Log("과일가게");
            GameObject.Find("ShopUI").transform.Find("FruitsUI").gameObject.SetActive(true);
        }
        else if (hit.transform.CompareTag("electronics"))
        {
            Debug.Log("전자제품가게");
            GameObject.Find("ShopUI").transform.Find("ElectronicsUI").gameObject.SetActive(true);
        }
        else if (hit.transform.CompareTag("luxury"))
        {
            Debug.Log("명품가게");
            GameObject.Find("ShopUI").transform.Find("LuxuryUI").gameObject.SetActive(true);
        }
        else if (hit.transform.CompareTag("jewelry"))
        {
            Debug.Log("보석가게");
            GameObject.Find("ShopUI").transform.Find("JewelryUI").gameObject.SetActive(true);
        }
        else if (hit.transform.CompareTag("cars"))
        {
            Debug.Log("자동차가게");
            GameObject.Find("ShopUI").transform.Find("CarsUI").gameObject.SetActive(true);
        }
    }
}
