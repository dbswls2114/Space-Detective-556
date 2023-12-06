using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System.Runtime.Serialization;

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

    public Animator anim;



    void Awake()
    {
        I = this;
        Alive = true;
        anim = player.gameObject.transform.GetChild(0).GetComponent<Animator>();
    }

    void Start()
    {        
        isGameOver= false;
        //TotalScore = 0;
        //테스트를 하기위해 주석 처리함
        //Eidit->Clear All PlayerPrefs 을 하면 저장된 값을 초기화 시켜줌
        Time.timeScale= 1.0f;
        UpdateScore(0); //점수 초기화 


        AudioManager.instance.PlayBgm(true);        


        playerhitbox = player.GetComponent<BoxCollider2D>();


    }
    
    void Update(){ 
        
    }
    public void UpdateScore(int score){ 
        TotalScore += score;
        scoreTxt.text = TotalScore.ToString();
    }

    public void GameOver()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Win);
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
    public void PlayerRespawn() 
    {
        Alive = false;
        
        Invoke("PlayerRespawnPlay", 2f);
    }

    void PlayerRespawnPlay() 
    {
        
        player.transform.position = Vector3.down * 3.5f;
        player.transform.GetChild(0).gameObject.SetActive(true);

        playerhitbox.enabled = false;
        StartCoroutine(PlayerRespawnaegis());
    }

    IEnumerator PlayerRespawnaegis()
    {
        yield return new WaitForSeconds(1.8f);
        Alive = true;
        yield return new WaitForSeconds(0.2f);
        playerhitbox.enabled = true;
        yield return null;
    }
}
