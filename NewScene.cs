using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewScene : MonoBehaviour
{
   public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NewSceneWithPortal")){
            SceneManager.LoadScene("RootScene");  
        }

        if (other.gameObject.CompareTag("GameOver"))
        {
            SceneManager.LoadScene("GameOverScene");
        }
        if (other.gameObject.CompareTag("EndGame"))
        {
            Application.Quit();
        }

        if (other.gameObject.CompareTag("GoFairy"))
        {
            SceneManager.LoadScene("FairyScene");
        }
    }
}
