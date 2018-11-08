using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public GameObject examplePlatform;
    public Transform generationPoint;
    public float platformWidth;

    public float distanceBetween;


    public float distanceBetweenMin;
    public float distanceBetweenMax;


    //public GameObject[] thePlatforms;
    private int platformSelector;
    private float[] platformWidths;

    public ObjectPooler[] theObjectPools;

    // for jumping

    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    public float heightChange;




	// Use this for initialization
	void Start () {
        // platformWidth = examplePlatform.GetComponent<BoxCollider2D>().size.x;
        platformWidths = new float[theObjectPools.Length];

        for(int i = 0; i< theObjectPools.Length; i++)
        {
            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = transform.position.y -3;
        maxHeight = maxHeightPoint.position.y;
	}
	
	// Update is called once per frame
	void Update () {

        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            platformSelector = Random.Range(0, theObjectPools.Length);


            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

            if(heightChange > maxHeight)
            {
                heightChange = maxHeight;
            }

            else if(heightChange < minHeight)
            {
                heightChange = minHeight;
            }

            //moves object
            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] /2) + distanceBetween, heightChange, transform.position.z);


            //copy, remove for pools
            //Instantiate(thePlatforms[platformSelector], transform.position, transform.rotation);
            
            GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] /2), transform.position.y, transform.position.z);

        }
    }
}
