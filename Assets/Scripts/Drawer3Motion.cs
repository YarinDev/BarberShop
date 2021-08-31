using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drawer3Motion : MonoBehaviour
{
    public Animator animator;
    public GameObject MainCam;
    public GameObject seeThroughCrossHair;
    public GameObject touchCrossHair;
    private bool isDrawerOpened = false, isFocusOn = false;
    public Text whatToDo;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        //check what object is in our focus
        if (Physics.Raycast(MainCam.transform.position, MainCam.transform.forward, out hit))
        {
            if (hit.transform.gameObject != null && hit.distance < 5)
            {
                //check that the object in camera focus is THIS
                if (this.transform.gameObject == hit.transform.gameObject)
                {
                    //change crosshair
                    if (!isFocusOn)
                    {
                        seeThroughCrossHair.SetActive(false);
                        touchCrossHair.SetActive(true);
                        isFocusOn = true;
                    }

                    //show the right inscription
                    if (isDrawerOpened)
                    {
                        whatToDo.text = "Press [E] to close the drawer";
                    }
                    else //the drawer is closed
                    {
                        whatToDo.text = "Press [E] to open the drawer";
                    }

                    whatToDo.gameObject.SetActive(true);

                    //and allow action on drawer
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        animator.SetBool("Drawer3Openning", !isDrawerOpened);
                        isDrawerOpened = !isDrawerOpened;
                    }
                }
                else //this.transform.gameObject != hit.transform.gameObject
                {
                    if (isFocusOn)
                    {
                        isFocusOn = false;
                        seeThroughCrossHair.SetActive(true);
                        touchCrossHair.SetActive(false);
                        whatToDo.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}