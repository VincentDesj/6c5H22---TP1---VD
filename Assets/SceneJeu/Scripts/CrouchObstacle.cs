using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchObstacle : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("character")) 
        {
            animator.SetBool("isCrouching", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("character"))
        {
            animator.SetBool("isCrouching", false);
        }
    }
}
