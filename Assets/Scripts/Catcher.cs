using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catcher : MonoBehaviour {	

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            GameManager.gm.SCORE++;
            Destroy(other.transform.parent.gameObject);
            Destroy(this.gameObject);
        }
    }
}
