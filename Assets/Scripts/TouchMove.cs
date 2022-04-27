using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMove : MonoBehaviour
{

	private MirrorHandle mirrorHandle;

	private Vector3 lastMousePos;

	public float dragSpeed = 0.01f;

    private void Start()
    {
		mirrorHandle = GetComponent<MirrorHandle>();
    }
    void OnMouseDown()
	{
		//Stores position of when mouse button clicked
		lastMousePos = Input.mousePosition;
		
	}

	void OnMouseDrag()
	{
		//If mirror handle is between max and min set in mirrorhandle script
		if (mirrorHandle.yTransform < mirrorHandle.max || mirrorHandle.yTransform > mirrorHandle.min)
		{
			//Minus the mouse position from the lastmouse position
			Vector3 delta = Input.mousePosition - lastMousePos;

			//Store the transforms current position
			Vector3 pos = transform.position;

			//Y position of transform = Y position plus its position from last frame * speed
			pos.y += delta.y * dragSpeed;

			//Place in new position
			transform.position = pos;

			//Restart the loop until stop moving.
			lastMousePos = Input.mousePosition;
		}
		
	}

}
