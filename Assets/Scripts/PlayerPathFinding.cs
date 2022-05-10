using System;
using System.Collections;

using System.Collections.Generic;
using UnityEngine;


public class PlayerPathFinding : MonoBehaviour
{

    [SerializeField] Transform PlayerPivot;
    public float speed = 1;

    private Rigidbody rb;

    public Transform mainTarget;

    public Transform nextTarget;

    public Transform currentPlatform;

    public Transform endPosition;

    public GameObject[] paths;

    public CapsuleCollider coll;

    public List<Transform> pathRoute;

    private int currentTarget = 0;
    private bool hasReachedNextTile;

    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pathRoute = new List<Transform>();
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
                    endPosition = mainTarget;

                    
                    
                    
                }
            }
        }

        MovePlayer();
        
    }//Yuck!

    private void MovePlayer()
    {
        if (endPosition == null) { return; }

        if (targetTileLocation() == pathRoute.IndexOf(currentPlatform)) { return; }

        if (pathRoute.Contains(currentPlatform))
        {
            if(targetTileLocation() > pathRoute.IndexOf(currentPlatform))
            {
                currentTarget = pathRoute.IndexOf(currentPlatform) + 1;
            }
            else
            {
                currentTarget = pathRoute.IndexOf(currentPlatform) - 1;
            }
            
            
        }
        
        float distance = Vector3.Distance(transform.position, pathRoute[currentTarget].position);
        
        if (distance <= 0.1f)
        {
            Transform node = pathRoute[currentTarget];
            
            Vector3 offsetPosition = new Vector3(node.position.x, node.position.y + 0.6f, node.position.z);
            transform.position = offsetPosition;
            if(transform.position == offsetPosition)
            {
                currentTarget++;
            }
        }
        else
        {
            float step = speed * Time.deltaTime;
            Transform node = pathRoute[currentTarget];
            Vector3 offsetPosition = new Vector3(node.position.x, node.position.y + 0.6f, node.position.z);
            transform.position = Vector3.MoveTowards(transform.position, offsetPosition, step);
        }
    }

    private void UpdateCT()
    {
        currentTarget++;
    }

    private int targetTileLocation()
    {
        foreach (Transform t in pathRoute)
        {
            if(t == endPosition)
            {
                return pathRoute.IndexOf(t);
            }
            
        }
        return -1;
    }

    private void OnTriggerEnter(Collider other)
    {
        //If entering a trigger called Path, change it to Achievable.
        if(other.transform.tag == "Path")
        {

            pathRoute.Insert(0, other.transform);
            //Light up the path to show its an achievable route.


            other.GetComponent<PathLight>().isNextToAchievablePath = true;
            
            LightUpPath(other.transform.gameObject);
            other.transform.tag = "AchievablePath";

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
        PathLight pl = path.GetComponent<PathLight>();
        pl.isAchievablePath = true;
        pl.index = 1;
        pl.isStartingTransform = true;
        

    }


}
