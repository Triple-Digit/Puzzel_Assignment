using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{    
    private int randomnumber;
    public bool needToSpawn;

    
    
    private void Start()
    {
        Spawn();
        
    }

    private void Update()
    {
        if(needToSpawn)
        {
            Spawn();
        }
    }


    void Spawn()
    {
        needToSpawn = false;
        randomnumber = Random.Range(0, GameManager.instance.blocks.Length - 1);
        GameObject newBlock = GameManager.instance.blocks[randomnumber];
        Instantiate(newBlock, transform.position, newBlock.transform.rotation);
        
    }    
}
