using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour {
    private float speed = 5f;
    private float runLimit = 3.5f;

    private Vector3 initPosition;
    private Vector3 limitPosition;
    private Rigidbody rb;

    private bool charging;
    private bool release;
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
        initPosition = rb.position;
        limitPosition = initPosition - Vector3.forward * runLimit;                
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetKey(KeyCode.RightShift)) {
            charging = true;
            release = true;
        } else {
            charging = false;
        }
    }

    void FixedUpdate() {
        if(charging) {            
            Vector3 targetPosition = rb.position + Vector3.back * speed * Time.fixedDeltaTime;
            if(targetPosition.z < limitPosition.z) {
                targetPosition.z = limitPosition.z;
            } 

            rb.MovePosition(targetPosition);
        } else if(release) {
            rb.MovePosition(initPosition);
            release = false;
        }
    }
}
