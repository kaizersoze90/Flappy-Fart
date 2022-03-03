using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameControl : MonoBehaviour
{
    public Text _lastScoreText;
    public AudioClip _endSound;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().PlayOneShot(_endSound, 1f);
        _lastScoreText.text = "Score: " + PlayerPrefs.GetInt("lastScore");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
