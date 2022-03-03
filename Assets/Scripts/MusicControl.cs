using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    static bool musicOn;
    // Start is called before the first frame update
    void Start()
    {
        if (!musicOn)
        {
            GameObject.DontDestroyOnLoad(gameObject);
            musicOn = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
