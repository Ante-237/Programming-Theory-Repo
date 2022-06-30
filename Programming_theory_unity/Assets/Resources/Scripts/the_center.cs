using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class the_center : MonoBehaviour
{
    private static int points = 10;



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("fast_player"))
        {
            if (get_ValueBoxDecide())
            {
                set_ValueboxDecide(false);
                collision.gameObject.GetComponent<fast_player>().increasePoints(points);
            }
        }

        if (collision.gameObject.CompareTag("strong_player"))
        {
            if (get_ValueBoxDecide())
            {
                set_ValueboxDecide(false);
                collision.gameObject.GetComponent<strong_player>().increasePoints(points);
            }
        }

    }



    private bool get_ValueBoxDecide() {
        return GameObject.FindGameObjectWithTag("GameManager").GetComponent<game_manager>().isBoxCollect_O;
    }

    private void set_ValueboxDecide(bool value)
    {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<game_manager>().isBoxCollect_O = value;
    }
}
