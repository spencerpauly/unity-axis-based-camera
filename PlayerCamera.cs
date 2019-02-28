using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerCamera : MonoBehaviour
{
    public PlayerMovement playerMovement;

    [Range(0, 90)]
    public int cameraAngle;
    [Range(2, 40)]
    public float cameraDistance;
    [Range(0, 20)]
    public float cameraOffset;
    [Range(0, 180)]
    public int cameraRotateStepAngle;
    [Range(0, 20)]
    public float cameraSmoothness;

    public Vector3 GetLookDirection() {
        return VectorPlus.DegreeToVector(transform.eulerAngles.y);
    }

}
