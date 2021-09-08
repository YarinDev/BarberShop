using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BobMotion : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;
    public GameObject target_chair;
    private LineRenderer line;
    private bool flag = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;
        line = GetComponent<LineRenderer>();
        animator.SetInteger("state", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            StartCoroutine(enable_agent());
        }

        if (agent.enabled)
        {
            agent.SetDestination(target_chair.transform.position); //start AI path generation(A* algorithem)
            if (agent.destination == target_chair.transform.position)
            {
                StartCoroutine(BobMovement());
            }

            //and start moving on the path
            //draw path
            line.positionCount = agent.path.corners.Length;
            line.SetPositions(agent.path.corners);
        }
    }

    IEnumerator enable_agent()
    {
        flag = false;
        yield return new WaitForSeconds(2.5f); // delay
        animator.SetInteger("state", 2);
        yield return new WaitForSeconds(2f); // delay
        agent.enabled = true;

    }

    IEnumerator BobMovement()
    {
        animator.SetInteger("state", 3);
        yield return new WaitForSeconds(2f); // delay
        animator.SetInteger("state", 0);
        yield return new WaitForSeconds(10f); // delay
        animator.SetInteger("state", 1);
        yield return new WaitForSeconds(2f); // delay
    }
}