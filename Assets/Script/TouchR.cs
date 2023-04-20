using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class TouchR : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    //Player 객체,논리형 변수 선언
    public GameObject player;
    private bool playerBool = false;

   

    void Update()
    {
      //만약 터치 중이면
      if(playerBool)
        {
            //플레이어를 오른쪽으로 이동
            player.transform.Translate(Vector2.right * 500f * Time.deltaTime);
        }
    }
    //다음과 같은 함수로 모바일 터치시 행동을 제어할 수 있다.
    public void OnPointerDown(PointerEventData eventData)
    {
        //누르면 논리형 변수 true
        playerBool = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //떄면 논리형 변수 false
        playerBool = false;
    }
}
