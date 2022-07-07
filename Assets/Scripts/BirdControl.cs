using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdControl : MonoBehaviour
{
    [SerializeField] GameObject fartEffect, expEffect, scoreReward, scoreStage;
    [SerializeField] AudioClip[] fartSounds;
    [SerializeField] AudioClip yeahSound, stageSound;

    Rigidbody2D _rg;
    GameControl _gControl;
    AudioSource _aSource;

    float _force = 4f;
    bool _GameActive = true;

    void Start()
    {
        _rg = GetComponent<Rigidbody2D>();
        _gControl = GameObject.Find("_Scripts").GetComponent<GameControl>();
        _aSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (_GameActive)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    MoveBird();
                }
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                MoveBird();
            }
        }
    }

    void MoveBird()
    {
        _rg.velocity = Vector3.up * _force;
        GameObject goFart = Instantiate(fartEffect, transform.position, transform.rotation) as GameObject;
        goFart.GetComponent<Rigidbody2D>().velocity = Vector2.left;
        _aSource.PlayOneShot(fartSounds[Random.Range(0, 3)], 1f);
        Destroy(goFart.gameObject, 1.333f);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            _GameActive = false;
            _gControl.EndGame();
        }
        else if (other.gameObject.tag == "Reward")
        {
            _aSource.PlayOneShot(yeahSound, 0.8f);
            _gControl.RewardScore();
            Vector3 posReward = other.contacts[0].point;
            GameObject goExp = Instantiate(expEffect, posReward, Quaternion.identity) as GameObject;
            GameObject goReward = Instantiate(scoreReward, posReward, Quaternion.identity) as GameObject;
            Destroy(goReward, 1f);
            Destroy(goExp, 0.5f);
            Destroy(other.gameObject);

        }
        else if (other.gameObject.tag == "Stage")
        {
            _aSource.PlayOneShot(stageSound, 1f);
            Vector3 posStage = other.contacts[0].point;
            GameObject goStage = Instantiate(scoreStage, posStage, Quaternion.identity) as GameObject;
            Destroy(goStage, 1f);
            _gControl.RaiseScore();
            Destroy(other.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other2d)
    {
        if (other2d.gameObject.tag == "Enemy")
        {
            _GameActive = false;
            _gControl.EndGame();
        }
    }
}
