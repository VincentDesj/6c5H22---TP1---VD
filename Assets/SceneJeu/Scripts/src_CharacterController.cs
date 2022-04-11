using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class src_CharacterController : MonoBehaviour
{
    private GameObject character;
    private List<Vector3> listOfPositions;
    private src_FireController src_FireController;

    public int targetIndex = -1;
    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.FindGameObjectWithTag("character");
        listOfPositions = new List<Vector3>();
        src_FireController = new src_FireController();


        for (int i = 0; i < src_FireController.listOfFires.Length; i++) {
            listOfPositions.Add(src_FireController.listOfFires[i].transform.position);
        }

        targetIndex = UnityEngine.Random.Range(0, listOfPositions.Count);
        targetPosition = listOfPositions[targetIndex];
        src_FireController.setVisibilityOn(targetIndex);
    }

    // Update is called once per frame
    void Update()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
        character.GetComponent<NavMeshAgent>().SetDestination(targetPosition);

        if (Vector3.Distance(transform.position, targetPosition) < .5f) { ChangeTarget(); }
    }

    private void ChangeTarget()
    {
        src_FireController.setVisibilityOff(targetIndex);

        int nextTargetIndex = targetIndex;
        while (nextTargetIndex == targetIndex) {
           nextTargetIndex = UnityEngine.Random.Range(0, listOfPositions.Count);
            Debug.Log("Le next target " + nextTargetIndex);
        }
        targetIndex = nextTargetIndex;


        targetPosition = listOfPositions[targetIndex];
        src_FireController.setVisibilityOn(targetIndex);
    }
}
