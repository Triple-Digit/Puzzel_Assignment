using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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

    public bool selected;
    private bool scored;

    
    public void DestroyBlock()
    {   
        if (selected)
            return;
        else
        {
            selected = true;
            if (!scored)
            {
                scored = true;
                GameManager.instance.Score();
            }

            foreach (var item in sensor)
            {
                item.GetComponent<SensorAI>().DestroyAdjacentBlock(color);
            }
            transform.DOScale(0f, 0.4f);
            Destroy(gameObject, 0.5f);
        }        
    }

}
