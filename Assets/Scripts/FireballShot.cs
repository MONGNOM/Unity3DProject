using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireballShot : MonoBehaviour
{
    public Enemy target;
    public RangedAttackMonster rangedAttack;
    public float shotSpeed;
    public float deleteTime;
    public int damage;

   
    private void Start()
    {
        damage = rangedAttack.damage;    
    }
    public FireballShot(Enemy target)
    {
        this.target = target;
    }
    
    void Update()
    {
        transform.Translate(Vector3.forward * shotSpeed * Time.deltaTime, Space.Self);
    }

    private void OnBecameInvisible()
    { 
           Destroy(gameObject);
    }
    
    


}
