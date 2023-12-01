using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class retryBtn : MonoBehaviour
{
    // Start is called before the first frame update
    public void ReGame(){
        SceneManager.LoadScene("BackgroundScene");
    }
}
