using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour {

    public  List<Vector3> blocksPos;

	// Use this for initialization
	void Start () {
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        foreach (GameObject block in blocks)
        {
            Debug.Log(block.transform.position);
            blocksPos.Add(block.transform.position);
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
