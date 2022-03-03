using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public Text _scoreText;
    public int _score;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartGame()
    {
        SceneManager.LoadScene("Game Scene");
    }
    public void EndGame()
    {
        PlayerPrefs.SetInt("lastScore", _score);
        SceneManager.LoadScene("End Scene");
    }
    public void RaiseScore()
    {
        _score += 10;
        _scoreText.text = _score + "";
    }
    public void RewardScore()
    {
        _score += 50;
        _scoreText.text = _score + "";
    }
}
