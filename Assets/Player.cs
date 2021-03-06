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

    void Update()
    {
        movementDirection = new Vector2((Input.GetKey("d")?1:0) - (Input.GetKey("a")?1:0), (Input.GetKey("w")?1:0) - (Input.GetKey("s")?1:0));
        movementDirection.Normalize();
        transform.Translate(movementDirection * movementSpeed * Time.deltaTime);
        timeToAttack -= Time.deltaTime;
        if (timeToAttack <= 0 && Input.GetMouseButton(0))
        {
            Shoot();
        }
    }
    
    void Shoot()
    {
        Vector3 targetDirection = Input.mousePosition - new Vector3(Screen.width/2, Screen.height/2, 0);
        targetDirection.Normalize();
        timeToAttack = attackCooldown;
        PlayerBullet bullet = Instantiate(playerBullet, transform.position, Quaternion.identity, _Dynamic);
        bullet.speed = bulletSpeed;
        bullet.transform.up = targetDirection;
    }
}
