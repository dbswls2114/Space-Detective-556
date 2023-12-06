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

    public BoxCollider2D playerhitbox;
    public GameObject[] LifeImage;
    private int i = 0;

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
        playerhitbox = player.GetComponent<BoxCollider2D>();
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

    public void UpdateLifeIcon()
    {
        
        if (i < LifeImage.Length)
        {
            LifeImage[i].SetActive(false);
            i++;
            Debug.Log(i);
        }
    }
    public void PlayerRespawn() //리스폰 시간 딜레이
    {
        Invoke("PlayerRespawnPlay", 2f);
    }

    void PlayerRespawnPlay() //리스폰 무적시간
    {
        player.transform.position = Vector3.down * 3.5f;
        player.SetActive(true);
        playerhitbox.enabled = false;
        Invoke("PlayerRespawnaegis",2f);
        // 리스폰 될 때 애니메이션
    }
    void PlayerRespawnaegis() //리스폰
    {
        playerhitbox.enabled = true;
    }
}
