using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectClick : MonoBehaviour, IPointerClickHandler
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

            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Shop Layer"))
            {
                UIManager.instance.OpenShop(hit);
            }
            else if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Sales Item Layer"))
            {
                Debug.Log("GGG");
                UIManager.instance.OpenItemInfo(hit);
            }
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("GG");
    }
}
