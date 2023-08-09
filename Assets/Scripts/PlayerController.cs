using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody rb;

    bool carpa;

    float currentTime;

    bool invincible;

    public GameObject fireShield;

    void Start()
    {
       rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            carpa = true;
        }
        if(Input.GetMouseButtonUp(0))
        {
            carpa = false;
        }

        if(invincible)
        {
            currentTime = Time.deltaTime * 0.35f;
            if (!fireShield.activeInHierarchy)
            {
                fireShield.SetActive(true);
            }
        }
        else
        {
            if(fireShield.activeInHierarchy)
            {
                fireShield.SetActive(false);
            }
            if (carpa)
            {
                currentTime += Time.deltaTime * 0.8f;
            }
            else
            {
                currentTime -= Time.deltaTime * 0.5f;
            }

        }

        if(currentTime >= 1)
        {
            currentTime = 1;
            invincible = true;
            Debug.Log("invincible");
        }
        else if(currentTime <= 0)
        {
            currentTime = 0;
            invincible = false;
            Debug.Log("normal");
        }
        
    }

    private void FixedUpdate()
    {
        if(carpa)
        {
            rb.velocity = new Vector3(0,-100 * Time.fixedDeltaTime * 7 , 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!carpa)
        {
            rb.velocity = new Vector3(0, 50 * Time.deltaTime * 5, 0);
        }
        else
        {
            if (invincible)
            {
                if (collision.gameObject.tag == "enemy" || collision.gameObject.tag == "plane")
                {
                    Destroy(collision.transform.parent.gameObject);
                }
            }
            else
            {
                if (collision.gameObject.tag == "enemy")
                {
                    Destroy(collision.transform.parent.gameObject);
                }
                else if (collision.gameObject.tag == "plane")
                {
                    Debug.Log("Game Over");
                }
            }
            
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (!carpa)
        {
            rb.velocity = new Vector3(0, 50 * Time.deltaTime * 5, 0);
        }
    }
}
