using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateManager : MonoBehaviour
{

    public float speed = 100f;
    void Start()
    {
        
    }


    void Update()
    {
        transform.Rotate(new Vector3(0, speed * Time.deltaTime));
    }
}
