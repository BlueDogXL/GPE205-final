using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicalMover : Mover
{
    private Rigidbody rb;
    // Start is called before the first frame update
    public override void Start()
    {
        rb = GetComponent<Rigidbody>(); // get the rigidbody we're attached to. not that we need it. hmmm
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Move(Vector3 direction, float speed)
    {
        // do not
    }
    public override void Rotate(float speed)
    {
        transform.Rotate(0, speed * Time.deltaTime, 0); // rotate that transform
    }
}
