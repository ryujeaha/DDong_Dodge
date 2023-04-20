using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class TouchR : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    //Player ��ü,���� ���� ����
    public GameObject player;
    private bool playerBool = false;

   

    void Update()
    {
      //���� ��ġ ���̸�
      if(playerBool)
        {
            //�÷��̾ ���������� �̵�
            player.transform.Translate(Vector2.right * 500f * Time.deltaTime);
        }
    }
    //������ ���� �Լ��� ����� ��ġ�� �ൿ�� ������ �� �ִ�.
    public void OnPointerDown(PointerEventData eventData)
    {
        //������ ���� ���� true
        playerBool = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //���� ���� ���� false
        playerBool = false;
    }
}
