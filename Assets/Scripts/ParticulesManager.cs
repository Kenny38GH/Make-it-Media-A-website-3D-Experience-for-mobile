using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticulesManager : MonoBehaviour
{
    public ParticleSystem part1, part2;
    private ParticleSystemRenderer psr1, psr2;
    public Material mat_streaks;
    public float lengthScale, lSdepart,lSHyperdrive;
    public float rateOverTime,rateOverTimeDepart,rateOverTimeHD;
    public float intensity,intensityDepart,intensityHD;
    public Color color;
    static float t = 0.0f;
    static float t2 = 0.0f;
    public bool isHyperDrive;
    // Start is called before the first frame update
    void Start()
    {
        psr1 = part1.GetComponent<ParticleSystemRenderer>();
        psr2 = part2.GetComponent<ParticleSystemRenderer>();
        
        lSdepart = 2;
        lSHyperdrive = 30;
        lengthScale = lSdepart;
        
        rateOverTimeDepart = 5.3f;
        rateOverTimeHD = 400f;
        rateOverTime = rateOverTimeDepart;
        
        color = mat_streaks.GetColor("_Color");    
        intensityDepart = 1;
        intensityHD = 15;
        intensity = intensityDepart;

        isHyperDrive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isHyperDrive)
        {
            HyperDrive();
        }
        if(!isHyperDrive)
        {
            t = 0;
            t2 = 0;
        }
        
        // PARTICULES SYSTEM CHANGEMENTS
        psr1.lengthScale = lengthScale;
        var emission = part1.emission;
        emission.rateOverTime = rateOverTime;

        psr2.lengthScale = lengthScale;
        var emission2 = part2.emission;
        emission2.rateOverTime = rateOverTime;

        //MATERIALS CHANGEMENTS
        mat_streaks.color = new Color(color.r * intensity, color.g * intensity, color.b * intensity, color.a);
    }



    public void HyperDrive()
    {
        lengthScale = Mathf.Lerp(lSdepart,lSHyperdrive,t);
        rateOverTime = Mathf.Lerp(rateOverTimeDepart,rateOverTimeHD,t);
        intensity = Mathf.Lerp(intensityDepart,intensityHD,t);

        t += 0.2f * Time.deltaTime;

        if(t >= 1.2f)
        {
            BacktoStaticFlow();
        }
    }

    public void BacktoStaticFlow()
    {
        lengthScale = Mathf.Lerp(lSHyperdrive,lSdepart,t2);
        rateOverTime = Mathf.Lerp(rateOverTimeHD,rateOverTimeDepart,t2);
        intensity = Mathf.Lerp(intensityHD,intensityDepart,t2);

        t2 += 0.3f * Time.deltaTime;

        if(t2 >= 1)
        {
            isHyperDrive = false;
        }
    }

    public void ActivateHyperDrive()
    {
        isHyperDrive = true;
    }
}
