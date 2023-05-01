using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicalShooter : Shooter
{
    public Transform shootPoint;
    // Start is called before the first frame update
    public override void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        
    }

    public override void Shoot(GameObject shellPrefab, float shootForce, float damageDone, float lifespan)
    {
        GameObject newShell = Instantiate(shellPrefab, shootPoint.position, shootPoint.rotation);
        // get damage on hit script
        DamageOnHit doh = newShell.GetComponent<DamageOnHit>();

        if (doh != null) // this stuff is delivered to the health component
        {
            doh.damageDone = damageDone;
            doh.owner = GetComponent<Pawn>();
        }

        Rigidbody rb = newShell.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.AddForce(shootPoint.forward * shootForce); // launch that rigidbody with the might of shootForce
        }

        Destroy(newShell, lifespan); // and, if we miss, destroy it so it doesn't clog up unity. there's a smarter way to say that but i forgor :skull:
    }
}
