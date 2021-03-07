using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    public float range;
    public Vector2 startPosition;
    public float damage;

    private void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        if (Vector2.Distance(startPosition, transform.position) > range)
        {
            Destroy(gameObject);
        }
    }
}
