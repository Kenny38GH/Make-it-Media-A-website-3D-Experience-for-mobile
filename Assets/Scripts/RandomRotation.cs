using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    public float rotateSpeed ,rotateAroundSpeed;
    Vector3 rotateVec, rotateAroundVec;

     void Start()
     {  
        
        rotateSpeed = 0.04f;
        rotateAroundSpeed = 3.0f;
        rotateVec = new Vector3(
                     Random.Range(-360f, 360f),
                     Random.Range(-360f, 360f),
                     Random.Range(-360f, 360f));
        int sens = 0;
        if(Random.value<0.5f)
            sens=-1;
        else
            sens=1;
        rotateAroundVec = transform.up * sens;
     }

     void Update()
     {
        transform.Rotate(rotateVec * rotateSpeed * Time.deltaTime);
        if(this.transform.parent.GetComponent<StopRotation>().canRotateAround)
        {
            transform.RotateAround (Vector3.zero,rotateAroundVec,rotateAroundSpeed * Time.deltaTime);
        }
     }
}

