using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireballShot : MonoBehaviour
{
    public Enemy target;
    public TeamMonster monster;
    public float shotSpeed;
    public float deleteTime;
    public int damage;

    private void Start()
    {
        damage = monster.damage;
    }
    public FireballShot(Enemy target)
    {
        this.target = target;
    }
    
    void Update()
    {
        transform.Translate(Vector3.forward * shotSpeed, Space.Self);
    }

    private void OnBecameInvisible()
    { 
           Destroy(gameObject);
    }
    
    


}
