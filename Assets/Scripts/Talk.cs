using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using UnityEngine.EventSystems;

public class Talk : MonoBehaviour,IPointerClickHandler {

    [SerializeField]
    private string characterName;
    [SerializeField]
    private GameObject bubble;
    [SerializeField]
    private TextMesh text;
    private int dialogCount;
    private int index;
    private List<string> dialogs=new List<string>();
    private List<string> titles=new List<string>();
    private List<int> paraLength;
    [SerializeField]
    private GameObject playerText;
    XmlDocument xml = new XmlDocument();

    // Use this for initialization
    void Start () {
        string data = Resources.Load("Dialogues/dialogues").ToString();
        xml.LoadXml(data);
        LoadDialog(characterName);
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
            Debug.Log(titles[titles.Count - 1]);
        }
    }

    void UpdateDialog()
    {

    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        UpdateDialog();
    }
}
