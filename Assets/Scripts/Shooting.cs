using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject aCamera;

    public GameObject target;

    public GameObject muzzle;

    private LineRenderer line;
    public AudioSource shootingSound;
    public GameObject Knight;
    private Animator animator;
    private static int numHits;

    // Start is called before the first frame update
    void Start()
    {
        numHits = 0;
        line = GetComponent<LineRenderer>();
        animator = Knight.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit hit;
            if (Physics.Raycast(aCamera.transform.position, aCamera.transform.forward, out hit))
            {
                target.transform.position = hit.point;
                //draw line
                shootingSound.Play();
                StartCoroutine(ShowFlash());


                //check that the bullet hit the knight
                if (hit.transform.gameObject == Knight)
                {
                    numHits++;
                    if (numHits<3)
                    {
                        StartCoroutine(KnightFallAndGettingUp());

                    }
                    else
                    {
                        animator.SetInteger("state", 4); //dying

                    }
                }
            }
        }
    }

    IEnumerator KnightFallAndGettingUp()
    {
        animator.SetInteger("state", 2); //fall back
        yield return new WaitForSeconds(2f); // delay
        animator.SetInteger("state", 3); //getting up
    }
    

    IEnumerator ShowFlash()
    {
        //draw flash
        line.SetPosition(0, muzzle.transform.position);
        line.SetPosition(1, target.transform.position);

        //all the lines before next run immidiatly
        yield return new WaitForSeconds(0.1f); // delay
        //the next line will be executed after the delay
        //erase flash
        line.SetPosition(0, transform.position);
        line.SetPosition(1, transform.position);
    }
}