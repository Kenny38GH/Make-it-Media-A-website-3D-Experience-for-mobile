
using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{

	public Transform camTransform;
	
	// Amplitude of the shake
	public float shakeAmountMax = 0.7f;
    static float t = 0.0f;
    static float t2 = 0.0f;
    private float shakeAmount;
    private bool isSkaking;

	Vector3 originalPos;

	void Awake()
	{
        isSkaking = false;
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
	}
	

    public void StartSkaking()
    {
        originalPos = camTransform.localPosition;
        t = 0;
        t2 = 0;
        isSkaking = true;

    }

	void Update()
	{
        if(isSkaking)
        {
            shakeAmount = Mathf.Lerp(0.0f,shakeAmountMax,t);
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
            t += 0.15f * Time.deltaTime;

            if(t >=1f)
            {
                shakeAmount = Mathf.Lerp(shakeAmountMax,0.0f,t2);
                camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
                t2 += 0.26f * Time.deltaTime;

                if(t2>=1)
                {
                    camTransform.localPosition = originalPos;
                    isSkaking = false;
                }
            }
        }
        
	}
}