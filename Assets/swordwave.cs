using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class swordwave : MonoBehaviour
{
    public float wavedelete;
    public float waveSpeed;
    public float damage;
    public PlayerController playerController;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        StartCoroutine(Swordwave());

    }
    public IEnumerator Swordwave()
    {
        yield return new WaitForSeconds(wavedelete);

        Destroy(gameObject);
        Debug.Log(string.Format("{0}¿Ã ªÁ∂Û¡¸", gameObject.name));
    }

  
    private void Update()
    {
        Vector3 forward = playerController.transform.forward;
        transform.Translate(forward * waveSpeed * Time.deltaTime, Space.World);
        
    }

}
