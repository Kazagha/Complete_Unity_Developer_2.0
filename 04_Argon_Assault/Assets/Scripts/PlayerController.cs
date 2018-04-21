using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    [Tooltip("In ms^-1")] [SerializeField] float xMoveSpeed = 3f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Fetch the 'Horizontal' input
        // Integer between -1 and 1
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");

        // Determine the offset for the current frame 
        // Throw * Move Speed * Delta Time
        float xOffset = xThrow * xMoveSpeed * Time.deltaTime;
        print(xOffset);
	}
}
