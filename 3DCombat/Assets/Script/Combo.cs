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
            //방어
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
            if (comboStep == 1)
            {
                //playAnim.Play("");
            }
            if (comboStep == 2)
            {
                //playAnim.Play("");
            }
            if (comboStep == 3)
            {
                //playAnim.Play("");
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
