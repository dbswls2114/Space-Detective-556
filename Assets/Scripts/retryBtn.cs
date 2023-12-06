using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class retryBtn : MonoBehaviour
{

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Start is called before the first frame update
    public void ReGame(){
        SceneManager.LoadScene("MainScene");
    }
}
