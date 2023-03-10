using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStateUI : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI levelValue;

    [SerializeField]
    private TextMeshProUGUI MineralValue;

    [SerializeField]
    private TextMeshProUGUI HeartlValue;


    
    //private void Update()
    //{
    //    levelValue = GameObject.Find("LevelValue").GetComponent<TextMeshProUGUI>();
    //    MineralValue = GameObject.Find("MineralValue").GetComponent<TextMeshProUGUI>();
    //    HeartlValue = GameObject.Find("HpValue").GetComponent<TextMeshProUGUI>();

    //    ChangeHeart(WaveManager.Instance.Heart);
    //    ChangeMineral(SpawnManager.Instance.Mineral);
    //    ChangeLevel(WaveManager.Instance.Level);
    //}
    private void Start()
    {
        levelValue = GameObject.Find("LevelValue").GetComponent<TextMeshProUGUI>();
        MineralValue = GameObject.Find("MineralValue").GetComponent<TextMeshProUGUI>();
        HeartlValue = GameObject.Find("HpValue").GetComponent<TextMeshProUGUI>();


        WaveManager.Instance.OnChangeHeart += ChangeHeart;
        WaveManager.Instance.OnChangeLevel += ChangeLevel;
        SpawnManager.Instance.OnChangeMineral += ChangeMineral;

        ChangeHeart(WaveManager.Instance.Heart);
        ChangeMineral(SpawnManager.Instance.Mineral);
        ChangeLevel(WaveManager.Instance.Level);
    }

    public void ChangeLevel(int level)
    {
        levelValue.text = level.ToString();
    }

    public void ChangeMineral(int mineral)
    {
        MineralValue.text = mineral.ToString();
    }

    public void ChangeHeart(int heart)
    { 
        HeartlValue.text = heart.ToString();
    }
}
