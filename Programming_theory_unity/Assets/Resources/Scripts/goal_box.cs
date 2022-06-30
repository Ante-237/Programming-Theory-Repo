using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal_box : MonoBehaviour
{
    //increase points by this amount

    //funnction checks the tag and increase the points based on the player type in case of two players in scene ast onc

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("fast_player"))
        {
            makeVisible();
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("strong_player"))
        {
            makeVisible();
            Destroy(gameObject);
        }
       
    }

    //get game manager and change box_show bool
    private void makeVisible()
    {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<game_manager>().isBoxCollect_O = true;
    }

}
