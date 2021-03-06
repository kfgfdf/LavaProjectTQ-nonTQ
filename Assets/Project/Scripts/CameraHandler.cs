﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public Transform camTrans, Pivot, Character, mTransform;

    public CharacterStatus characterstatus;
    public CameraConfig cameraconfig;

    public bool leftPivot;

    public float delta, mouseX, mouseY, smoothX, smoothY, smoothXVelocity, smoothYVelocity, lookAngle, titlAnge;

    public Transform targetLook;

    void Update()
    {
        Tick();
    }

    void Tick()
    {
        delta = Time.deltaTime;

        HandlePosition();
        HandleRotation();

        Vector3 targetPosition = Vector3.Lerp(mTransform.position, Character.position, 1);
        mTransform.position = targetPosition;
    }

    void TargetLook()
    {
        Ray ray = new Ray(camTrans.position, camTrans.forward * 2000);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            targetLook.position = Vector3.Lerp(targetLook.position, hit.point, Time.deltaTime * 40);
        }
        else
        {
            targetLook.position = Vector3.Lerp(targetLook.position, targetLook.transform.forward * 200, Time.deltaTime * 5);
        }
    }

    void HandlePosition()
    {
        float targetX = cameraconfig.normalX;
        float targetY = cameraconfig.normalY;
        float targetZ = cameraconfig.normalZ;

        if(characterstatus.isAiming)
        {
            targetX = cameraconfig.aimX;
            targetZ = cameraconfig.aimZ;
        }

        if(leftPivot)
        {
            targetX = -targetX;
        }

        Vector3 newPivotPosition = Pivot.localPosition;
        newPivotPosition.x = targetX;
        newPivotPosition.y = targetY;

        Vector3 newCameraPosition = camTrans.localPosition;
        newCameraPosition.z = targetZ;

        float t = delta * cameraconfig.pivotSpeed;
        Pivot.localPosition = Vector3.Lerp(Pivot.localPosition, newPivotPosition, t);
        camTrans.localPosition = Vector3.Lerp(camTrans.localPosition, newCameraPosition, t);
    }

    void HandleRotation()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        if(cameraconfig.turnSmooth > 0)
        {
            smoothX = Mathf.SmoothDamp(smoothX, mouseX, ref smoothXVelocity, cameraconfig.turnSmooth);
            smoothY = Mathf.SmoothDamp(smoothY, mouseY, ref smoothYVelocity, cameraconfig.turnSmooth);
        }
        else
        {
            smoothX = mouseX;
            smoothY = mouseY;
        }

        lookAngle += smoothX * cameraconfig.X_rotSpeed;
        Quaternion targetRot = Quaternion.Euler(0, lookAngle, 0);
        mTransform.rotation = targetRot;

        titlAnge -= smoothY * cameraconfig.Y_rotSpeed;
        titlAnge = Mathf.Clamp(titlAnge, cameraconfig.minAngle, cameraconfig.maxAngle);
        Pivot.localRotation = Quaternion.Euler(titlAnge, 0, 0);
    }
}
