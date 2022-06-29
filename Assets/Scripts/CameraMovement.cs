using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float cameraSpeed = 5;

    public Vector3 camVelocity;
    PlayerController playerController;
    public void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
     
        if (playerController.canMove)
        {
            transform.position += Vector3.forward * cameraSpeed * Time.deltaTime;
        }

        camVelocity = Vector3.forward * cameraSpeed * Time.deltaTime;
    }
}
