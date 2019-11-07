//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Pickup_Throw : MonoBehaviour
//{
//    private CharacterController controller;
//    public LayerMask trashMask;
//    public GameObject trashObject;
//    private Rigidbody trashBody;
//    private Transform trashTransform;
//    bool trashPickedUp;
//    bool holdingTrash;

//    bool initiallyPressed;
//    bool currentlyPressed;


//    // Start is called before the first frame update
//    void Start()
//    {
//        controller = GetComponent<CharacterController>();
//        trashBody = trashObject.GetComponent<Rigidbody>();
//        trashTransform = /*trashObject.GetComponent<Transform>();//*/trashObject.transform;
//        //holdingTrash = false;
//        //canHoldTrash = false;
//        trashPickedUp = false;
//        holdingTrash = false;
//        initiallyPressed = false;
//        currentlyPressed = false;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        //if(holdingTrash)
//        //{
//        //    throwTrash();
//        //}

//        //checkTrashProximity();
//        //holdTrash();
//        //if (Input.GetAxisRaw("Pick Up") > 0 && currentlyPressed && initiallyPressed)
//        //{
//        //    initiallyPressed = false;
//        //}
//        //if (Input.GetAxisRaw("Pick Up") > 0 && !initiallyPressed && !currentlyPressed)
//        //{
//        //    initiallyPressed = true;
//        //    currentlyPressed = true;
//        //}
//        //if (Input.GetAxisRaw("Pick Up") == 0 && currentlyPressed)
//        //{
//        //    currentlyPressed = false;
//        //}

//        PickUpTrash();
//        HoldTrash();
//        ThrowTrash();
//    }


//    bool TrashIsInSight()
//    {
//        Collider[] trashProximity = Physics.OverlapSphere(transform.position, 1, trashMask);
//        int i = 0;
//        if (i < trashProximity.Length)
//            return true;
//        else
//            return false;
//    }

//    bool CanPickUpTrash()
//    {
//        if (initiallyPressed)
//            return true;
//        else
//            return false;

//        //if (Input.GetAxisRaw("Pick Up") == 0 && !holdingTrash)
//        //{
//        //    trashPickedUp = false;
//        //    return true;
//        //}
//        //else
//        //    return false;
//    }

//    void PickUpTrash()
//    {
//        if (!trashPickedUp && !holdingTrash)
//            if (CanPickUpTrash() && TrashIsInSight())
//                if (Input.GetAxisRaw("Pick Up") > 0)
//                {
//                    trashPickedUp = true;
//                }
//    }

//    void HoldTrash()
//    {
//        if (trashPickedUp && Input.GetAxisRaw("Pick Up") > 0)
//        {
//            trashTransform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), trashTransform.rotation);
//            holdingTrash = true;
//        }
//        else
//            holdingTrash = false;
//    }

//    void ThrowTrash()
//    {
//        if (holdingTrash && Input.GetAxisRaw("Throw") > 0)
//        {
//            trashBody.AddForce(new Vector3(200, 100));
//            holdingTrash = false;
//        }
//    }









//    ////  Check if trash is within pickup radius.
//    //bool getIsTrashInSight()
//    //{
//    //    Collider[] trashProximity = Physics.OverlapSphere(transform.position, 1, trashMask);
//    //    int i = 0;
//    //    if (i < trashProximity.Length)
//    //       return true;
//    //    else 
//    //        return false;
//    //}

//    ////  Check proximity of trash
//    //void checkTrashProximity()
//    //{
//    //    if (getIsTrashInSight())
//    //        canHoldTrash = true;
//    //    else
//    //        canHoldTrash = false;
//    //}

//    ////  Hold trash
//    //void holdTrash()
//    //{
//    //    if ((canHoldTrash || holdingTrash) && Input.GetAxisRaw("Pick Up") > 0)
//    //    {
//    //        trashTransform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), trashTransform.rotation);
//    //        holdingTrash = true;
//    //    }
//    //    else
//    //        holdingTrash = false;
//    //}

//    ////  Throw trash if holding
//    //void throwTrash()
//    //{
//    //    if(Input.GetAxisRaw("Throw") > 0)
//    //    {
//    //        trashBody.AddForce(new Vector3(1, 2));
//    //        Input.ResetInputAxes();
//    //        holdingTrash = false;
//    //    }
//    //}
//}
