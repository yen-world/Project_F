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

    public void OpenShop(RaycastHit2D hit)
    {
        if (hit.transform.CompareTag("fruits"))
        {
            GameObject.Find("ShopUI").transform.Find("FruitsUI").gameObject.SetActive(true);
        }
        else if (hit.transform.CompareTag("electronics"))
        {
            GameObject.Find("ShopUI").transform.Find("ElectronicsUI").gameObject.SetActive(true);
        }
        else if (hit.transform.CompareTag("luxury"))
        {
            GameObject.Find("ShopUI").transform.Find("LuxuryUI").gameObject.SetActive(true);
        }
        else if (hit.transform.CompareTag("jewelry"))
        {
            GameObject.Find("ShopUI").transform.Find("JewelryUI").gameObject.SetActive(true);
        }
        else if (hit.transform.CompareTag("cars"))
        {
            GameObject.Find("ShopUI").transform.Find("CarsUI").gameObject.SetActive(true);
        }
    }

    public void OpenItemInfo(RaycastHit2D hit)
    {
        Debug.Log("G");
        if (hit.transform.CompareTag("item1"))
        {
            Debug.Log("사과");
        }
        else if (hit.transform.CompareTag("item2"))
        {
            Debug.Log("배");
        }
        else if (hit.transform.CompareTag("item3"))
        {
            Debug.Log("바나나");
        }
        else if (hit.transform.CompareTag("item4"))
        {
            Debug.Log("멜론");
        }
        else if (hit.transform.CompareTag("item5"))
        {
            Debug.Log("수박");
        }
    }
}
