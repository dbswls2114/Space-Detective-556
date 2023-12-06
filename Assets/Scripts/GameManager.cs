using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject retryBtn;
    public GameObject player;
    public bool isGameOver;

    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI maxScoreTxt;
    private int TotalScore; 
    private GameObject[] NumberOfEnemies;
    public static GameManager I;
    public GameObject PowerUpItem;
    
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
        UpdateScore(0); //점수 초기화 

    }
    
    void Update(){ 
        NumberOfEnemies = GameObject.FindGameObjectsWithTag("Enemy"); 
        if(NumberOfEnemies.Length == 0){ //enemies가 0일때 
            //다음 레벨로?? 아님 클리어??             
        }
    }
    public void UpdateScore(int score){ //적을 잡을때마다 호출 
        TotalScore += score;
        scoreTxt.text = TotalScore.ToString();

        //해당 객체를 뺴고
    }

    public void GameOver(){ // player의 hp가 0이 되었을때 (3번 맞았을때) 호출 
        retryBtn.SetActive(true);
        Time.timeScale = 0.0f;
        isGameOver= true;
    }

    public void SpawnItem(Vector3 enemyPos)
    {
        Instantiate(PowerUpItem, enemyPos, Quaternion.identity);
    }

}
