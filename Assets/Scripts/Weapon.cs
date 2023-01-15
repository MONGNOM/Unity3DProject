using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public new Collider collider;

    public float damage;

    public float Damage
    { get { return damage; } private set { damage = value; } }

    private void Awake()
    {
        collider = GetComponent<Collider>();
    }
}
