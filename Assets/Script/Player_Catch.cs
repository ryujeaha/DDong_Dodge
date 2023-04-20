using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Catch : MonoBehaviour
{
    [SerializeField] Animator animator;
 
    void Update()
    {
        //�÷��̾� �¿� ������
        if(gameObject.transform.position.x >= Screen.width-50)
        {
            gameObject.transform.position = new Vector2(Screen.width - 50, gameObject.transform.position.y);
        }
        if(gameObject.transform.position.x <= 50)
        {
            gameObject.transform.position = new Vector2(50,gameObject.transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�±� �̸��� DDong���
        if(collision.tag == "DDong")
        {
            Debug.Log("�浹");
            //animator.SetTrigger("Hit");
            Gamemanager.MinHp();
            //�±� ������Ʈ ����
            Destroy(collision.gameObject);
        }
    }
}
