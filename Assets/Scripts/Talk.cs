using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System.IO;
using UnityEngine.EventSystems;

public class Talk : MonoBehaviour,IPointerClickHandler {

    [SerializeField]
    private string characterName;
    [SerializeField]
    private GameObject bubble;
    [SerializeField]
    private Text text;
    private int dialogCount;//对话总数
    private int index;//当前对话目录
    private List<string> dialogs=new List<string>();
    private List<string> titles=new List<string>();
    private List<int> paraLength;
    [SerializeField]
    private GameObject playerText;
    [SerializeField]
    private GameObject playerBubble;
    XmlDocument xml = new XmlDocument();
    private bool canbClicked;

    // Use this for initialization
    void Start () {
        string data = Resources.Load("Dialogues/dialogues").ToString();
        xml.LoadXml(data);
        LoadDialog(characterName);
        canbClicked = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LoadDialog(string name)
    {
        XmlNode self = xml.SelectSingleNode("//"+name);
        XmlNodeList list1 = self.SelectNodes("//对话");
        foreach(XmlNode node in list1)
        {
            dialogs.Add(node.InnerText);
            //Debug.Log(dialogs[dialogs.Count-1]);
        }
        XmlNodeList list2 = self.SelectNodes("//标题");
        foreach(XmlNode node in list2)
        {
            titles.Add(node.InnerText);
            //Debug.Log(titles[titles.Count - 1]);
        }
        dialogCount = dialogs.Count;
        index = 0;
    }

    void UpdateDialog()
    {
        if (index < dialogCount)
        {
            string character = dialogs[index].Split('：')[0];
            string sentence = dialogs[index].Split('：')[1];
            Debug.Log(dialogs[index] + "  " + index);
            switch (character)
            {
                case "Q":
                    playerBubble.SetActive(true);
                    bubble.SetActive(false);
                    playerText.GetComponent<Text>().text = sentence;
                    break;
                case "A":
                    playerBubble.SetActive(false);
                    bubble.SetActive(true);
                    text.text = sentence;
                    break;

            }
            index += 1;
        }
        else
        {
            playerBubble.SetActive(false);
            bubble.SetActive(false);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log("clicked");

        UpdateDialog();
    }
}
