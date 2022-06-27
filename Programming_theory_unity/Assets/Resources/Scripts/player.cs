using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class player : MonoBehaviour
{
    public abstract void move();
    public abstract void damage(int damage);

    public virtual void moveAround(float speed)
    {
        float Horizontal = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        float Vertical = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;
        transform.position += new Vector3(Horizontal, 0, Vertical);

    }

    public abstract void increasePoints(int points);
  
}
