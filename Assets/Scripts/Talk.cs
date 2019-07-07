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
    [SerializeField]
    private int id;

    private GameObject restart;
    private List<int> paraLengths=new List<int>();
    private int paralength;
    private int paraIndex;
    [SerializeField]
    private List<GameObject> tags;
    [SerializeField]
    private GameObject readButton;
    private List<XmlNodeList> intersections=new List<XmlNodeList>();
    private int repeatIndex;//复读段落的目录
    private int repeatCount;//复读对话总数
    private Button repeatButton;
    private string repeatParaName;
    private List<string> repeatDialog = new List<string>();

    private Dictionary<string, GameObject> restartPairs = new Dictionary<string, GameObject>();

    public bool canRepeated;

    public int RepeatIndex
    {
        set
        {
            repeatIndex = value;
        }
    }

    public string ParaName
    {
        set
        {
            repeatParaName = value;
        }
    }

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
        ShowButton();
	}

    void LoadDialog(string name)
    {
        XmlNode self = xml.SelectSingleNode("//"+name);
        XmlNodeList list1 = self.SelectNodes("//对话"+id);
        foreach(XmlNode node in list1)
        {
            dialogs.Add(node.InnerText);
            //Debug.Log(dialogs[dialogs.Count-1]);
        }
        XmlNodeList list2 = self.SelectNodes("//标题"+id);
        foreach(XmlNode node in list2)
        {
            titles.Add(node.InnerText);
            //restartPairs.Add(node.InnerText, null);
            //Debug.Log(titles[titles.Count - 1]);
        }
        dialogCount = dialogs.Count;
        index = 0;
        
        ReadIntersections();
        readButton.GetComponent<RankMove>().names = titles;
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

        //UpdateDialog();
        
            Repeat(repeatParaName);
        
        //AddTags();
    }

    void ReadIntersections()
    {
        XmlNodeList nodeList = xml.SelectNodes("//段落" + id);
        //Debug.Log(nodeList.Count);
        foreach(XmlNode node in nodeList)
        {
            XmlNodeList dialogs=node.ChildNodes;
            paraLengths.Add(dialogs.Count-1);
            intersections.Add(dialogs);
            //Debug.Log(intersections[intersections.Count-1][0].InnerText);
        }
    }

    public void Repeat(string paraName)
    {
        //Debug.Log(paraName);
        
        if (repeatIndex < repeatCount&&canRepeated)
        {
            
            string character = repeatDialog[repeatIndex].Split('：')[0];
            string sentence = repeatDialog[repeatIndex].Split('：')[1];
            Debug.Log(character + "  " + sentence);
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
            repeatIndex += 1;
        }
        else
        {
            //canRepeated = false;
            playerBubble.SetActive(false);
            //repeatIndex = 0;
            bubble.SetActive(false);
        }
    }

    /*void AddTags()
    {
        int count = index-1;
        for(int i =0;i<paraLength.Count;i++)
        {
            if(count==paraLength[i])
            {
                
            }
        }
    }*/

    void ShowButton()
    {
        if ((Camera.main.transform.position - this.transform.position).magnitude < 14f)
        {
            if (repeatButton == null)
                repeatButton = readButton.transform.parent.gameObject.GetComponent<Button>();
            //Debug.Log("button show");
            readButton.SetActive(true);
            readButton.transform.parent.gameObject.SetActive(true);
        }
        else
        {
            bubble.SetActive(false);
            readButton.transform.parent.gameObject.SetActive(false);
        }
        
    }

    public void InitialRepeater()
    {
        repeatIndex = 0;
        canRepeated = true;
        repeatParaName = readButton.GetComponent<Text>().text;
        Debug.Log("initialized");
        int i;
        if (repeatParaName != null)
        {
            i = titles.IndexOf(repeatParaName);
            //Debug.Log(i);
        }
        else
            i = 0;
        //

        repeatDialog.Clear();
        for (int j = 1; j < intersections[i].Count; j++)
        {
            repeatDialog.Add(intersections[i][j].InnerText);
            Debug.Log(intersections[i][j].InnerText);
        }
        repeatCount = repeatDialog.Count;
    }
}
