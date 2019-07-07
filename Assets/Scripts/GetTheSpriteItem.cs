using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GetTheSpriteItem : MonoBehaviour

{
    public GameObject obj;
    public int Id;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                Debug.DrawLine(ray.origin, hitInfo.point);
                GameObject gameObj = hitInfo.collider.gameObject;
                Debug.Log("click object name is " + gameObj.name);
                if (gameObj.tag == "wallPaper" + Id)
                {
                    obj.SetActive(true);
                }
            }

        }
    }
}
