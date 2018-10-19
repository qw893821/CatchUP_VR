﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum OccpuyType{
    good,//player occupied
    bad,//enemy occupied
    neutral//nothing in the grid
}
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager gm
    {
        get { return _instance; }
    }
    public Vector3 gridStartPos;
    public float width;
    public Dictionary<int, List<Grid>> gridsDic/* = new Dictionary<int, List<Grid>>()*/;

    float totalWidth;
    float totalLength;
    // Use this for initialization
    void Start()
    {
        if (_instance!=this)
        {
            _instance = this;
        }
        else { Destroy(gameObject); }
        width = 0.5f;
        /*Dictionary<int, List<Grid>> */gridsDic = new Dictionary<int, List<Grid>>();
        gridStartPos = Vector3.zero - new Vector3(totalWidth / 2 + width, 0f, -10.0f);
        totalWidth = 30.0f;
        totalLength = 10.0f;
        //width is 0.5, so the gird is 1.0f width. and the grid creation loop could use ++ operator
        for (int x = 0; x < totalLength; x++)
        {
            gridStartPos= Vector3.zero - new Vector3(totalWidth / 2 + width, 0f, -10.0f - x * 2 * width);
            if (!gridsDic.ContainsKey(x))
            {
                gridsDic.Add(x,new List<Grid>());
            }
            for (int y = 0; y < totalWidth; y++)
            { 
                gridsDic[x].Add(new Grid());
                gridsDic[x][y].InitialGrid(gridStartPos,width);
                gridStartPos += new Vector3(2*width,0f,0f);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        foreach(KeyValuePair<int,List<Grid>> myDic in gridsDic)
        {
            foreach(Grid gd in myDic.Value)
            {
                gd.DrawGrid();
            }
        }


    }
}
