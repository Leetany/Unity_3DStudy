using UnityEditor.SearchService;
using UnityEngine;

public class Combo : MonoBehaviour
{
    Animator playerAnim;
    public GameObject hitbox;

    bool comboPossible;
    public int comboStep;
    bool inputSmash;


    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            NormalAttack();
        }

        if (Input.GetMouseButtonDown(1))
        {
            SmashAttack();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAnim.Play("ARPG_Samurai_Parry");
        }
    }

    public void ComboPossible()
    {
        comboPossible = true;
    }

    public void NextAtk()
    {
        if (!inputSmash)
        {
            HitStop.instance.stopTime = 0f;
            HitStop.instance.timeScaleRecoverySpeed = 5;
            HitStop.instance.shakeFrequency = 0.2f;
            HitStop.instance.shakeIntensity = 0.2f;

            if (comboStep == 2)
            {
                playerAnim.Play("ARPG_Samurai_Attack_Combo3");
            }
            if (comboStep == 3)
            {
                playerAnim.Play("ARPG_Samurai_Attack_Combo4");
            }
        }

        if (inputSmash)
        {
            HitStop.instance.stopTime = 0.2f;
            HitStop.instance.timeScaleRecoverySpeed = 5;
            HitStop.instance.shakeFrequency = 0.3f;
            HitStop.instance.shakeIntensity = 0.3f;

            if (comboStep == 1)
            {
                playerAnim.Play("ARPG_Samurai_Attack_Sprint");
            }
            if (comboStep == 2)
            {
                playerAnim.Play("ARPG_Samurai_Attack_Heavy2");
            }
            if (comboStep == 3)
            {
                playerAnim.Play("ARPG_Samurai_Attack_Heavy1_Start");
            }
        }
    }

    public void ResetCombo()
    {
        comboPossible = false;
        comboStep = 0;
        inputSmash = false;
    }

    void NormalAttack()
    {
        if (comboStep == 0)
        {
            playerAnim.Play("ARPG_Samurai_Attack_Combo2");
            comboStep = 1;
            return;
        }

        if (comboStep != 0)
        {
            if (comboPossible)
            {
                comboPossible = false;
                comboStep += 1;
            }
        }
    }

    void SmashAttack()
    {
        if (comboPossible)
        {
            comboPossible = false;
            inputSmash = true;
        }
    }

    void ChangeTag(string t)
    {
        hitbox.tag = t;
    }
}
