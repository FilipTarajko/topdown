using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 movementDirection;
    public float movementSpeed;
    public float timeToAttack;
    public float attackCooldown;
    public Transform _Dynamic;
    public PlayerBullet playerBullet;
    public float bulletSpeed;
    public Vector3 targetDirection;
    public float weaponRange;

    void Update()
    {
        HandleMoving();
        HandleCamera();
        HandleShooting();
    }

    void HandleMoving()
    {
        movementDirection = new Vector2((Input.GetKey("d") ? 1 : 0) - (Input.GetKey("a") ? 1 : 0), (Input.GetKey("w") ? 1 : 0) - (Input.GetKey("s") ? 1 : 0));
        movementDirection.Normalize();
        transform.Translate(movementDirection * movementSpeed * Time.deltaTime);
    }

    void HandleCamera()
    {
        if (Input.GetKey(KeyCode.Equals) && Camera.main.orthographicSize >= 250)
        {
            Camera.main.orthographicSize -= 10;
        }
        if (Input.GetKey(KeyCode.Minus) && Camera.main.orthographicSize <=5000)
        {
            Camera.main.orthographicSize += 10;
        }
    }

    void HandleShooting()
    {
        timeToAttack -= Time.deltaTime;
        if (timeToAttack <= 0 && Input.GetMouseButton(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Vector3 targetDirection = Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2, 0);
        targetDirection.Normalize();
        timeToAttack = attackCooldown;
        PlayerBullet bullet = Instantiate(playerBullet, transform.position, Quaternion.identity, _Dynamic);
        bullet.speed = bulletSpeed;
        bullet.transform.up = targetDirection;
        bullet.range = weaponRange;
    }
}
