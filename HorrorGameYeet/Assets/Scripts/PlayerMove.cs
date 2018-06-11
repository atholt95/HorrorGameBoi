using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    private CharacterController controller;

    public float moveSpeed;

    private Vector3 moveDirection;
    public float gravityScale;

    public Transform pivot;
    private GameObject _currentCam;

    public float rotateSpeed;

    public GameObject playerModel;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();

        _currentCam = pivot.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        float yStore = moveDirection.y;

        moveDirection = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal"));
        moveDirection = moveDirection.normalized * moveSpeed;
        moveDirection.y = yStore;

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }
	}

    public GameObject CurrentCamera
    {
        get { return _currentCam; }
        set
        {
            pivot = value.transform;
            _currentCam = pivot.gameObject;
        }
    }
}
