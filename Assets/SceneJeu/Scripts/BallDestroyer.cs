using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroyer : MonoBehaviour
{
    private float yPosition = -20f;

    void Update()
    {
        if (this.transform.position.y <= yPosition)
        {
            DestructionOfObject();
        }
    }

    void DestructionOfObject()
    {
        Destroy(this.gameObject);
    }
}
