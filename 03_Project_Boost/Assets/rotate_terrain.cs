using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_terrain : MonoBehaviour {

    [SerializeField] float turn_speed;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        rotate();
	}

    void rotate()
    {
        float rotation_this_frame = turn_speed * Time.deltaTime;
        transform.Rotate(Vector3.forward * rotation_this_frame);
    }
}
