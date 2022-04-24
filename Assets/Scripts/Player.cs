using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float movespeed=2f;
    public float rotateAmount=5f;
    float rot;
    public int score=0;
    public GameObject winText;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetMouseButton(0))
        // {
        //     Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //     if (mousepos.x < 0)
        //     {
        //         rot = rotateAmount;
        //     }
        //     else
        //     {
        //         rot = -rotateAmount;
        //     }

        //     transform.Rotate(0,0,rot);
        // }
        // rb.velocity = transform.up * movespeed ;
        
    }
    private void FixedUpdate() 
    {
                if (Input.GetMouseButton(0))
        {
            Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (mousepos.x < 0)
            {
                rot = rotateAmount;
            }
            else
            {
                rot = -rotateAmount;
            }

            transform.Rotate(0,0,rot);
        }
        rb.velocity = transform.up * movespeed ;
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Food")
        {
            Destroy(collision.gameObject);
            score++;
            if (score>=5)
            {
                print("Level Complete");
                winText.SetActive(true);
                Time.timeScale=0;
            }
        }
        else if (collision.gameObject.tag == "Danger")
        {
            SceneManager.LoadScene("Game");
        }
        
    }
}
