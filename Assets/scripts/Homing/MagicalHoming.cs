using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicalHoming : HomingBullet
{
    public float homingDelay;
    public float homingSpeed;
    public GameObject target;
    // Start is called before the first frame update
    public override void Start()
    {
        TargetNearestEnemy();
        HomeTowards(target);
    }
    protected void TargetNearestEnemy()
    {
        // Get a list of all the enemies (pawns)
        Pawn[] allEnemies = FindObjectsOfType<Pawn>();

        // Assume that the first enemy is closest
        Pawn closestEnemy = allEnemies[0];
        float closestEnemyDistance = Vector3.Distance(this.transform.position, closestEnemy.transform.position);

        // Iterate through them one at a time
        foreach (Pawn enemy in allEnemies)
        {
            // If this one is closer than the closest
            if (Vector3.Distance(this.transform.position, enemy.transform.position) <= closestEnemyDistance)
            {
                // It is the closest
                closestEnemy = enemy;
                closestEnemyDistance = Vector3.Distance(this.transform.position, closestEnemy.transform.position);
            }
        }

        // Target the closest enemy
        target = closestEnemy.gameObject;
    }

    // Update is called once per frame
    public override void HomeTowards(GameObject target)
    {
        // wait homingDelay seconds
        // launch towards enemy


        // or maybe do some repeating to make a more fluid arc idk like
        // wait homingDelay seconds
        // for (number of homing times)
        // {
        //      rotate towards target
        //      launch with less force
        // }
    }
}
