using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenPathReveal : MonoBehaviour
{

    public GameObject[] tilePaths;

    

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);

    }

    public void RevealPath()
    {
        this.gameObject.SetActive(true);
        foreach (var g in tilePaths)
        {
            PathLight pathLight = g.GetComponent<PathLight>();
            pathLight.isNextToAchievablePath = true;

        }
    }

    public void HidePath()
    {
        this.gameObject.SetActive(false);
        foreach (var g in tilePaths)
        {
            PathLight pathLight = g.GetComponent<PathLight>();
            pathLight.isNextToAchievablePath = false;

        }
    }
}
