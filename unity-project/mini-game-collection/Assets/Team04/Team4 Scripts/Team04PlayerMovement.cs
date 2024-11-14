using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public GameObject Player;
    public int stickCurrent;
    public int stickLast;
    public int rotateCurrent;
    public int rotateSpeed;

    public float speedCurrent;
    public float speedMax;

    public int xpos;
    public int ypos;
    public int targetxpos;
    public int targetypos;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        stickLast = stickCurrent; //stores the input from the previous frame
        stickCurrent = 0;//REPLACE THIS LINE WITH HOWEVER THE JOYSTICK INPUT WORKS



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
        if (Input.GetKeyDown(KeyCode.A))
        {
            Player.transform.eulerAngles = new Vector3 (0,0, Player.transform.eulerAngles.z + 10);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Player.transform.eulerAngles = new Vector3(0, 0, Player.transform.eulerAngles.z - 10);
        }



    }
}
