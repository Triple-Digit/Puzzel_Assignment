using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorAI : MonoBehaviour
{
    public int adjacentBlockColor;
    public GameObject blockToDestroy;

    #region Color index
    /*
     * Blue = 1
     * Green = 2
     * Yellow = 3
     * Red = 4
    */
    #endregion

    public void DestroyAdjacentBlock(int parentBlockColor)
    {        
        adjacentBlockColor = GetColor();

        Debug.Log(adjacentBlockColor.ToString());

        if (parentBlockColor == adjacentBlockColor)
        {
            Debug.Log("Same Color");
            if (blockToDestroy.GetComponent<BlocksAI>().selected != true)
            {
                blockToDestroy.GetComponent<BlocksAI>().DestroyBlock();
            }
        }
        else return;
    }

    private int GetColor()
    {
        if(blockToDestroy == null)
        {
            return 0;
        }
        return blockToDestroy.gameObject.GetComponent<BlocksAI>().color;
    }

    private void OnTriggerStay(Collider other)
    {
        if(!other)
        {
            return;
        }
        
        blockToDestroy = other.gameObject;
    }
}
