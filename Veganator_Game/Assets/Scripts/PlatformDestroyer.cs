using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour {

    public GameObject platformDesPoint;

    // Use this for initialization
    private void Start () {
        platformDesPoint = GameObject.Find("PlatformDesPoint");
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < platformDesPoint.transform.position.x)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);

        }
	}
}
