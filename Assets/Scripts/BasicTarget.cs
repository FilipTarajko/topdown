using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTarget : MonoBehaviour
{
    public GameController gameController;
    public float health;

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        HandleRotation();
    }

    void HandleRotation()
    {
        if (Input.GetKey("q"))
        {
            transform.Rotate(new Vector3(0, 0, gameController.player.rotationSpeed));
        }
        if (Input.GetKey("e"))
        {
            transform.Rotate(new Vector3(0, 0, -gameController.player.rotationSpeed));
        }
        if (Input.GetKey("z"))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
    }

    public void DealDamage(float damage)
    {
        health -= damage;
    }
}
