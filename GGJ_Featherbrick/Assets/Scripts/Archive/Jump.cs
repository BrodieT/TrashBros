using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public bool is_grounded;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(this.transform.GetChild(0).GetComponent<check_grounded>().is_grounded);
        //if (Input.anyKeyDown == true && this.transform.GetChild(0).GetComponent<check_grounded>().is_grounded == true)
        // {
        //     this.GetComponent<Rigidbody>().AddForce(Vector2.up * 500.0f);
        //     this.transform.GetChild(0).GetComponent<check_grounded>().is_grounded = false;
        // }

        Debug.Log(is_grounded);
        if (Input.anyKeyDown == true && is_grounded == true)
        {
            this.GetComponent<Rigidbody>().AddForce(Vector2.up * 200.0f);
            is_grounded = false;
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Building")
        {
            is_grounded = true;
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Building")
        {
            is_grounded = false;
        }
    }

    //bool isGrounded()
    //{
    //    return Physics.Raycast(transform.position, -Vector3.up, 0.1f);
    //}
}
