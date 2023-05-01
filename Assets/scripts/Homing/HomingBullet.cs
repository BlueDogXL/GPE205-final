using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HomingBullet : MonoBehaviour
{
    public abstract void Start();
    public abstract void HomeTowards(GameObject target);
}
