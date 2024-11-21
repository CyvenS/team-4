using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MiniGameCollection.ArcadeInput;

public class MovementScript : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    
    public int stickCurrent;
    public int stickLast;
    public int rotateCurrent;
    public float rotateSpeed;
    public float speedCurrent;

    public int stickCurrentP2;
    public int stickLastP2;
    public int rotateCurrentP2;
    public int rotateSpeedP2;
    public float speedCurrentP2;

    public float speedMax = 10; 



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
        stickLast = stickCurrent; //stores the input from the previous frame
        stickCurrent = 0;//REPLACE THIS LINE WITH HOWEVER THE JOYSTICK INPUT WORKS

        if (speedCurrent > 0)
        {
            speedCurrent -= (float)0.3; // drag
        }
        else if (speedCurrent < 0)
        {
            speedCurrent = 0;
        }

        if (speedCurrentP2 > 0)
        {
            speedCurrentP2 -= (float)0.3; // drag
        }
        else if (speedCurrentP2 < 0)
        {
            speedCurrentP2 = 0;
        }


        //handle rotating
        if (stickCurrent == stickLast +1 || stickCurrent == 8 && stickLast == 1)
        {
            if (rotateSpeed >= 0)
            {
                rotateSpeed = rotateSpeed + 5;
            }
            else
            {
                rotateSpeed = rotateSpeed + 10;
            }
        }
        if (stickCurrent == stickLast - 1 || stickCurrent == 1 && stickLast == 8)
        {
            if (rotateSpeed <= 0)
            {
                rotateSpeed = rotateSpeed - 5;
            }
            else
            {
                rotateSpeed = rotateSpeed - 10;
            }
        }

        //make rotation slowly stop if no input happening
        if (rotateSpeed > 0)
        {
            rotateSpeed--;
        }
        if (rotateSpeed < 0)
        {
            rotateSpeed++;
        }

        //TEMPORARY ROTATION CODE
        if (Input.GetKey(KeyCode.A))
        {
            Player1.transform.eulerAngles = new Vector3 (0,0, Player1.transform.eulerAngles.z + 2);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Player1.transform.eulerAngles = new Vector3(0,0, Player1.transform.eulerAngles.z - 2);
        }


        if (Input.GetKeyDown(KeyCode.W))
        {
            speedCurrent += (float)0.05;
            if (speedCurrent <= speedMax)
            {
                speedCurrent = speedMax;
            }
            Player1.GetComponent<Rigidbody2D>().velocity = Player1.transform.up * speedCurrent;

        }

        if (Input.GetKey(KeyCode.J))
        {
            Player2.transform.eulerAngles = new Vector3(0, 0, Player2.transform.eulerAngles.z + 2);
        }
        if (Input.GetKey(KeyCode.L))
        {
            Player2.transform.eulerAngles = new Vector3(0, 0, Player2.transform.eulerAngles.z - 2);
        }



        if (Input.GetKeyDown(KeyCode.I))
        {
            speedCurrentP2 += (float)0.05;
            if (speedCurrentP2 <= speedMax)
            {
                speedCurrentP2 = speedMax;
            }
            Player2.GetComponent<Rigidbody2D>().velocity = Player2.transform.up * speedCurrentP2;
        }
    }
}
