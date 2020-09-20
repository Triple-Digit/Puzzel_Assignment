using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Score")]
    public int score;
    public int highScore;
    private bool beatHighScore;
    
    [Header("UI components")]
    public Text liveScore;
    public Text liveHighScore;

    [Header("Shake Variables")]
    public GameObject objectToShake;
    [Range(1f, 5f)]
    public float duration;
    [Range(1, 5f)]
    public int vibrationAmount;
    [Range(0f, 1f)]
    public float elasticity;
    
    [Header("Blocks")]
    public GameObject[] blocks;

    [Header("Spawn Points")]
    public GameObject[] spawnPoints;
    public float blockSpawnRate, blockSpawnRateDecreaseFactor;
     

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        liveHighScore.text = highScore.ToString();
        SpawnBlocks();
    }

    public void Score()
    {
        score++;
        liveScore.text = score.ToString();
        if (score > highScore)
        {
            highScore = score;
            liveHighScore.text = highScore.ToString();
            //objectToShake.transform.DOPunchScale(new Vector3(2f, 2f, 2f), duration, vibrationAmount, elasticity);
            PlayerPrefs.SetInt("HighScore", highScore);

        }
    }

    private void SpawnBlocks()
    {
        foreach (var item in spawnPoints)
        {
            item.GetComponent<SpawnPoints>().Spawn();
        }
        StartCoroutine(SpawnMoreBlocks(blockSpawnRate));
    }

    IEnumerator SpawnMoreBlocks(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SpawnBlocks();
        if (blockSpawnRate >= 0f)
        {
            blockSpawnRate -= blockSpawnRateDecreaseFactor;
        }        
    }

    
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
