using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Score")]
    public int score;

    [Header("UI components")]
    public Text liveScore;

    [Header("Blocks")]
    public GameObject[] blocks;


    private void Awake()
    {
        instance = this;
    }

    public void Score()
    {
        score++;
        liveScore.text = score.ToString();
        
    }
}
