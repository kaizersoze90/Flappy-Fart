using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvControl : MonoBehaviour
{
    Rigidbody2D _rg;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        _rg = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        float multiplier = 1f + (time / 10f) / 2f;
        _rg.velocity = Vector2.left * multiplier;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Destroyer")
        {
            Destroy(gameObject);
        }
    }
}
