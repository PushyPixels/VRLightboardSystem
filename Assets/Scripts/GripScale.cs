using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GripScale : MonoBehaviour
{
    public WorldGrabMovement worldGrabMovement;

    private Transform objectToScale;
    private float gripDistance;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis(worldGrabMovement.leftHand.gripAxis) >= 0.25f && Input.GetAxis(worldGrabMovement.rightHand.gripAxis) >= 0.25f)
        {
            if(objectToScale)
            {
                float newGripDistance = (worldGrabMovement.leftHand.rigidbody.position - worldGrabMovement.rightHand.rigidbody.position).magnitude;
                objectToScale.localScale *= newGripDistance/gripDistance;
                gripDistance = newGripDistance;
            }
            else if(worldGrabMovement.leftHand.grippedObject && !worldGrabMovement.rightHand.grippedObject)
            {
                objectToScale = worldGrabMovement.leftHand.grippedObject.transform;
                gripDistance = (worldGrabMovement.leftHand.rigidbody.position - worldGrabMovement.rightHand.rigidbody.position).magnitude;
            }
            else if(worldGrabMovement.rightHand.grippedObject && !worldGrabMovement.leftHand.grippedObject)
            {
                objectToScale = worldGrabMovement.rightHand.grippedObject.transform;
                gripDistance = (worldGrabMovement.leftHand.rigidbody.position - worldGrabMovement.rightHand.rigidbody.position).magnitude;
            }
        }
        else
        {
            objectToScale = null;
        }
    }

    void OnValidate()
    {
        worldGrabMovement = GetComponent<WorldGrabMovement>();
	}
}
