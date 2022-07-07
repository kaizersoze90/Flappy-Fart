using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] int score;

    public void StartGame()
    {
        SceneManager.LoadScene("Game Scene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void EndGame()
    {
        PlayerPrefs.SetInt("lastScore", score);
        SceneManager.LoadScene("End Scene");
    }
    public void RaiseScore()
    {
        score += 10;
        scoreText.text = score + "";
    }
    public void RewardScore()
    {
        score += 50;
        scoreText.text = score + "";
    }
}
