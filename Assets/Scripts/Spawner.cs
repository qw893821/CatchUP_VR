using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public static Spawner instance { get; private set; }
    //a test cube
    public GameObject cube;
    private void Start()
    {
        InvokeRepeating("InstCube", 1.0f, 5.0f);
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else { Destroy(gameObject); }
    }

    void InstCube()
    {
        Instantiate(cube,PickPos(),Quaternion.identity);
    }

    Vector3 PickPos()
    {
        Vector3 pos;
        float heightOffset=10.0f;
        int x = Random.Range(0, 10);
        int y = Random.Range(0, 30);

        pos = GameManager.gm.gridsDic[x][y].pos;
        pos += new Vector3(0, heightOffset, 0);
        return pos;
    }
}
