using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameControl : MonoBehaviour
{
    [SerializeField] Text lastScoreText;
    [SerializeField] AudioClip endSound;

    void Start()
    {
        GetComponent<AudioSource>().PlayOneShot(endSound, 1f);
        lastScoreText.text = "SCORE: " + PlayerPrefs.GetInt("lastScore");
    }
}
