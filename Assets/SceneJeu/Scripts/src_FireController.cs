using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class src_FireController : MonoBehaviour
{
    public static ParticleSystem[] listOfFires;

    void Awake()
    {
        listOfFires = this.GetComponentsInChildren<ParticleSystem>(true);
    }

    public void setVisibilityOn(int target)
    {
            listOfFires[target].Play();
    }

    public void setVisibilityOff(int target)
    {
        listOfFires[target].Stop();
    }
}
