using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 movementDirection;
    public float movementSpeed;

    void Update()
    {
        movementDirection = new Vector2((Input.GetKey("d")?1:0) - (Input.GetKey("a")?1:0), (Input.GetKey("w")?1:0) - (Input.GetKey("s")?1:0));
        movementDirection.Normalize();
        transform.Translate(movementDirection * movementSpeed * Time.deltaTime);
    }
}
