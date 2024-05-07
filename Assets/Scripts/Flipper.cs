using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour {
    public enum FlipperSide {
        Left,
        Right
    }

    public FlipperSide flipperSide;
    private Rigidbody rb;

    private KeyCode activationKey;
    private float rotationAngle;

    private Vector3 initRotation;

    private bool flipperForward;
    private bool flipperBack;


    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
        activationKey = GetActivationKey();
        rotationAngle = GetRotationAngle();

        initRotation = rb.rotation.eulerAngles;        
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(activationKey)) {
            flipperForward = true;                        
        }
        if(Input.GetKeyUp(activationKey)) {
            flipperBack = true;
        }
        
    }

    void FixedUpdate() {
        if(flipperForward) {
            rb.MoveRotation(Quaternion.Euler(0, initRotation.y + rotationAngle, 0));
            flipperForward = false;
        }
        if(flipperBack) {
            rb.MoveRotation(Quaternion.Euler(initRotation));
            flipperBack = false;
        }
    }

    private KeyCode GetActivationKey() {
        return flipperSide == FlipperSide.Left?KeyCode.LeftControl:KeyCode.RightControl;
    }

    private float GetRotationAngle() {
        return flipperSide == FlipperSide.Left?-40f:40;
    }
}
