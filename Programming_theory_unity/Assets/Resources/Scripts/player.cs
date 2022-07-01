using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ABSTRACTION
public abstract class player : MonoBehaviour
{
    // ABSTRACTION
    public abstract void move();
    // ABSTRACTION
    public abstract void damage(int damage);

    public virtual void moveAround(float speed)
    {
        float Horizontal = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        float Vertical = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;
        transform.position += new Vector3(Horizontal, 0, Vertical);

    }
    // ABSTRACTION
    public abstract void increasePoints(int points);
  
}
