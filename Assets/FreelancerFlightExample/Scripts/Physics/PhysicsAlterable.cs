using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsAlterable : MonoBehaviour
{
    private Transform _currentGravityParent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool IsInLocalPhysicsGrid()
    {
        return _currentGravityParent != null;
    }

    public Transform GravityParent()
    {
        return _currentGravityParent;
    }

    private void OnTriggerEnter(Collider other)
    {
        LocalPhysicsGrid localPhysicsGrid = other.GetComponent<LocalPhysicsGrid>();
        if (localPhysicsGrid != null)
        {
            Debug.Log("Entered Volume");
            _currentGravityParent = localPhysicsGrid.transform;
            transform.SetParent(localPhysicsGrid.transform, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        LocalPhysicsGrid localPhysicsGrid = other.GetComponent<LocalPhysicsGrid>();
        if (localPhysicsGrid != null)
        {
            Debug.Log("Exited Volume");
            _currentGravityParent = null;
            transform.parent = null;
        }
    }
}
