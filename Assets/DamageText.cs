using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    [SerializeField]
    private float deleteTime;


    TextMeshProUGUI textMeshPro;

    [SerializeField]
    private float Speed;

    [SerializeField]
    private float alphaSpeed;

    Color alpha;

    private Weapon weapon; 

    public float damage;
    private void Awake()
    {
        weapon = GameObject.Find("RealSword").GetComponent<Weapon>();
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }


    void Start()
    {
        Invoke("DestoryObject", deleteTime);
        textMeshPro.text = weapon.damage.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, Speed * Time.deltaTime, 0));
        alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime * alphaSpeed);
    }

    IEnumerator Damagetext()
    {
        yield return new WaitForSeconds(deleteTime);
    }

    void DestoryObject()
    {
        Destroy(gameObject);    
    }

}
