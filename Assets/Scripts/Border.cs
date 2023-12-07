using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public string boundaryTag = "Border"; // Use the tag you assigned to your colliders.

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 newPosition = rb.position + moveDirection * moveSpeed * Time.deltaTime;

        if (CanMoveToPosition(newPosition))
        {
            rb.MovePosition(newPosition);
        }
    }

    private bool CanMoveToPosition(Vector3 newPosition)
    {
        Collider[] colliders = Physics.OverlapBox(newPosition, Vector3.one * 0.45f, Quaternion.identity);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag(boundaryTag))
            {
                return false; // A collision with a boundary occurred; movement is not allowed.
            }
        }

        return true; // No collisions with boundaries; movement is allowed.
    }
}

