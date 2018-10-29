using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitGround : MonoBehaviour {
    public Grid targetGrid=new Grid();
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Ground")
        {
            GameManager.gm.RemoveGrid(targetGrid);
        }
    }
}
