using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    public List<Dot> dot = new List<Dot>();
    public List<GameObject> dotObj = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Show()
    {

    }

    public int MaxPrice()
    {
        int maxPrice = 0;
        for (int i = 0; i < dot.Count; i++)
        {
            if (dot[i].price > maxPrice)
                maxPrice = dot[i].price;
        }
        return maxPrice;
    }
    public int MinPirce()
    {
        int minPrice = 9999999;
        for (int i = 0; i < dot.Count; i++)
        {
            if (dot[i].price < minPrice)
                minPrice = dot[i].price;
        }
        return minPrice;
    }
    public void DotAddList(Dot d)
    {
        if (dot.Count > 20)
        {

        }
    }
}
