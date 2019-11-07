//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class ControllerManager : MonoBehaviour
//{
//    List<GameObject> players;

//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {

//        HandleInput();
//    }

//    void HandleInput()
//    {
//        //Player 1 Controls
//        //-------------------------------------------------------
//        if (Input.GetAxisRaw("Player1LH") >  0)
//        {
//            Debug.Log("Player 1 moved right");
//        }
//        else if (Input.GetAxisRaw("Player1LH") < 0)
//        {
//            Debug.Log("Player 1 moved left");
//        }

//        if (Input.GetAxisRaw("Player1RH") != 0 || Input.GetAxisRaw("Player1RV") != 0)
//        {
//            Debug.Log("Player 1 is aiming at " + new Vector2(Input.GetAxisRaw("Player1RH"), Input.GetAxisRaw("Player1RV")));
//        }
       


//        if (Input.GetAxisRaw("Player1LT") != 0)
//        {
//            Debug.Log("Player 1 pressed Left Trigger");
//        }

//        if (Input.GetAxisRaw("Player1RT") != 0)
//        {
//            Debug.Log("Player 1 pressed Right Trigger");
//        }

//        if (Input.GetAxisRaw("Player1A") != 0)
//        {
//            Debug.Log("Player 1 pressed A");
//        }

//        //-------------------------------------------------------

        

//        //Player 2 Controls
//        //-------------------------------------------------------
//        if (Input.GetAxisRaw("Player2LH") > 0)
//        {
//            Debug.Log("Player 2 moved right");
//        }
//        else if (Input.GetAxisRaw("Player2LH") < 0)
//        {
//            Debug.Log("Player 2 moved left");
//        }


//        if (Input.GetAxisRaw("Player2RH") != 0 || Input.GetAxisRaw("Player2RV") != 0)
//        {
//            Debug.Log("Player 2 is aiming at " + new Vector2(Input.GetAxisRaw("Player2RH"), Input.GetAxisRaw("Player2RV")));
//        }

//        if (Input.GetAxisRaw("Player2LT") != 0)
//        {
//            Debug.Log("Player 2 pressed Left Trigger");
//        }

//        if (Input.GetAxisRaw("Player2RT") != 0)
//        {
//            Debug.Log("Player 2 pressed Right Trigger");
//        }

//        if (Input.GetAxisRaw("Player2A") != 0)
//        {
//            Debug.Log("Player 2 pressed A");
//        }
//        //-------------------------------------------------------

//        //Player 3 Controls
//        //-------------------------------------------------------

//        if (Input.GetAxisRaw("Player3LH") > 0)
//        {
//            Debug.Log("Player 3 moved right");
//        }
//        else if (Input.GetAxisRaw("Player3LH") < 0)
//        {
//            Debug.Log("Player 3 moved left");
//        }


//        if (Input.GetAxisRaw("Player3RH") != 0 || Input.GetAxisRaw("Player3RV") != 0)
//        {
//            Debug.Log("Player 3 is aiming at " + new Vector2(Input.GetAxisRaw("Player3RH"), Input.GetAxisRaw("Player3RV")));
//        }

//        if (Input.GetAxisRaw("Player3LT") != 0)
//        {
//            Debug.Log("Player 3 pressed Left Trigger");
//        }

//        if (Input.GetAxisRaw("Player3RT") != 0)
//        {
//            Debug.Log("Player 3 Right Trigger");
//        }

//        if (Input.GetAxisRaw("Player3A") != 0)
//        {
//            Debug.Log("Player 3 pressed A");
//        }

//        //-------------------------------------------------------

//        //Player4 Controls
//        //-------------------------------------------------------
//        if (Input.GetAxisRaw("Player4LH") > 0)
//        {
//            Debug.Log("Player 4 moved right");
//        }
//        else if (Input.GetAxisRaw("Player4LH") < 0)
//        {
//            Debug.Log("Player 4 moved left");
//        }


//        if (Input.GetAxisRaw("Player4RH") != 0 || Input.GetAxisRaw("Player4RV") != 0)
//        {
//            Debug.Log("Player 4 is aiming at " + new Vector2(Input.GetAxisRaw("Player4RH"), Input.GetAxisRaw("Player4RV")));
//        }

//        if (Input.GetAxisRaw("Player4LT") != 0)
//        {
//            Debug.Log("Player 4 Left Trigger");
//        }

//        if (Input.GetAxisRaw("Player4RT") != 0)
//        {
//            Debug.Log("Player 4 Right Trigger");
//        }

//        if (Input.GetAxisRaw("Player4A") != 0)
//        {
//            Debug.Log("Player 4 pressed A");
//        }
//        //-------------------------------------------------------

    





//    }

//}
