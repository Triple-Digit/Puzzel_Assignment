using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksAI : MonoBehaviour
{
    [Header("Block Variables")]
    public int color;
    #region Color index
    /*
     * Blue = 1
     * Green = 2
     * Yellow = 3
     * Red = 4
    */
    #endregion

    [Header("Sensors")]
    public GameObject[] sensor;


    public bool selected, scored;
    

    private void Update()
    {
        if(selected)
        {
            DestroyBlock();
            selected = false;
        }
    }

    public void DestroyBlock()
    {
        Debug.Log("Destroying");
                        
        if(!scored)
        {
            scored = true;
            GameManager.instance.Score();
        }

        foreach (var item in sensor)
        {
            
            item.GetComponent<SensorAI>().DestroyAdjacentBlock(color);
        }
        
        Destroy(gameObject, 0.5f);
    }

}
