using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveManager : SingleTon<WaveManager>
{

    [Header("Header")]
    [SerializeField]
    private int heart;

    [SerializeField]
    private int level;
    public UnityAction<int> OnChangeLevel;

    public UnityAction<int> OnChangeHeart;

    [Header("Enemy")]
    [SerializeField]
    private Enemy enemyprefab;
    [SerializeField]
    private float spawnDelay;
    private Coroutine spawnRoutine;

    [SerializeField]
    private EnemySpawnPoint spawnPoint;

    [SerializeField]
    private MyTower myTower;

    public int Heart
    {
        get { return heart; }
        private set { heart = value; OnChangeHeart?.Invoke(heart); }
    }

    public int Level
    {
        get { return level; }
        private set { level = value; OnChangeLevel?.Invoke(level); }
    }

    private void Start()
    {
        spawnRoutine = StartCoroutine(SpawnRoutine());
    }

    private void Update()
    {
        spawnPoint = GameObject.Find("enemySpawnPoint").GetComponent<EnemySpawnPoint>();
        myTower = GameObject.Find("MyTower").GetComponent<MyTower>();
    }
    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);
            Instantiate(enemyprefab, spawnPoint.transform.position, Quaternion.Euler(0, 0, 0));
        }

    }

    public void LevelUp(int level)
    {
        Level += level;
        
    }
    public void TakeDamage(int damage)
    {
        Heart -= damage;
        // TODO : gameManager.instance.gameover();
    }
}
