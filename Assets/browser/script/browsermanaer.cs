using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class browsermanaer : MonoBehaviour
{
    public GameObject slide;
    public Animator slideanim;
    public GameObject caches;

    public void Start()
    {
        slide.SetActive(false);
        caches.SetActive(false);
    }
    public void oslide()
    {
        slide.SetActive(true);
        slideanim.SetBool("slide", true);
    }
    public void ofSlide()
    {
        slide.SetActive(false);
    }
    public void oncaches()
    {
        caches.SetActive(true);
    }

    public void offcaches()
    {
        caches.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
