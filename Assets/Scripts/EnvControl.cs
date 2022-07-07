using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvControl : MonoBehaviour
{
    Rigidbody2D _rigidBody;
    float _time;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _time += Time.deltaTime;
        float multiplier = 1f + (_time / 10f) / 2f;
        _rigidBody.velocity = Vector2.left * multiplier;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Destroyer")
        {
            Destroy(gameObject);
        }
    }
}
