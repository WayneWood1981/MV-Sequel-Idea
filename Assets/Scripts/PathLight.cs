using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathLight : MonoBehaviour
{

    public List<GameObject> touchingPaths;

    public GameObject cubeCentre;

    public MeshRenderer centreRenderer;

    public Material greenMaterial;

    public Material redMaterial;

    public bool isNextToAchievablePath;

    public bool isAchievablePath;

    private void Start()
    {
        isAchievablePath = false;
        cubeCentre = transform.GetChild(0).gameObject;
        centreRenderer = cubeCentre.GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        //Performance issue in a large game...
        AchievablePath();
        
    }


    public void AchievablePath()
    {
        if (isNextToAchievablePath)
        {
            cubeCentre = transform.GetChild(0).gameObject;
            centreRenderer = cubeCentre.GetComponent<MeshRenderer>();
            centreRenderer.material = greenMaterial;
            this.transform.tag = "AchievablePath";
            isAchievablePath = true;
        }
        else
        {
            cubeCentre = transform.GetChild(0).gameObject;
            centreRenderer = cubeCentre.GetComponent<MeshRenderer>();
            centreRenderer.material = redMaterial;
            this.transform.tag = "Path";
            isAchievablePath = false;
        }
            
        
    }

    

    private void OnTriggerStay(Collider other)
    {
        if(other.transform.tag == "AchievablePath")
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
