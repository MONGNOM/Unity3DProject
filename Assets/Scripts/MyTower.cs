using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MyTower : MonoBehaviour
{
    [SerializeField]
    private int level;

    [SerializeField]
    private int mineral;

    public Enemy target;

    public int Mineral { get { return mineral; } private set { mineral = value; } }

        
    private void Update()
    {
        GameOver();
    }

    private void TakeHit()
    {
        WaveManager.Instance.TakeDamage(target.damage);
    }
    private void GameOver()
    {
        if (WaveManager.Instance.Heart <= 0)
        {
            Destroy(gameObject);
            Time.timeScale = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Å¸¿ö¿¡ ºÎµúÇû´Ù");
        if (collision.collider.tag == "Enemy")
        {
            Debug.Log("Å¸¿ö¿¡ ºÎµúÇû´Ù");
            TakeHit();
        }
    }


}
