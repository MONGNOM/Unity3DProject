using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkilButton : MonoBehaviour
{

    public ParticleSystem beamparticle;
    public ParticleSystem powerUpparticle;
    public ParticleSystem iceAttackparticle;
    public BoxCollider iceAttackbox;
    public GameObject sword;
    public Weapon realsword;

    public float damage;
    

    public Button button;
    public Animator animator;


    private void Start()
    {
        iceAttackbox.enabled = false;
        damage = realsword.damage;
    }

    void Update()
    {
        // �÷��̾� ��Ʈ�ѷ��� �̵� ����
        if (Input.GetKeyDown("1"))
        {
            beamparticle.Play();
            animator.SetBool("BeamSkil", true);
            animator.SetTrigger("Beam");
            StartCoroutine(BeamAttackPose());
            PlayerStatusManager.Instance.UseMp(150);
            // �ݸ��� �Ⱦֵ����� ������ ��
        }
        else if (Input.GetKeyDown("2"))
        {
            powerUpparticle.Play();
            animator.SetBool("PowerUp", true);
            realsword.damage = realsword.damage * 2;
            StartCoroutine(PowerUpExit());
            PlayerStatusManager.Instance.UseMp(50);
        }
        else if (Input.GetKeyDown("3"))
        {
            iceAttackparticle.Play();
            animator.SetTrigger("IceAttack");
            iceAttackbox.enabled = true;
            StartCoroutine(iceAttackCollider());
            PlayerStatusManager.Instance.UseMp(100);
        }
        //else if (Input.GetKeyDown("`"))
        //{ 
        //    PlayerStatusManager.Instance.UseMp(100);
        //    if (sword.gameObject.activeSelf)
        //    {
        //        sword.gameObject.SetActive(false);
        //    }
        //    else
        //    {
        //        sword.gameObject.SetActive(true);
        //    }
        //}
        else
        {
            animator.SetBool("PowerUp", false);
        }
    }

    public IEnumerator iceAttackCollider()
    {
        yield return new WaitForSeconds(3.8f);
        iceAttackbox.enabled = false;
    }

    public IEnumerator BeamAttackPose()
    {
        yield return new WaitForSeconds(7.3f);
        animator.SetBool("BeamSkil", false);
    }

    public IEnumerator PowerUpExit()
    {
        yield return new WaitForSeconds(5f);
        realsword.damage /= 2;
    }

}
