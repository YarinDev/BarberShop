using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoorMotion : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("open", true);
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("open", false);
    }

    // Update is called once per frame
    void Update()
    {
    }
}