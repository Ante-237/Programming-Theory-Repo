using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pillars : MonoBehaviour
{
    public GameObject[] randomPos;
    int randomPosition;

    private void Start()
    {
        changePos();
        randomPos = GameObject.FindGameObjectsWithTag("move_one");
    }

    private void Update()
    {
        float s_up = 30 * Time.deltaTime; 
        transform.position = Vector3.MoveTowards(transform.position, randomPos[randomPosition].transform.position, s_up);
    }

    public void changePos()
    {
        randomPosition = Random.Range(0, randomPos.Length);
    }




  
    
}
