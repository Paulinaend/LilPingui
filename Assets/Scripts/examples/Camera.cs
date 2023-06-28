using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public Transform target;
    public float OffsetY;

    void Update()
    {
        if (target != null)
        {
            transform.position = new Vector3(transform.position.x, target.position.y + OffsetY, target.position.z);
        }
    }
}
