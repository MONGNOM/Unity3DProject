using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public new Collider collider;

    public int damage;

    private void Awake()
    {
        collider = GetComponent<Collider>();
    }
}
