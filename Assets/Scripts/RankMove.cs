using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RankMove : MonoBehaviour,IPointerEnterHandler{

    private GameObject character;
    public List<string> names = new List<string>();
    private int namesIndex;
    private Text text;
    private Rect ButtonRect;

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        
    }

    // Use this for initialization
    void Start () {
        text = this.GetComponent<Text>();
        namesIndex = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log(names.Count);
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                namesIndex += 1;

            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                namesIndex -= 1;
            }
            if (namesIndex < 0)
                namesIndex = names.Count - 1;
            if (namesIndex >= names.Count)
                namesIndex = 0;
            if (this.gameObject.activeInHierarchy)
                text.text = names[namesIndex];
        }
        
    }
}
