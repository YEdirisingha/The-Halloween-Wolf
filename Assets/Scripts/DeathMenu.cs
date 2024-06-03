using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public Text lastScore;

    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    public void ToggleEndMenu(float lastscore)
    {
        gameObject.SetActive(true);

        lastScore.text = ((int)lastscore).ToString();
        

    }

    public void Restart()
    {      
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
