using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIController : MonoBehaviour {

    public bool isGameOver = false;

    private MusicPlayer mus;

    public GameObject introPanel;
    public GameObject loseGamePanel;
    public GameObject winGamePanel;

    public GameObject bricks;

    private void Start()
    {
        mus = GameObject.FindObjectOfType<MusicPlayer>();

        MainMenu();
    }

    /**
     * Triggered when the MainMenu needs to open.
     */
    public void MainMenu()
    {
        introPanel.SetActive(true);
        loseGamePanel.SetActive(false);
        winGamePanel.SetActive(false);

        bricks.SetActive(false);
    }

    /**
     * Triggered when the game is successfully completed
     */
    public void WinGame()
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");

        foreach (GameObject b in balls)
        {
            b.SetActive(false);
        }

        winGamePanel.SetActive(true);
        isGameOver = true;
    }

    /**
     * Triggered when the game is lost.
     */
    public void LoseGame()
    {
        loseGamePanel.SetActive(true);
        isGameOver = true;

        bricks.SetActive(false);
    }

    /**
     * Triggered when the player clicks to start a game.
     */
    public void StartGame()
    {
        introPanel.SetActive(false);
        isGameOver = false;

        bricks.SetActive(true);
    }

    /**
     */
     public void ResetGame()
    {
        mus.KillMusic();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /**
     * Triggered when the player exits the whole game.
     */
    public void Exit()
    {
        Application.Quit();
    }
}
