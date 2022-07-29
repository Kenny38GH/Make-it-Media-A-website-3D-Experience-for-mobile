using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public GameObject currentState;
    public GameObject previousState;
    public GameObject nextState;
    public GameObject Media;
    public GameObject Studio;
    static float t = 0.0f;
    public bool isInSwitchingState;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        Media.transform.SetParent(currentState.transform);
        Studio.transform.SetParent(nextState.transform);
        currentState.transform.GetChild(0).transform.position = currentState.transform.position;
        nextState.transform.GetChild(0).transform.position = nextState.transform.position;
        nextState.transform.GetChild(0).GetComponent<StopRotation>().enabled = false;
        nextState.SetActive(false); // false
        isInSwitchingState = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isInSwitchingState)
        {
            nextState.SetActive(true);
            nextState.transform.GetChild(0).transform.position = Vector3.Lerp(nextState.transform.position,currentState.transform.position,t);
            currentState.transform.GetChild(0).transform.position = Vector3.Lerp(currentState.transform.position,previousState.transform.position,t);
            t += 0.1f * Time.deltaTime;
            if(t>=1)
            {
                currentState.transform.GetChild(0).transform.SetParent(previousState.transform);
                nextState.transform.GetChild(0).transform.SetParent(currentState.transform);
                nextState.SetActive(false); // false
                previousState.SetActive(false); // false
                currentState.transform.GetChild(0).GetComponent<StopRotation>().ActivateRotation();
                previousState.transform.GetChild(0).transform.position = nextState.transform.position;
                previousState.transform.GetChild(0).transform.SetParent(nextState.transform);
                isInSwitchingState = false;
            }
        }
        if(!isInSwitchingState)
        {
            t = 0;
        }
        
    }

    public void SwitchState()
    {
            currentState.transform.GetChild(0).GetComponent<StopRotation>().StopRotating();
            isInSwitchingState = true;
    }
}
