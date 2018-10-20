using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this class spawns ball(currently)
public class Spawner : MonoBehaviour {
    public static Spawner instance { get; private set; }
    //a test cube
    public GameObject cube;
    public GameObject catcherGO;
    private void Start()
    {
        //when game start create a cube every 5s
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

    //Instantiate a cube at picked pos
    void InstCube()
    {
        Instantiate(cube,PickPos(),Quaternion.identity);
    }

    //pick a position in the Grid list
    Vector3 PickPos()
    {
        //heightOffset is 0 now because the new cube model use a image as shadow.
        Vector3 pos;
        float heightOffset=0f;
        int x = Random.Range(0, 10);
        int y = Random.Range(0, 30);

        pos = GameManager.gm.gridsDic[x][y].pos;
        pos += new Vector3(0, heightOffset, 0);
        return pos;
    }


    public void CatechSpawner(Vector3 pos)
    {
        Instantiate(catcherGO,pos,Quaternion.identity);
    }
}
