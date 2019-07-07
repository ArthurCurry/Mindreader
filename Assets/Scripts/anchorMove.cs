using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anchorMove : MonoBehaviour {

    //public GameObject leftButton, rightButton;
    //private RectTransform anchorPosition;
    private RectTransform _rectTransform;
    // Use this for initialization
    void Start () {
        //_rectTransform = this.GetComponent<RectTransform>() ;
        //float x = Mathf.Clamp(_rectTransform.rect.position.x, -622, 0);
        //float y = Mathf.Clamp(_rectTransform.rect.position.y, 0, 0);
        //_rectTransform.transform.position = new Vector3(x, y, 0);

    }
	
	// Update is called once per frame_
	void Update () {

    }

    public void LeftMove()
    {
        this.transform.position -= new Vector3(4 * Time.deltaTime, 0, 0); //Vector3.MoveTowards(this.transform.position, new Vector3(0, 0, 0), 2.0f*Time.deltaTime );
    }

    public void RightMove()
    {
        this.transform.position += new Vector3(4 * Time.deltaTime, 0, 0); //= Vector3.MoveTowards(this.transform.position, new Vector3(-662, 0, 0), 2.0f*Time.deltaTime );
    }
}
