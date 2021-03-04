using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{

    [SerializeField] GameObject endGameText;


    void Update()
    {
        if (Timer.sharedInstance.timer <= 0) 
        {
            GameOver();
        }
    }

    public void GameOver() 
    {
        Time.timeScale = 0;
        endGameText.GetComponent<Text>().text = $"Игра окончена \n 'ESC' - выход \n 'R' - заново";
        endGameText.GetComponent<Text>().color = new Color(146, 146, 146);

        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadGame();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame();
        }
    }

    private static void ReloadGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1;
    }

    private static void ExitGame()
    {
        Application.Quit();
    }
}
