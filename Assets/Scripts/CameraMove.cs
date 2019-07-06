using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {


	// Update is called once per frame
	void Update () {
        StartGame();
	}

    void StartGame()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(0, 0, -10), 0.7f * Time.deltaTime);
        if (this.transform.position.y <= 0.1f)
        {
            this.transform.position = new Vector3(0,0,-10);
            this.enabled = false;
        }
            
    }
}
