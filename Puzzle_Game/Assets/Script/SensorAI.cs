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
        if (adjacentBlockColor != parentBlockColor)
        {
            return;
        }
        else
        {
            if (blockToDestroy.transform.gameObject.GetComponent<BlocksAI>().selected)
                return;
            else
            blockToDestroy.transform.gameObject.GetComponent<BlocksAI>().DestroyBlock();
        }
    }

    

    private void OnTriggerStay(Collider other)
    {
        if(!other)
        {
            return;
        }
        
        blockToDestroy = other.gameObject;
        
        if (blockToDestroy.tag == "BlueBlock")
        {
            adjacentBlockColor =  1;
        }

        if (blockToDestroy.tag == "GreenBlock")
        {
            adjacentBlockColor = 2;
        }

        if (blockToDestroy.tag == "YellowBlock")
        {
            adjacentBlockColor = 3;
        }

        if (blockToDestroy.tag == "RedBlock")
        {
            adjacentBlockColor = 4;
        }
    }
}
