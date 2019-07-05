using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Block : MonoBehaviour,IDragHandler,IEndDragHandler,IBeginDragHandler{

    [SerializeField]
    private BlockManager bm;
    private Vector3 mousePos;
    private Vector3 initialSelfPos;
    private RectTransform rt;
    private bool inBubble;
    /*[SerializeField]
    private float offset;*/
    [SerializeField]
    private float fitrange;
    private GameObject[] bubbles;
    private Vector3 prePos;

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector3 pos;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(rt, eventData.position, eventData.enterEventCamera, out pos);
        rt.position = pos;
        
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        if (IntoBubble())
            inBubble = true;
        else if (IntoBlock())
            inBubble = false;
        else
            this.transform.position = prePos;
        //Debug.Log("drag ended"+"  "+rt.position);
    }


    // Use this for initialization
    void Start () {
        rt = this.GetComponent<RectTransform>();
        initialSelfPos = rt.position;
        bubbles = GameObject.FindGameObjectsWithTag("Bubble");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    bool IntoBubble()
    {
        if(!inBubble)
        {
            for(int i=0;i<bubbles.Length;i++)
            {
                
                if(Mathf.Abs((this.transform.position-bubbles[i].transform.position).magnitude) <= fitrange)
                {
                    Debug.Log((this.transform.position - bubbles[i].transform.position).magnitude);
                    this.transform.position = bubbles[i].transform.position;
                    Debug.Log("fit in");
                    return true;
                }
            }
        }
        return false;
    }

    bool IntoBlock()
    {
        if(!inBubble)
        {
            
            foreach(Vector3 block in bm.blocksPos)
            {
                if(Mathf.Abs((this.transform.position - block).magnitude)<=fitrange)
                {
                    Debug.Log((this.transform.position - block).magnitude);
                    this.transform.position = block;
                    return true;
                }
            }
        }
        return false;
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("begin drag   " + this.transform.position);
        inBubble=false;
        prePos = this.transform.position;
    }
}
