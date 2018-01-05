using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_terrain : MonoBehaviour {

    [SerializeField] float turn_speed;
    [SerializeField] Vector3 rotation_direction;

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
        transform.Rotate(rotation_direction * rotation_this_frame);
    }
}
