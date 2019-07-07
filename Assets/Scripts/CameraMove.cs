using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public GameObject preButton, nextButton, leftButton, rightButton,confirmButton;
    public GameObject anchor;
    public bool nextDown = false, preDown = false, needToMove = true;
    private int x = 0;
    // Update is called once per frame
    void Update()
    {
        if (needToMove)
        {
            StartGame();
        }

        if (nextDown == true)
        {
            Debug.Log("yes");
            NextPage();
        }
        if (preDown)
        {
            PrePage();
        }
    }


    void StartGame()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(0, 0, -10), 2.0f * Time.deltaTime);
        if (this.transform.position.y <= 0.1f)
        {
            this.transform.position = new Vector3(0, 0, -10);
            //this.enabled = false;
            anchor.SetActive(true);
            preButton.SetActive(true);
            nextButton.SetActive(true);
            needToMove = false;
            leftButton.SetActive(true);
            rightButton.SetActive(true);
            confirmButton.SetActive(true);

        }

    }

    void NextPage()
    {

        if (x <= 84)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(x, 0, -10), 3.0f * Time.deltaTime);
            if (Mathf.Abs(this.transform.position.x - x) <= 0.1f)
            {
                this.transform.position = new Vector3(x, 0, -10);
                nextDown = false;
            }
        }
        else
        {
            x = 0;
            this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(x, 0, -10), 3.0f * Time.deltaTime);
            if (Mathf.Abs(this.transform.position.x) <= 0.1f)
            {
                this.transform.position = new Vector3(x, 0, -10);
                nextDown = false;
            }
        }

    }

    void PrePage()
    {

        if (x >= 0)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(x, 0, -10), 3.0f * Time.deltaTime);
            if (Mathf.Abs(this.transform.position.x) <= 0.1f)
            {
                this.transform.position = new Vector3(x, 0, -10);
                preDown = false;
            }
        }
        else
        {
            x = 84;
            this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(x, 0, -10), 3.0f * Time.deltaTime);
            if (Mathf.Abs(this.transform.position.x) <= 0.1f)
            {
                this.transform.position = new Vector3(x, 0, -10);
                preDown = false;
            }
        }
    }

    public void NextDown()
    {
        x += 21;
        nextDown = true;
        Debug.Log(nextDown);
    }

    public void PreDown()
    {
        x -= 21;
        preDown = true;
    }
}
