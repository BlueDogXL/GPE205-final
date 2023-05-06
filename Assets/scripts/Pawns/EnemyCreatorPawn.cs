using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreatorPawn : Pawn
{
    public MagicalShooter shooter;
    public GameObject enemyPrefab;
    public float shootForce;
    public float damageDone;
    public float spellLifespan;
    public float fireRate;
    public bool canIShoot;
    private float fireRateTimer;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        shooter = GetComponent<MagicalShooter>();
        canIShoot = true;
    }
    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (Time.time >= fireRateTimer)
        {
            canIShoot = true;
        }
        if (GameManager.instance.GameOverScreenStateObject.activeInHierarchy == true) 
        {
            Destroy(this.gameObject);
        }
    }

    public override void TurnLeft()
    {
        Debug.Log("what the heck is calling the move functions on the enemy spawner");
    }
    public override void TurnRight()
    {
        Debug.Log("what the heck is calling the move functions on the enemy spawner");
    }
    public override void MoveBackward()
    {
        Debug.Log("what the heck is calling the move functions on the enemy spawner");
    }
    public override void MoveForward()
    {
        Debug.Log("what the heck is calling the move functions on the enemy spawner");
    }
    public override void RotateTowards(Vector3 targetPosition)
    {
        Debug.Log("what the heck is calling the move functions on the enemy spawner");
    }
    public override void Shoot()
    {
        if (canIShoot == true)
        {
            shooter.Shoot(enemyPrefab, shootForce, damageDone, spellLifespan);
            Debug.Log("successful [insert attack name here]!");
            canIShoot = false;
            fireRateTimer = Time.time + fireRate;
        }
        else
        {
            Debug.Log("You can't enemy that fast!");
        }
    }
    
}
