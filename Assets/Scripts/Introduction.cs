using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Introduction : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{

    public int itemId;
    public GameObject introductionPanel;
    public Text iPText;

    public void OnPointerEnter(PointerEventData eventData)
    {
        introductionPanel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        introductionPanel.SetActive(false);
    }

    // Use this for initialization
    void Start () {
       // iPText = introductionPanel.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        switch (itemId)
        {
            case 1:  break;
            case 2: break;
            case 3: break;
            case 4: break;
            case 5: break;
            case 6: break;
            case 7: break;
            case 8: break;
            case 9: break;
            case 10: break;
            case 11: break;
            case 12: break;
            case 13: break;
            case 14: break;
            case 15: break;
        }
	}
}
