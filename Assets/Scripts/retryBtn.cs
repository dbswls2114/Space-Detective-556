using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class retryBtn : MonoBehaviour
{

    public void ReGame(){
        SceneManager.LoadScene("MainScene");
    }
}
