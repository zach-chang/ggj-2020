using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    private AudioSource asource;

    public static bool active;
    public static int gameTime = 60;
    public GameObject mainMenu;
    public GameObject timerMenu;
    public GameObject countdownPanel;
    public GameObject gameOverPanel;
    public GameObject timeOverPanel;
    public GameObject winPanel;
    public GameObject fadeyPanel;

    public static float startTime;

    public AudioClip ac_321;
    public AudioClip ac_time;
    public AudioClip ac_gameover;
    public AudioClip ac_youwin;

    private void Awake()
    {
        active = false;
        instance = this;
        asource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        MusicPlayer.Title();
    }

    public void StartGame()
    {
        active = true;
        startTime = Time.time;
        Invoke("ShowTimer", 1f);
        SpawnController.instance.Spawn();
        MusicPlayer.Gameplay();
    }
    public void ShowTimer()
    {
        timerMenu.SetActive(true);
    }

    public void StartButton()
    {
        countdownPanel.SetActive(true);
        mainMenu.SetActive(false);
        Invoke("StartGame", 3f);
        Play(ac_321);
        MusicPlayer.Stop();
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
        Play(ac_time);
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
        Play(ac_gameover);
    }

    public void Win()
    {
        CancelInvoke();
        winPanel.SetActive(true);
        Play(ac_youwin);
    }

    public void Reset()
    {
        fadeyPanel.SetActive(true);
    }

    public static void Play(AudioClip clip)
    {
        instance.asource.clip = clip;
        instance.asource.Play();
    }

}
