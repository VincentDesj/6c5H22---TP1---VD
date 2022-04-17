using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ball;
    public float delayTime = 2.5f;

    void Start()
    {
        StartCoroutine(DelayedSpawn());
    }

    IEnumerator DelayedSpawn()
    {
        while (true) {
            yield return new WaitForSeconds(delayTime);
            Instantiate(ball, this.transform.position, this.transform.rotation);
        }
        
    }
}
