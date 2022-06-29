using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pillars : MonoBehaviour
{

    private bool decision = false;
    private Vector3 pos;
    [SerializeField]
    private float pillarSpeed = 100.0f;
    [SerializeField]
    public float pillarSpeed_O
    {
        get { return pillarSpeed; }
        set { pillarSpeed = value; }
    }

    [SerializeField]
    private float pillarWaitTime = 4.0f;
    public float pillarWaitTime_O
    {
        set { pillarWaitTime = value; }
        get { return pillarWaitTime; }
    }

  

    private void Start()
    {
        pos = GameObject.FindGameObjectWithTag("GameManager").GetComponent<game_manager>().generatePosition();
        InvokeRepeating("changeChoice",2,pillarWaitTime);
    }

    private void Update()
    {
        if (decision)
        {
            changePos();
        }
    }

    //moves player with certain speed
    public void changePos()
    {
        float s_up = pillarSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, pos, s_up);
    }


    //controls the pillar move choice
    private void changeChoice()
    {
        if (decision)
        {
            decision = false;
        }
        else
        {
            decision = true;
        }

        pos = GameObject.FindGameObjectWithTag("GameManager").GetComponent<game_manager>().generatePosition();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("fast_player"))
        {
            if(collision.gameObject.GetComponent<fast_player>().fast_player_health_u <= 1)
            {
                GameObject.FindGameObjectWithTag("SceneManager").GetComponent<sceneManager>().gameOver_Decide(true);
            }

            collision.gameObject.GetComponent<fast_player>().damage(5);
        }

        if (collision.gameObject.CompareTag("strong_player"))
        {
            if (collision.gameObject.GetComponent<strong_player>().strong_player_health_u <= 0)
            {
                GameObject.FindGameObjectWithTag("SceneManager").GetComponent<sceneManager>().gameOver_Decide(true);
            }

            collision.gameObject.GetComponent<strong_player>().damage(5);
        }


    }






}
