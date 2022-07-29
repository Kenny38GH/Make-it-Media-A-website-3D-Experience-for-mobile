using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public Material firstMat;
    public Material secondMat;
    private MeshRenderer meshRenderer;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = firstMat;
    }
    public void ChangeTheMat()
    {
        Material currentMaterial = meshRenderer.material;
        Debug.Log("Current Mat: " + currentMaterial.name);
        Debug.Log("1st Mat: " + firstMat.name);
        Debug.Log("1st Mat: " + secondMat.name);
        if(currentMaterial.name == firstMat.name + " (Instance)")
        {
            meshRenderer.material = secondMat;
        }
        if(currentMaterial.name == secondMat.name + " (Instance)")
        {
            meshRenderer.material = firstMat;
        }
    }
}
