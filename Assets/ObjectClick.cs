using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectClick : MonoBehaviour
{
    Camera cam;
    public bool IsOpenUI;

    void Awake()
    {
        cam = GetComponent<Camera>();
        IsOpenUI = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !IsOpenUI)
        {
            Vector2 pos = cam.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

            if (hit.collider != null && hit.transform.gameObject.layer == LayerMask.NameToLayer("Shop Layer"))
            {
                UIManager.instance.OpenShop(hit);
                IsOpenUI = true;
            }
        }
    }


}
