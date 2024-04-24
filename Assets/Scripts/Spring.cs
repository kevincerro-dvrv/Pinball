using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private Vector3 initialPosition;
    private Vector3 limitPosition;
    private bool charging = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = rb.position;
        limitPosition = initialPosition + Vector3.back * 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightShift)) {
            charging = true;
        } else {
            charging = false;
        }

        if (Input.GetKeyUp(KeyCode.RightShift)) {
            rb.MovePosition(initialPosition);
        }
    }

    void FixedUpdate()
    {
        if (charging) {
            Vector3 targetPosition = rb.position + Vector3.back * speed * Time.fixedDeltaTime;

            if (targetPosition.z < limitPosition.z) {
                targetPosition.z = limitPosition.z;
            }

            rb.MovePosition(targetPosition);
        }
    }
}
