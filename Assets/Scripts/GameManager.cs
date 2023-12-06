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
    public bool Alive=true;

    void Awake()
    {
        I = this;
        Alive = true;
    }

    void Start()
    {
        isGameOver= false;
        TotalScore = 0;
        Time.timeScale= 1.0f;
        UpdateScore(0); //점수 초기화 
        playerhitbox = player.GetComponent<BoxCollider2D>();
    }
    
    void Update(){ 
        
    }
    public void UpdateScore(int score){ //적을 잡을때마다 호출 
        TotalScore += score;
        scoreTxt.text = TotalScore.ToString();
    }

    public void GameOver(){ // player의 hp가 0이 되었을때 (3번 맞았을때) 호출 
        retryBtn.SetActive(true);
        Time.timeScale = 0.0f;
        isGameOver= true;

        if(PlayerPrefs.HasKey("bestscore") == false){
            PlayerPrefs.SetInt("bestscore", TotalScore);
        }else{
            if (TotalScore > PlayerPrefs.GetFloat("bestscore")){
                PlayerPrefs.SetInt("bestscore",TotalScore);
            }
        }


        float maxScore= PlayerPrefs.GetInt("bestscore");
        maxScoreTxt.text = maxScore.ToString();
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
        Alive = false;
        Invoke("PlayerRespawnPlay", 2f);
    }

    void PlayerRespawnPlay() //리스폰 무적시간
    {
        player.transform.position = Vector3.down * 3.5f;
        player.transform.GetChild(0).gameObject.SetActive(true);
        playerhitbox.enabled = false;
        StartCoroutine(PlayerRespawnaegis());
        //Invoke("PlayerRespawnaegis",1.8f);
        // 리스폰 될 때 애니메이션
    }
    //void PlayerRespawnaegis() //리스폰
    //{
    //    Alive = true;
    //    Invoke("",0.3f);
    //    playerhitbox.enabled = true;
    //}
    IEnumerator PlayerRespawnaegis()
    {
        yield return new WaitForSeconds(1.8f);
        Alive = true;
        yield return new WaitForSeconds(0.2f);
        playerhitbox.enabled = true;
        yield return null;
    }
}
