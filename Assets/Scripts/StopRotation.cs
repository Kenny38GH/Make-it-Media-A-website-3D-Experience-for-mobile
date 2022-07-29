using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopRotation : MonoBehaviour
{
    public bool canRotateAround;
    void Start()
    {
        canRotateAround = true;
    }
    public void StopRotating()
     {
        canRotateAround = false;
     }

     public void ActivateRotation()
     {
        canRotateAround = true;
     }
}
