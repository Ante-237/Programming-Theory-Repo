using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class strong_player : player
{
    [SerializeField]
    private float strong_player_speed = 100.0f;
    [SerializeField]
    private float strong_player_health = 20.0f;
    [SerializeField]
    private static int strong_points = 0;


    public float strong_player_health_u
    {
        get { return strong_player_health; }   
        set { strong_player_health = value; }
    }

    public float stronig_player_speed_v
    {
        get { return strong_player_speed; }
        set { strong_player_speed = value; }
    }

    public int strong_points_u
    {
        get { return strong_points; }
        set { strong_points = value; }
    }


    private void FixedUpdate()
    {
        move();
    }

    public override void move()
    {
        moveAround(strong_player_speed);
    }

    public override void increasePoints(int points)
    {
        strong_points += points;
    }


    public override void damage(int damage)
    {
        if (strong_player_health > 0)
        {
            strong_player_health -= damage;
            if (strong_player_health < 0)
            {
                strong_player_health = 0;
            }
        }
        else
        {
            strong_player_health = 0;
            Destroy(gameObject, 2.0f);
        }
    }
}
