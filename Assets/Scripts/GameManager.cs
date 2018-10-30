using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum OccpuyType{
    good,//player occupied
    bad,//enemy occupied
    neutral//nothing in the grid
}
public class GameManager : MonoBehaviour
{
    public static GameManager gm { get; private set; }
    public Vector3 gridStartPos;
    public float width;
    public Dictionary<int, List<Grid>> gridsDic;

    float totalWidth;
    float totalLength;
    public Vector3 trashPos;
    private void Awake()
    {
        if (gm == null)
        {
            gm = this;
        }
        else { Destroy(this); }
        trashPos = new Vector3(100,100,100);
    }
    void Start()
    {
        
        width = 1.5f;
        /*Dictionary<int, List<Grid>> */gridsDic = new Dictionary<int, List<Grid>>();
        gridStartPos = Vector3.zero - new Vector3(totalWidth / 2 + width, 0f, -10.0f);
        totalWidth = 30.0f;
        totalLength = 15.0f;
        //width is 0.5, so the gird is 1.0f width. and the grid creation loop could use ++ operator
        for (int x = 0; x < totalLength/(int)(width*2); x++)
        {
            gridStartPos= Vector3.zero - new Vector3(totalWidth / 2 + width, 0f, -10.0f - x * 2 * width);
            if (!gridsDic.ContainsKey(x))
            {
                gridsDic.Add(x,new List<Grid>());
            }
            for (int y = 0; y < totalWidth/ (int)(width * 2); y++)
            { 
                gridsDic[x].Add(new Grid());
                gridsDic[x][y].InitialGrid(gridStartPos,width,x);
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
        GameOverTest();
    }

    //remove a grid when is is marked as dead
    public void RemoveGrid(Grid grid)
    {
        gridsDic[grid.myRow].Remove(grid);
    }
    
    //whenever one row is fully hit by egg game end.
    void GameOverTest()
    {
        foreach (KeyValuePair<int, List<Grid>> myDic in gridsDic)
        {
            if (myDic.Value.Count==0)
            {
                Time.timeScale = 0.01f;
                Debug.Log("game over");
            }
        }
    }
}

