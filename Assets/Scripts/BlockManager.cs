using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour {

    public  List<Vector3> blocksPos;
    public GameObject[] blocks;
    public GameObject[] boxes;
    // Use this for initialization
    void Start () {
        blocks = GameObject.FindGameObjectsWithTag("Block");
        foreach (GameObject block in blocks)
        {
            Debug.Log(block.transform.position);
            blocksPos.Add(block.transform.position);
        }
        boxes = GameObject.FindGameObjectsWithTag("Box");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
