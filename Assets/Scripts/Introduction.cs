using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Introduction : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{

    public int itemId;
    public GameObject introductionPanel;
    public GameObject iPText;
    private Text text;
    

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
        text = iPText.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 mouseposition =  Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        if ((mouseposition-transform.position).magnitude <0.5f)
        switch (itemId)
        {
            case 1: text.text = "录取通知书"; break;
            case 2: text.text = "钞票"; break;
            case 3: text.text = "笔记本电脑"; break;
            case 4: text.text = "一瓶酒"; break;
            case 5: text.text = "一份礼物"; break;
            case 6: text.text = "一叠机票"; break;
            case 7: text.text = "解压电台"; break;
            case 8: text.text = "演唱会门票"; break;
            case 9: text.text = "一栋房子"; break;
            case 10: text.text = "笔和小说"; break;
            case 11: text.text = "高达10w的关注度"; break;
            case 12: text.text = "友情"; break;
            case 13: text.text = "爱情"; break;
            case 14: text.text = "纹身"; break;
            case 15: text.text = "他人的认可"; break;
        }
	}
}
