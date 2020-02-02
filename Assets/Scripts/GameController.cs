using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public static bool active;
    public static int gameTime = 1;
    public GameObject mainMenu;
    public GameObject timerMenu;
    public GameObject gameOverPanel;
    public GameObject timeOverPanel;
    public GameObject winPanel;

    public static float startTime;

    private void Awake()
    {
        active = false;
        instance = this;
    }

    public void StartGame()
    {
        active = true;
        mainMenu.SetActive(false);
        startTime = Time.time;
        timerMenu.SetActive(true);
        //SpawnController.instance.Spawn();
    }

    private void Update()
    {
        if (active && Time.time - startTime >= gameTime)
        {
            active = false;
            Debug.Log("Time!");
            TimeOver();
        }
    }

    public void TimeOver()
    {
        timerMenu.SetActive(false);
        timeOverPanel.SetActive(true);
        Invoke("Drive", 2f);
    }

    public void Drive()
    {
        Car.instance.Drive();
        timeOverPanel.SetActive(false);
        Invoke("GameOver", 8);
    }

    public void GameOver()
    {
        Car.instance.Brakes();
        CancelInvoke();
        Invoke("ShowGameOver", 3);
    }

    private void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void Win()
    {
        CancelInvoke();
        winPanel.SetActive(true);
    }

}
