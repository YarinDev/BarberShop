using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LewisMotion : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;
    public GameObject player;
    private LineRenderer line;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.enabled)
        {
            agent.SetDestination(player.transform.position); //start AI path generation(A* algorithem)
            //and start moving on the path
            //draw path
            line.positionCount = agent.path.corners.Length;
            line.SetPositions(agent.path.corners);
            StartCoroutine(npcTalk());

            if (!agent.pathPending)
            {
                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                    {
                     //   animator.SetInteger("state", 5);
                        StartCoroutine(npcTalk());
                        //left chair location fot target
                        /*player.transform.SetPositionAndRotation(new Vector3(35.3f, 1.1f, -43.49f),
                            new UnityEngine.Quaternion(0, 90, 0, 0));*/
                        /*agent.transform.SetPositionAndRotation(new Vector3(35.78f, 1.1f, -43.49f),
                             Quaternion.Euler(new Vector3(0,90,0)));*/
                        //  StartCoroutine(delayBeforeStand());
                        // StartCoroutine(delayBeforeWalk());

                    }
                }
            }
        }

        IEnumerator npcTalk()
        {
            yield return new WaitForSeconds(5f); // delay
            animator.SetInteger("state", 2);
        }
        

        /*
            if (Input.GetKeyDown(KeyCode.Z))
                animator.SetInteger("state", 0);
            else if (Input.GetKeyDown(KeyCode.X))
                animator.SetInteger("state", 1);
            else if (Input.GetKeyDown(KeyCode.C))
                animator.SetInteger("state", 2);
            else if (Input.GetKeyDown(KeyCode.V))
                animator.SetInteger("state", 3);
            else if (Input.GetKeyDown(KeyCode.B))
                animator.SetInteger("state", 4);
            */
    }
}