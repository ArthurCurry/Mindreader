using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Block : MonoBehaviour,IDragHandler,IEndDragHandler{

    private Vector3 mousePos;
    private Vector3 initialSelfPos;
    private RectTransform rt;

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector3 pos;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(rt, eventData.position, eventData.enterEventCamera, out pos);
        rt.position = pos;
        
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        rt.position = initialSelfPos;
        Debug.Log("drag ended");
    }


    // Use this for initialization
    void Start () {
        rt = this.GetComponent<RectTransform>();
        initialSelfPos = rt.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
