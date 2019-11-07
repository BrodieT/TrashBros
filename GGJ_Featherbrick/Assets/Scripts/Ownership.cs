using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ownership : MonoBehaviour
{
    public int ownerID = 0;
  
    public void SetOwnership(int id)
    {
        ownerID = id;
        Debug.Log("I am owned by Player " + id);
    }
}
