using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Camera/Config")]
public class CameraConfig : ScriptableObject
{
    public float turnSmooth, pivotSpeed, Y_rotSpeed, X_rotSpeed, minAngle, maxAngle, normalZ,
    normalX, aimZ, aimX, normalY;
}
