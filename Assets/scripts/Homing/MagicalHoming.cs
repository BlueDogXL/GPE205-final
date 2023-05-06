using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicalHoming : HomingBullet
{
    public float homingDelay;
    public bool canIHoming;
    public float homingRateTimer;
    public float homingSpeed;
    public GameObject target;
    public Rigidbody rb;
    // Start is called before the first frame update
    public override void Start()
    {
        homingRateTimer = Time.time + homingDelay;
        TargetNearestEnemy();
    }

    public void Update()
    {
        if (Time.time >= homingRateTimer)
        {
            canIHoming = true;
        }
        if (canIHoming == true && target != null)
        {
            HomeTowards(target);
        }
    }
    protected void TargetNearestEnemy()
    {
        // Get a list of all the enemies (stuff with MagicalTarget)
        MagicalTarget[] allEnemies = FindObjectsOfType<MagicalTarget>();

        // Assume that the first enemy is closest
        if (allEnemies.Length > 0)
        {
            MagicalTarget closestEnemy = allEnemies[0];
            float closestEnemyDistance = Vector3.Distance(this.transform.position, closestEnemy.transform.position);

            // Iterate through them one at a time
            foreach (MagicalTarget enemy in allEnemies)
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
        else
        {
            Debug.Log("No targets!");
        }
    }

    // Update is called once per frame
    public override void HomeTowards(GameObject target)
    {
        // wait homingDelay seconds

        // taking this code from the unity docs
        var step = homingSpeed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
    }
}
