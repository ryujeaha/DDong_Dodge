using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PP_down : MonoBehaviour
{
  public static float Speed = 800;
    void Update()
    {
        //�� ������Ʈ �Ʒ��� ���� �߸���
        this.transform.Translate(Vector2.down * Speed * Time.deltaTime);//Translate�Լ��� Ȱ���ϸ� ������Ʈ�� ���ϴ� �������� �̵���ų �� �ֽ��ϴ�.
                                                                        //Translate �Լ��� transformŬ�������� �ҷ��ɴϴ�. �� ��ü�� ��ġ���� ������� �۵��Ѵٴ� �ǹ��Դϴ�.
        // ���� ������Ʈ�� ������ 0���� ��������
        if(this.gameObject.transform.position.y <= 0)
        {
            //���� �ø��� ������Ʈ ����
            Gamemanager.AddScore();
            Destroy(this.gameObject);
        }
    }
}
