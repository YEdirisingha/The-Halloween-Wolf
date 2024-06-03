using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text highScore;
    // Start is called before the first frame update
    void Start()
    {
        highScore.text = "Highscore : " + ((int)PlayerPrefs.GetFloat("Highscore")).ToString();
    }

  
    public void ToGame()
    {
        SceneManager.LoadScene("The Halloween Wolf");
    }

    
}
