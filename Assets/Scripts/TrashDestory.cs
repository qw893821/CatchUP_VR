using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashDestory : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.transform.parent.gameObject);
    }
}
