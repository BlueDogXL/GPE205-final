using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHoming : HomingBullet
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
        TargetPlayerOne();
        // get player as target
    }
    public void Update()
    {
        if (Time.time >= homingRateTimer)
        {
            canIHoming = true;
        }
        if (target != null)
        {
            if (canIHoming == true)
            {
                HomeTowards(target);
            }
        }
    }
    public void TargetPlayerOne()
    {
        // If the GameManager exists
        if (GameManager.instance != null)
        {
            // And the array of players exists
            if (GameManager.instance.players != null)
            {
                // And there are players in it
                if (GameManager.instance.players.Count > 0 && GameManager.instance.players[0].pawn != null)
                {
                    //Then target the gameObject of the pawn of the first player controller in the list
                    target = GameManager.instance.players[0].pawn.gameObject;
                }
            }
        }
    }
    // Update is called once per frame
    public override void HomeTowards(GameObject target)
    {
        Debug.Log("Homing towards player!");
        // taking this code from the unity docs
        var step = homingSpeed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
    }
}
