using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inputmanager : MonoBehaviour {
    public GameObject mainCamera;
    public GameObject textGO;
    Text text;

    int testCount;
	// Use this for initialization
	void Start () {
        text = textGO. GetComponent<Text>();
        testCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
        OVRInput.Update();
        if (Input.GetButtonUp("Fire1"))
        {
            ShotRay();
            testCount++;
            text.text = testCount.ToString();
        }
	}

    private void FixedUpdate()
    {
        OVRInput.FixedUpdate();
    }

    void ShotRay()
    {
        RaycastHit hit;
        int layerMask;
        layerMask = 1 << 9;
        if(Physics.Raycast(mainCamera.transform.position,mainCamera.transform.forward,out hit,layerMask))
        {
            Vector3 hitpos;
            hitpos = hit.point;
            //Instantiate(catcherGO,hitpos,Quaternion.identity);
            foreach(KeyValuePair<int,List<Grid>> myDic in GameManager.gm.gridsDic)
            {
                foreach(Grid gd in myDic.Value)
                {
                    gd.InGrid(hitpos);
                }
            }
        }
        else
        {
            Debug.Log("no hit");
        }

    }
}
