using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // The target marker.
    public Transform target;

    // Speed in units per sec.
    public float speed = 10;

    void Update()
    {
        // The step size is equal to speed times frame time.
        float step = speed * Time.deltaTime;
        // Set target position
        target.position = new Vector3(-0.344f, 0.24f, 0.309f);
        // Move our position a step closer to the target.
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}
