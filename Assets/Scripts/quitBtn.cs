using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class quitBtn : MonoBehaviour
{

    public void QuitGame(){
        SceneManager.LoadScene("StartScene"); 
    }
}
