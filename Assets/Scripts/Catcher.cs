using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catcher : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            //Debug.Log("catch a ball");
            Destroy(other.transform.parent.gameObject);
            Destroy(this.gameObject);
        }
    }
}
