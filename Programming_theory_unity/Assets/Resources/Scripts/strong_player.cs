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
        throw new System.NotImplementedException();
    }


}
