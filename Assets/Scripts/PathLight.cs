using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathLight : MonoBehaviour
{

    PlayerPathFinding playersPathFinding;

    public List<GameObject> touchingPaths;

    public GameObject cubeCentre;

    public MeshRenderer centreRenderer;

    public Material greenMaterial;

    public Material redMaterial;

    public bool isNextToAchievablePath;

    public bool isAchievablePath;

    public bool increaseIndexStopper;

    public bool isStartingTransform;

    public int index;
    public int test = 0;

    private int adjacentIndex;

    public List<Transform> touchingObjects;

    public int objectsTouched;

    private void Start()
    {
        playersPathFinding = FindObjectOfType<PlayerPathFinding>();
        touchingObjects = new List<Transform>();
        isAchievablePath = false;
        cubeCentre = transform.GetChild(0).gameObject;
        centreRenderer = cubeCentre.GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        //Performance issue in a large game...
        AchievablePath();
        objectsTouched = touchingObjects.Count;
        
    }


    public void AchievablePath()
    {
        if (isNextToAchievablePath)
        {
            cubeCentre = transform.GetChild(0).gameObject;
            centreRenderer = cubeCentre.GetComponent<MeshRenderer>();
            centreRenderer.material = greenMaterial;
            this.transform.tag = "AchievablePath";
            if (!playersPathFinding.pathRoute.Contains(this.transform))
            {
                
                playersPathFinding.pathRoute.Add(this.transform);
                
                
            }
            
            isAchievablePath = true;
        }
        else
        {
            cubeCentre = transform.GetChild(0).gameObject;
            centreRenderer = cubeCentre.GetComponent<MeshRenderer>();
            centreRenderer.material = redMaterial;
            this.transform.tag = "Path";
            if (playersPathFinding.pathRoute.Contains(this.transform))
            {
                
                playersPathFinding.pathRoute.Remove(this.transform);


            }

            isAchievablePath = false;
        }
            
        
    }


    private void OnTriggerStay(Collider other)
    {
        
        if (other.transform.tag == "AchievablePath")
        {
            
            isNextToAchievablePath = true;

        }

        

        
            
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "AchievablePath")
        {
            isNextToAchievablePath = false;

        }
    }




}
