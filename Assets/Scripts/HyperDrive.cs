using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperDrive : MonoBehaviour
{
    public bool isHyperDrive;
    public GameObject ObjectParent;
    private float posZDepart, posZHD;
    static float t = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        isHyperDrive = false;
        posZDepart = ObjectParent.transform.position.z;
        posZHD = -200f;
    }

    // Update is called once per frame
    void Update()
    {
        if(isHyperDrive)
        {
            HyperDriveTravel();
        }
    }
    private void HyperDriveTravel()
    {
        ObjectParent.transform.position = new Vector3(ObjectParent.transform.position.x, ObjectParent.transform.position.y,(Mathf.Lerp(posZDepart,posZHD,t)));
        t += 0.5f * Time.deltaTime;
    }

    public void ActivateHyperDrive()
    {
        isHyperDrive = true;
    }
}
