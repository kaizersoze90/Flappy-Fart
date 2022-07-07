using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] GameObject bird;

    void Start()
    {
        bird = bird.transform.gameObject;
    }

    void Update()
    {
        transform.position = new Vector3(bird.transform.position.x + 1.5f,
                                        transform.position.y,
                                        transform.position.z);
    }
}
