using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerPathFinding : MonoBehaviour
{
    
    
    public float speed = 100;

    private Rigidbody rb;

    public Transform mainTarget;

    public Transform nextTarget;

    public Transform currentPlatform;

    public GameObject[] paths;

    public CapsuleCollider coll;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //If mouse button pressed

        if (Input.GetMouseButtonDown(0))
        {
            //Stored mouse button position
            Vector3 mousePosition = Input.mousePosition;

            //Raycast to object clicked on.
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                //If clicked on possible path to walk on.
                if(hit.collider.transform.tag == "AchievablePath")
                {

                    mainTarget = hit.collider.transform;
                    
                }
            }
        }
        
    }


    private void OnTriggerEnter(Collider other)
    {
        //If entering a trigger called Path, change it to Achievable.
        if(other.transform.tag == "Path")
        {
            other.transform.tag = "AchievablePath";

            //Light up the path to show its an achievable route.
            LightUpPath(other.transform.gameObject);
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        //Display current tile player is on.
        currentPlatform = other.transform;
    }





    private void LightUpPath(GameObject path)
    {
        //Change light to green to show path is accessible.
        path.GetComponentInChildren<PathLight>().isAchievablePath = true;
    }


}
