using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class src_CharacterController : MonoBehaviour
{
    private GameObject character;
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private float speed = 1.5f;
    private int nextTargetIndex;
    private float distanceBetween;

    public float runMultipier = 2.5f;
    public float crouchMultipier = .8f;

    private List<Vector3> listOfPositions;
    private src_FireController src_FireController;

    public int targetIndex = -1;
    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.FindGameObjectWithTag("character");
        navMeshAgent = character.GetComponent<NavMeshAgent>();
        listOfPositions = new List<Vector3>();
        src_FireController = new src_FireController();

        animator = GetComponent<Animator>();

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
        SetAnimation();
        animator.SetFloat("speed", speed);
    }

    void FollowTarget()
    {
        navMeshAgent.SetDestination(targetPosition);

        if (Vector3.Distance(transform.position, targetPosition) < 1f) { ChangeTarget(); }
    }

    private void ChangeTarget()
    {
        src_FireController.setVisibilityOff(targetIndex);

        nextTargetIndex = targetIndex;
        while (nextTargetIndex == targetIndex) {
           nextTargetIndex = UnityEngine.Random.Range(0, listOfPositions.Count);
        }

        targetIndex = nextTargetIndex;
        targetPosition = listOfPositions[targetIndex];
        src_FireController.setVisibilityOn(targetIndex);
    }

    private void SetAnimation() 
    {
        distanceBetween = Vector3.Distance(transform.position, targetPosition);

        if (animator.GetBool("isCrouching") == true) {
            navMeshAgent.speed = speed * crouchMultipier;
        }
        else if (distanceBetween > 4)
        {
            animator.SetBool("isRunning", true);
            animator.SetBool("isWalking", false);
            navMeshAgent.speed = speed * runMultipier;
        }
        else
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isWalking", true);
            navMeshAgent.speed = speed;
        }
    }
}
