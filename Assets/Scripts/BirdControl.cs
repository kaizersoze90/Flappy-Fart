using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdControl : MonoBehaviour
{
    Rigidbody2D _rg;
    GameControl _gControl;
    AudioSource _aSource;

    private float _force = 4f;
    private bool _GameActive = true;

    public GameObject _fartEffect, _expEffect, _scoreReward, _scoreStage;
    public AudioClip[] _fartSounds;
    public AudioClip _yeahSound, _stageSound;

    // Start is called before the first frame update
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
                    _rg.velocity = Vector3.up * _force;
                    GameObject goFart = Instantiate(_fartEffect, transform.position, transform.rotation) as GameObject;
                    goFart.GetComponent<Rigidbody2D>().velocity = Vector2.left;
                    _aSource.PlayOneShot(_fartSounds[Random.Range(0, 3)], 1f);
                    Destroy(goFart.gameObject, 1.333f);
                }
            }
        }
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
            _aSource.PlayOneShot(_yeahSound, 0.8f);
            _gControl.RewardScore();
            Vector3 posReward = other.contacts[0].point;
            GameObject goExp = Instantiate(_expEffect, posReward, Quaternion.identity) as GameObject;
            GameObject goReward = Instantiate(_scoreReward, posReward, Quaternion.identity) as GameObject;
            Destroy(goReward, 1f);
            Destroy(goExp, 0.5f);
            Destroy(other.gameObject);

        }
        else if (other.gameObject.tag == "Stage")
        {
            _aSource.PlayOneShot(_stageSound, 1f);
            Vector3 posStage = other.contacts[0].point;
            GameObject goStage = Instantiate(_scoreStage, posStage, Quaternion.identity) as GameObject;
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
