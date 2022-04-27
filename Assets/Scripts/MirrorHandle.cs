using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorHandle : MonoBehaviour
{

    [SerializeField]
    GameObject mirrorHandle;


    public HiddenPathReveal hiddenPathReveal;

    public float yTransform;

    public float max = 2.66f;
    public float min = -4.15f;

    public bool hasReachedMaxPosition;


    // Start is called before the first frame update
    void Start()
    {
        
        mirrorHandle = this.gameObject;

        //Place mirror at minimum distance at start
        mirrorHandle.transform.position = new Vector3(mirrorHandle.transform.position.x, min,
                mirrorHandle.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        //An instance of transform position Y
        yTransform = mirrorHandle.transform.position.y;

        //If reached max position..
        if(yTransform > max)
        {
            yTransform = max;
            mirrorHandle.transform.position = new Vector3(mirrorHandle.transform.position.x, max,
                mirrorHandle.transform.position.z);

            //Change bool to show hidden path for movement.
            hasReachedMaxPosition = true;
           
        }else if (yTransform < min)
        {
            //If reached min position, keep it there.
            yTransform = min;
            mirrorHandle.transform.position = new Vector3(mirrorHandle.transform.position.x, min,
                mirrorHandle.transform.position.z);
        }

        if(yTransform < max)
        {
            hasReachedMaxPosition = false;
        }

        if (hasReachedMaxPosition)
        {
            hiddenPathReveal.RevealPath();
            
            
        }
        else
        {
            hiddenPathReveal.HidePath();
            
        }

        
    }
}
