using TMPro;
using UnityEngine;

public class HitBox_Player : MonoBehaviour
{
    public Animator playerAni;
    public TextMeshProUGUI message;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Col_EnemyAtk"))
        {
            if(gameObject.CompareTag("HitBox_Player"))
            {
                //데미지 입은 애니메이션

                message.text = "Player Damage";
                message.gameObject.SetActive(true);
            }

            if(gameObject.CompareTag("Defense"))
            {
                message.text = "Block";
                message.gameObject.SetActive(true);
            }

            if(gameObject.CompareTag("Parrying"))
            {
                playerAni.Play("Counter");
                message.text = "Parrying";
                message.gameObject.SetActive(true);
            }
        }
    }
}
