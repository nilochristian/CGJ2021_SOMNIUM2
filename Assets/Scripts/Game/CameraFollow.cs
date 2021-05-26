using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothAngle = 0.2f;
    public Vector3 offset;
    //Camera Update
    private void LateUpdate()
    {
        Vector3 pos = target.position - offset;
        Vector3 smoothPos =
            Vector3.Lerp(transform.position, pos, smoothAngle);
        transform.position = smoothPos;
    }
}
