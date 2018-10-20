using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//grid hold properity deternmines if the location can be spwan things or not
public class Grid {
    public OccpuyType type;//what type of thing have occupy the 
    public Vector3 pos;//position of the grid
    float width;//half width of the grid

    public void DrawGrid()
    {
        Vector3 pos1, pos2, pos3;
        pos1 = new Vector3(-width, 0f, width) + pos;
        pos2 = new Vector3(width, 0f, width) + pos;
        pos3 = new Vector3(width, 0f, -width) + pos;
        Debug.DrawLine(pos1,pos2);
        Debug.DrawLine(pos2, pos3);
    }

    public void InitialGrid(Vector3 pos,float width)
    {
        this.pos = pos;
        this.width = width;

    }
	
    public void GoodOccupy()
    {
        type = OccpuyType.good;
    }

    public void BadOccupy()
    {
        type = OccpuyType.bad;
    }


    //check if the hit point is inside the grid
    public void InGrid(Vector3 hitPos)
    {
        if ((hitPos.x <= pos.x + width) && (hitPos.x > pos.x-width) && (hitPos.z <= pos.z + width )&& (hitPos.z > pos.z - width))
        {
            Spawner.instance.CatechSpawner(this.pos);
            
        }
    }
}
