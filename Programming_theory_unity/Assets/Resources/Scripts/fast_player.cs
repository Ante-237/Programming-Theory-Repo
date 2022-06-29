using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fast_player : player
{
    [SerializeField]
    private float fast_player_speed = 150.0f;
    [SerializeField]
    private float fast_player_health = 10.0f;
    [SerializeField]
    private static int fast_points = 0;

    public float fast_player_health_u
    {
        get { return fast_player_health; }
        set { fast_player_health = value; }
    }

    public float stronig_player_speed_v
    {
        get { return fast_player_speed; }
        set { fast_player_speed = value; }
    }

    public int fast_points_u
    {
        get { return fast_points; } 
        set { fast_points = value; }
    }




    private void FixedUpdate()
    {
        move();
    }

    public override void move()
    {
        moveAround(fast_player_health);
    }

    public override void increasePoints(int points)
    {
        fast_points += points;
    }

    public override void damage(int damage)
    {
        if(fast_player_health > 0)
        {
            fast_player_health -= damage;
            if(fast_player_health < 0)
            {
                fast_player_health = 0;
            }
        }
        else
        {
            fast_player_health = 0;
            Destroy(gameObject, 2.0f);
        }
    }



}
