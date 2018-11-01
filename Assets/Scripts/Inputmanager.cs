using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inputmanager : MonoBehaviour {
    public GameObject mainCamera;
    public GameObject textGO;
    public GameObject debugText;
    Text text,text2;
    Counter counter;

	// Use this for initialization
	void Start () {
        text = textGO. GetComponent<Text>();
        text2 = debugText.GetComponent<Text>();
        counter = new Counter();
	}
	
	// Update is called once per frame
	void Update () {
        OVRInput.Update();
        if (Input.GetButtonUp("Fire1"))
        {
            ShotRay();
        }
        text2.text = GameManager.gm.SCORE.ToString();
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
            //could compare the column first then row to save performance. will change it later
            foreach (KeyValuePair<int, List<Grid>> myDic in GameManager.gm.gridsDic)
            {
                foreach (Grid gd in myDic.Value)
                {
                    //gd.InGrid(hitpos);
                    if (gd.InGrid(hitpos))
                    {

                    }
                }
            }
            text.text = "shot ray and hit";
        }
        else
        {
            text.text = "shot ray no hit";
        }
        
    }

    //when spawn a catcher, wait until next possible spawn
    
}
