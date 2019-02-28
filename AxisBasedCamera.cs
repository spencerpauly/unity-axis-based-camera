using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisBasedCamera : PlayerCamera {

    private Vector3 desiredPosition;
    private Vector3 playerViewOffset;    
    private Vector3 offset;

    void Start() {
        offset = new Vector3(0, cameraDistance * Mathf.Sin(Mathf.Deg2Rad*cameraAngle), -cameraDistance * Mathf.Cos(Mathf.Deg2Rad*cameraAngle));
        playerViewOffset = new Vector3(0.0f, cameraOffset, 0.0f);
    }

    void LateUpdate() {
        if (InputManager.SwipeLeft()) {
            RotateCamera(-cameraRotateStepAngle);
        } else if (InputManager.SwipeRight()) {
            RotateCamera(cameraRotateStepAngle);
        }

        //This WIP code is if you want a multidimensional follow camera that's not axis limited

        //float diffAngle = playerMovement.transform.eulerAngles.y - VectorPlus.VectorToDegree(GetLookDirection());
        //offset = Quaternion.Euler(0, diffAngle, 0) * offset;
        //Debug.Log(diffAngle, this);

        //

        desiredPosition = playerMovement.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, cameraSmoothness * Time.deltaTime);
        transform.LookAt(playerMovement.transform.position + playerViewOffset);
    }

    public void RotateCamera(float angle)
    {
        offset = Quaternion.Euler(0, angle, 0) * offset;
    }

    
}