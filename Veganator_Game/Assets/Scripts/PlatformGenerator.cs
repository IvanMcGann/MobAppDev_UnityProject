using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public GameObject examplePlatform;
    public Transform generationPoint;
    public float platformWidth;

    public float distanceBetween;

	// Use this for initialization
	void Start () {
        platformWidth = examplePlatform.GetComponent<BoxCollider2D>().size.x;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < generationPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);
            //copy
            Instantiate(examplePlatform, transform.position, transform.rotation);
        }
	}
}
