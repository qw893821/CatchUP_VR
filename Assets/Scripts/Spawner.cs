using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    private static Spawner _instance;
    public static Spawner instance
    {
        get { return _instance; }
    }
    //a test cube
	public GameObject cube;
    private void Start()
    {
        if (_instance==null)
        {
            _instance = this;
        }
        else { Destroy(gameObject); }
    }
    private void Awake()
    {
        Debug.Log(GameManager.gm.width);
        InvokeRepeating("InstCube", 1.0f, 5.0f);    
    }

    void InstCube()
    {
        Instantiate(cube,PickPos(),Quaternion.identity);
    }

    Vector3 PickPos()
    {
        Vector3 pos;
        float heightOffset=10.0f;
        //int x = Random.Range(0,10);
        //int y = Random.Range(0,30);
        int x = 0;
        int y = 0;
        pos = GameManager.gm.gridsDic[x][y].pos;
        pos += new Vector3(0, heightOffset, 0);
        return pos;
    }
}
