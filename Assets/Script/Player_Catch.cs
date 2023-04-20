using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Catch : MonoBehaviour
{
    [SerializeField] Animator animator;
 
    void Update()
    {
        //플레이어 좌우 못가게
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
        //태그 이름이 DDong라면
        if(collision.tag == "DDong")
        {
            Debug.Log("충돌");
            //animator.SetTrigger("Hit");
            Gamemanager.MinHp();
            //태그 오브젝트 삭제
            Destroy(collision.gameObject);
        }
    }
}
