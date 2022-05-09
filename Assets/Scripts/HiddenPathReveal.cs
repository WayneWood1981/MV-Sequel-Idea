using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenPathReveal : MonoBehaviour
{

    [SerializeField]
    public GameObject path;

    public GameObject[] tilePaths;

    

    // Start is called before the first frame update
    void Start()
    {
        

    }

    public void RevealPath()
    {
        path.SetActive(false);

        foreach (GameObject g in tilePaths)
        {
            g.GetComponent<MeshRenderer>().enabled = true;
            BoxCollider[] childColls = GetComponentsInChildren<BoxCollider>();
            MeshRenderer[] childRenderers = GetComponentsInChildren<MeshRenderer>();
            foreach (var cRend in childRenderers)
            {
                cRend.enabled = true;
            }
            foreach (var cColl in childColls)
            {
                cColl.enabled = true;
            }
           

        }
    }

    public void HidePath()
    {
        path.SetActive(true);

        foreach (GameObject g in tilePaths)
        {
            
            g.GetComponent<MeshRenderer>().enabled = false;
            BoxCollider[] childColls = GetComponentsInChildren<BoxCollider>();
            MeshRenderer[] childRenderers = GetComponentsInChildren<MeshRenderer>();
            foreach (var cRend in childRenderers)
            {
                cRend.enabled = false;
            }
            foreach (var cColl in childColls)
            {
                cColl.enabled = false;
            }
            PathLight pathLight = g.GetComponent<PathLight>();
            pathLight.isNextToAchievablePath = false;

        }
    }
}
