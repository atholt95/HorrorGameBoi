using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove : MonoBehaviour {

    Rigidbody _rigidBody;
    
    public float speed = 20f;

    public Camera cam;
	// Use this for initialization
	void Awake () {
        _rigidBody = GetComponent<Rigidbody>();

        if (cam == null)
        {
            cam = Camera.main; // See it's right here bitchtits
        }
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 right = cam.transform.right;
        Vector3 forward = Vector3.Cross(right, Vector3.up);

        Vector3 movement = Vector3.zero;

        movement += right * (Input.GetAxis("Horizontal") * speed);
        movement += forward * (Input.GetAxis("Vertical") * speed);

        _rigidBody.AddForce(movement, ForceMode.VelocityChange);
    }
}
