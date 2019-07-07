using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour {

    public  List<Vector3> blocksPos;
    public GameObject[] blocks;
    public GameObject[] boxes;
    private GameObject[] bubbles;

    [SerializeField]
    private GameObject confirmPannel;
    public  Dictionary<int, int> blockBubblePairs=new Dictionary<int, int>();

    public int condition;
    private int currentCondition;
    // Use this for initialization
    void Start () {
        blocks = GameObject.FindGameObjectsWithTag("Block");
        bubbles = GameObject.FindGameObjectsWithTag("Bubble");
        foreach (GameObject block in blocks)
        {
            //Debug.Log(block.transform.position);
            blocksPos.Add(block.transform.position);
        }

        boxes = GameObject.FindGameObjectsWithTag("Box");

        
	}

    public void Judge()
    {
        Debug.Log(currentCondition);
        foreach (GameObject block in blocks)
        {
            if (block.GetComponent<Block>().matchFound)
                currentCondition += 1;
        }
        
        if(currentCondition>=condition)
        {
            confirmPannel.SetActive(true); ;
        }
    }

}
