using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float cooldown;
    [SerializeField] private GameObject enemyPrefab;
    private void Start()
    {
        cooldown = Time.time;
    }
    void Update()
    {
        if (cooldown < Time.time)
        {
            cooldown = Time.time + 1;
            int rail = Random.Range(0, 3);
            switch (rail)
            {
                case 0:
                    Spawn(new Vector3(90, 0, 20));
                    break;
                case 1:
                    Spawn(new Vector3(-90, 0, 0));
                    break;
                case 2:
                    Spawn(new Vector3(90, 0, -20));
                    break;
                default: Debug.Log(rail);
                    break;
            }
        }

    }
    private void Spawn(Vector3 aSpawnPoint)
    {
        GameObject myEnemy = Instantiate(enemyPrefab, aSpawnPoint, Quaternion.identity);
        //myEnemy.GetComponent<GameObject>().tag = "enemy";
        if (aSpawnPoint.x > 0)
        {
            myEnemy.transform.eulerAngles = new Vector3(0, 90, 0);
        }
        if (aSpawnPoint.x < 0)
        {
            myEnemy.transform.eulerAngles = new Vector3(0, -90, 0);
        }
    }
}
