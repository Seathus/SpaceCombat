using System;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100.2f;

    public Transform playerBody;

    public PhysicsAlterable _physicsAlterable;
    
    private float xRoration = 0f;

    public bool isFlyingShip;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (isFlyingShip) return;
        
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        
        if (!_physicsAlterable || !_physicsAlterable.GravityParent())
        {
            xRoration -= mouseY;
            xRoration = Mathf.Clamp(xRoration, -90f, 90f);
        
            transform.localRotation = Quaternion.Euler(xRoration, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX, Space.Self);
        }
        else
        {
            playerBody.RotateAround(playerBody.transform.position, playerBody.up, mouseX);
            transform.RotateAround(playerBody.transform.position, playerBody.right, -mouseY);
        }
    }
}