using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightMotion : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}