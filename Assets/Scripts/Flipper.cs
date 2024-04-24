using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    public enum FlipperSide {
        Left,
        Right
    }

    public FlipperSide flipperSide;

    private Rigidbody rb;
    private KeyCode activationKey;
    private float rotationAngle;
    private Vector3 initialRotation;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        activationKey = flipperSide == FlipperSide.Left ? KeyCode.LeftControl : KeyCode.RightControl;
        rotationAngle = GetRotationAngle();
        initialRotation = rb.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(activationKey)) {
            rb.MoveRotation(Quaternion.Euler(0, initialRotation.y + rotationAngle, 0));
        }

        if (Input.GetKeyUp(activationKey)) {
            rb.MoveRotation(Quaternion.Euler(initialRotation));
        }
    }

    private float GetRotationAngle()
    {
        return flipperSide == FlipperSide.Left ? -40f : 40f;
    }
}
