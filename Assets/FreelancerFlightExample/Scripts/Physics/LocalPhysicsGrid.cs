using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalPhysicsGrid : MonoBehaviour
{
    private Vector3 up;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.up, .2f);
        //Debug.Log(transform.up);
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(Vector3.up, .3f);
    }
}
