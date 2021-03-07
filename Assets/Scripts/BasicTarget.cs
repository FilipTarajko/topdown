using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicTarget : MonoBehaviour
{
    public GameController gameController;
    public float health;
    public bool isDamageable;
    public float speed;
    public float visionRange;
    public Transform enemyBulletParent;

    private void Update()
    {
        Frame();
        CheckForDeath();
        HandleRotation();
    }

    public abstract void Frame();

    private void HandleRotation()
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

    private void CheckForDeath()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        if (isDamageable)
        {
            health -= damage;
        }
    }
}
