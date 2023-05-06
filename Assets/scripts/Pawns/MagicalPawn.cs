using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MagicalPawn : Pawn
{
    public Shooter shooter;
    public Mover mover;
    public Health health;
    public GameObject spellPrefab;
    public AudioSource soundSource;
    public AudioClip spellSound;
    // public NoiseMaker noiseMaker; // not sure if i need this either but we'll keep it in mind
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
        shooter = GetComponent<Shooter>();
        mover = GetComponent<Mover>(); // get our shooter and mover n stuff
        health = GetComponent<Health>();
        // noiseMaker = GetComponent<NoiseMaker>();
        canIShoot = true;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        GameManager.instance.SetPlayerOneLife(health.currentHealth / health.maxHealth);
        if (Time.time >= fireRateTimer)
        {
            canIShoot = true;
        }
    }

    
    public override void TurnLeft()
    {
        mover.Rotate(-turnSpeed);
        Debug.Log("Left!");
    }

    public override void TurnRight()
    {
        mover.Rotate(turnSpeed);
        Debug.Log("Right!");
    }

    public override void Shoot()
    {
        if (canIShoot == true)
        {
            soundSource.PlayOneShot(spellSound);
            shooter.Shoot(spellPrefab, shootForce, damageDone, spellLifespan);
            Debug.Log("successful [insert attack name here]!");
            canIShoot = false;
            fireRateTimer = Time.time + fireRate;
            //if (noiseMaker != null)
            //{
            //    noiseMaker.volumeDistance = 15;
            //}
        }
        else
        {
            Debug.Log("You can't magical girl that fast!");
        }
    }
    public override void MoveForward()
    {
        // don't
        Debug.Log("Don't even try it.");
    }
    public override void MoveBackward() 
    {
        // also don't
        Debug.Log("Don't even try it.");
    }
    public override void RotateTowards(Vector3 targetPosition)
    {
        // no AIs are gonna use this pawn i think so don't bother
    }
}
