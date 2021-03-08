using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Data data;
    public Player player;
    public Transform enemyParent;
    public Transform enemyBulletParent;
    public TrainingTarget trainingTarget;
    public PurpleCube purpleCube;
    public ChasingBall chasingBall;

    private void Start()
    {
        for (int i = 50; i<700; i+=200)
        {
            TrainingTarget spawned = Instantiate(trainingTarget, new Vector3(700, -350+i, 0), Quaternion.identity, enemyParent);
            spawned.gameController = this;
            spawned.enemyBulletParent = enemyBulletParent;
        }
        for (int i = 0; i<3; i++)
        {
            PurpleCube spawned = Instantiate(purpleCube, new Vector3(i * 300, 1000, 0), Quaternion.identity, enemyParent);
            spawned.gameController = this;
            spawned.enemyBulletParent = enemyBulletParent;
        }
        for (int i = 0; i < 3; i++)
        {
            ChasingBall spawned = Instantiate(chasingBall, new Vector3(i * 300, 2000, 0), Quaternion.identity, enemyParent);
            spawned.gameController = this;
            spawned.enemyBulletParent = enemyBulletParent;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("r") || player.health<=0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
