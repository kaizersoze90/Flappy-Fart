using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject bird;

    // Start is called before the first frame update
    void Start()
    {
        bird = bird.transform.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(bird.transform.position.x + 1.5f, transform.position.y, transform.position.z);
    }
}
