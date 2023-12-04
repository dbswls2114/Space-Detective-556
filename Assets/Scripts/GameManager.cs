using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Enemy[] enemies; 

    public GameObject retryBtn;
    public GameObject player;
    public bool isGameOver;

    public TextMeshProUGUI scoreTxt;
    private int TotalScore; 

    public static GameManager I;
    void Awake()
    {
        I = this;
    }

    void Start()
    {
        isGameOver= false;
        Time.timeScale= 1.0f;
        TotalScore = 0;
        //GameOver();
        UpdateScore(0);

    }
    public void UpdateScore(int score){
        TotalScore += score;
        scoreTxt.text = TotalScore.ToString();
    }


    public void GameOver(){
        retryBtn.SetActive(true);
        Time.timeScale = 0.0f;
        isGameOver= true;
    }


}
