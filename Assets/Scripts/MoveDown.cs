using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveDown : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool canMove = false, left = false, right = false;
    public anchorMove anchormove;
    void Update()
    {
        if (canMove == true)
        {
            if (Input.GetMouseButton(0) && left == true)
                anchormove.LeftMove();
            else if (Input.GetMouseButton(0) && right == true)
                anchormove.RightMove();
        }

    }

    public void leftDown()
    {
        left = true;
        right = false;
    }

    public void rightDown()
    {
        left = false;
        right = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        canMove = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        canMove = false;
    }
}
