using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PP_down : MonoBehaviour
{
  public static float Speed = 800;
    void Update()
    {
        //똥 오브젝트 아래로 떨어 뜨리기
        this.transform.Translate(Vector2.down * Speed * Time.deltaTime);//Translate함수를 활용하면 오브젝트를 원하는 방향으로 이동시킬 수 있습니다.
                                                                        //Translate 함수는 transform클래스에서 불러옵니다. 즉 물체의 위치값을 기반으로 작동한다는 의미입니다.
        // 만약 오브젝트가 포지션 0으로 내려가면
        if(this.gameObject.transform.position.y <= 0)
        {
            //점수 올리고 오브젝트 삭제
            Gamemanager.AddScore();
            Destroy(this.gameObject);
        }
    }
}
