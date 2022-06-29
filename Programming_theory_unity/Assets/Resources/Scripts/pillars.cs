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
        Debug.Log("new position" + pos.x);
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




  
    
}
