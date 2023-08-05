using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 cameraPos;
    private Transform player, win;

    private float cameraOffSet = 4f;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>().transform;
    }

    void Start()
    {
    }

    void Update()
    {
        if(win == null)
        {
            win = GameObject.Find("win(Clone)").GetComponent<Transform>();
        }

        if(transform.position.y > player.position.y && transform.position.y > win.position.y + cameraOffSet)
        {
            cameraPos = new Vector3(transform.position.x, player.position.y, transform.position.z);
            transform.position = new Vector3(transform.position.x, cameraPos.y, -5);
        }

    }
}
