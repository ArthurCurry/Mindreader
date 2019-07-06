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
    private List<int> paraLength;//各段落长度
    [SerializeField]
    private GameObject playerText;
    [SerializeField]
    private GameObject playerBubble;
    XmlDocument xml = new XmlDocument();
    private bool canbClicked;

    private GameObject restart;
    private List<int> paraLengths=new List<int>();
    private int paralength;
    private int paraIndex;
    [SerializeField]
    private List<GameObject> tags;

    private Dictionary<string, GameObject> restartPairs = new Dictionary<string, GameObject>();


    // Use this for initialization
    void Start () {
        string data = Resources.Load("Dialogues/dialogues").ToString();
        xml.LoadXml(data);
        LoadDialog(characterName);
        tags = new List<GameObject>();
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
            restartPairs.Add(node.InnerText, null);
            //Debug.Log(titles[titles.Count - 1]);
        }
        dialogCount = dialogs.Count;
        index = 0;
        
        ReadIntersections();
    }

    void UpdateDialog()
    {
        if (index < dialogCount)
        {
            string character = dialogs[index].Split('：')[0];
            string sentence = dialogs[index].Split('：')[1];
            //Debug.Log(dialogs[index] + "  " + index);
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
        AddTags();
    }

    void ReadIntersections()
    {
        XmlNodeList nodeList = xml.SelectNodes("//段落");
        //Debug.Log(nodeList.Count);
        foreach(XmlNode node in nodeList)
        {
            XmlNodeList dialogs=node.ChildNodes;
            paraLengths.Add(dialogs.Count-1);
            Debug.Log(dialogs.Count-1);
        }
    }

    void AddTags()
    {
        int count = index-1;
        for(int i =0;i<paraLength.Count;i++)
        {
            if(count==paraLength[i])
            {
                
            }
        }
    }
}
