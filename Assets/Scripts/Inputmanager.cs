using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inputmanager : MonoBehaviour {
    public GameObject mainCamera;
    public GameObject textGO;
    public GameObject debugText;
    Text text,text2;
    

    int testCount;
	// Use this for initialization
	void Start () {
        text = textGO. GetComponent<Text>();
        text2 = debugText.GetComponent<Text>();
        testCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
        OVRInput.Update();
        if (Input.GetButtonUp("Fire1"))
        {
            ShotRay();
        }
        float offDis;
        offDis = Vector3.Distance(mainCamera.transform.forward,Vector3.forward);
        text2.text = (offDis.ToString());
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
        if(Physics.Raycast(mainCamera.transform.position,mainCamera.transform.forward,out hit/*,layerMask*/))
        {
            Vector3 hitpos;
            hitpos = hit.point;
            foreach (KeyValuePair<int, List<Grid>> myDic in GameManager.gm.gridsDic)
            {
                foreach (Grid gd in myDic.Value)
                {
                    gd.InGrid(hitpos);
                }
            }
            text.text = "shot ray and hit";
        }
        else
        {
            text.text = "shot ray no hit";
        }
        
    }
}
