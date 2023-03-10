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

    public Weapon realsword;
    

    public Button button;
    public Animator animator;


    private void Start()
    {
        iceAttackbox.enabled = false;
    }

    void Update()
    {
        // 플레이어 컨트롤러로 이동 예정
        if (Input.GetKeyDown("1"))
        {
            Debug.Log("스킬씀");
            beamparticle.Play();
            animator.SetBool("BeamSkil", true);
            animator.SetTrigger("Beam");
            StartCoroutine(BeamAttackPose());
            PlayerStatusManager.Instance.UseMp(150);
        }
        else if (Input.GetKeyDown("2"))
        {
            Debug.Log("스킬씀");
            powerUpparticle.Play();
            animator.SetBool("PowerUp", true);
            realsword.damage = realsword.damage * 2;
            StartCoroutine(PowerUpExit());
            PlayerStatusManager.Instance.UseMp(50);
        }
        else if (Input.GetKeyDown("3"))
        {
            Debug.Log("스킬씀");
            iceAttackparticle.Play();
            animator.SetTrigger("IceAttack");
            iceAttackbox.enabled = true;
            StartCoroutine(iceAttackCollider());
            PlayerStatusManager.Instance.UseMp(100);
        }
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
        Debug.Log("버프 5초 남음");
        yield return new WaitForSeconds(5f);
        realsword.damage /= 2;
    }

}
