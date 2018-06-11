using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour {

    public GameObject cam;

    private PlayerMove playerMove;

	// Use this for initialization
	void Start () {
        playerMove = FindObjectOfType<PlayerMove>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            playerMove.CurrentCamera.SetActive(false);
            playerMove.CurrentCamera = cam;
            playerMove.CurrentCamera.SetActive(true);
        }
    }
}
