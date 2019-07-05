using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Block : MonoBehaviour,IDragHandler,IEndDragHandler,IBeginDragHandler{

    [SerializeField]
    private BlockManager bm;
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private GameObject anchor;
    private Vector3 mousePos;
    private Vector3 initialSelfPos;
    private RectTransform rt;
    private bool inBubble;
    /*[SerializeField]
    private float offset;*/
    [SerializeField]
    private float fitrange;
    private GameObject[] bubbles;
    private Vector3 posB4Drag;
    private Vector3 prePos;
    private Vector3 cameraOffset;
    private Vector3 cameraInitPos;

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
            this.transform.position = posB4Drag;
        //Debug.Log("drag ended"+"  "+rt.position);
    }


    // Use this for initialization
    void Start () {
        rt = this.GetComponent<RectTransform>();
        cameraInitPos = Camera.main.transform.position;
        initialSelfPos = rt.position;
        bubbles = GameObject.FindGameObjectsWithTag("Bubble");
        prePos = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        StayInBubble();
        cameraOffset = Camera.main.transform.position - cameraInitPos;
        prePos = this.transform.position;
	}

    bool IntoBubble()
    {
        if(!inBubble)
        {
            for(int i=0;i<bubbles.Length;i++)
            {
                
                if(Mathf.Abs((this.transform.position-bubbles[i].transform.position).magnitude) <= fitrange&&!Detect(bubbles[i]))
                {
                    Debug.Log((this.transform.position - bubbles[i].transform.position).magnitude);
                    this.transform.position = bubbles[i].transform.position;
                    transform.SetParent(canvas.transform);
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
            
            foreach(GameObject box in bm.boxes)
            {
                Debug.Log((this.transform.position - box.transform.position).magnitude);
                if ((this.transform.position- box.transform.position).magnitude<=fitrange&&!Detect(box))
                {
                    
                    this.transform.position = box.transform.position;
                    transform.SetParent(anchor.transform);
                    return true;
                }
            }
        }
        return false;
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("begin drag   " + this.transform.position);
        inBubble=false;
        posB4Drag = this.transform.position;
    }

    void StayInBubble()
    {
        if(inBubble)
        {
            this.transform.position = prePos;
        }
    }

    bool Detect(GameObject target)
    {
        foreach(GameObject block in bm.blocks)
        {
            if(block.transform!=this.transform&&(block.transform.position-target.transform.position).magnitude<fitrange)
            {
                return true;
            }
        }
        return false;
    }
}
