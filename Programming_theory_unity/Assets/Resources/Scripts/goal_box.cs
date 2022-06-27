using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal_box : MonoBehaviour
{
    //increase points by this amount
    static int points = 10;

    //funnction checks the tag and increase the points based on the player type in case of two players in scene ast onc

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("fast_player"))
        {
            other.gameObject.GetComponent<fast_player>().increasePoints(points);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("strong_player"))
        {
            other.gameObject.GetComponent<strong_player>().increasePoints(points);
            Destroy(gameObject);
        }
       
    }

}
