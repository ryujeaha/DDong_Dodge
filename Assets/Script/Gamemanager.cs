using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    //Score,HP ����
    public static int Score;
    public static int Hp = 5;
    public int totalScore;
    public float time = 0;

    //UI,Text ����
    public Text Score_Text;
    public Text Total_Score_Txt;
    public Text Time_Text;
    public Text HP_Text;

    //���� üũ����
    private bool checkpp = true;

    //���� ������Ʈ ����
    private GameObject PP;
    private GameObject canvas;
    private GameObject AndPanel;
    [SerializeField] GameObject Stop_Screen;
    [SerializeField] GameObject Dead_Screen;

    //����
    private int Ran;
    public static int Increas_Score;
    public static float Delay;
    bool IsStop = false;
    void Start()
    {
        // Score,HP ���� �ʱ�ȭ 
        Score = 0;
        Hp = 5;

        //�� ������Ʈ ���� ������Ʈ ���� ����
        PP = Resources.Load("DDong") as GameObject;
        canvas = GameObject.Find("Canvas");
        AndPanel = Resources.Load("AndPanel") as GameObject;
    }

    // UI Text
    void ViewText()
    {
        // ���� �� ȭ�鿡 ����ȭ
        Score_Text.text = Score.ToString()+"��";
        HP_Text.text = Hp.ToString();
    }

    //���� ���� ������ �ϴ� public static Score �Լ� ����
    public static void AddScore()
    {
        Score = Score + Increas_Score;
    }

    //ü�� ���� ������ �ϴ� public static MinHp �Լ� ����
    public static void MinHp()
    {
        Hp--;
    }

    public void Continue()
    {
        Time.timeScale = 1.0f;
        Stop_Screen.SetActive(false);
    }    

    //�ڷ�ƾ
     public IEnumerator CreatePP(float Delay)
    {
        //���� false�� �� �� ���� ���� �����ϰ� ��ü �����ϰ� 1�ʰ� ������ �ٽ� ���� true
        checkpp = false;
        Ran = Random.Range(50, Screen.width - 51);
        Instantiate(PP, new Vector2(Ran, Screen.height), Quaternion.identity, canvas.transform);
        yield return new WaitForSeconds(Delay);
        checkpp = true;
    }

    public void QUit()
    {
        SceneManager.LoadScene(0);
    }

    public void Result()
    {
        totalScore = Score;
        Total_Score_Txt.text = "������" + totalScore.ToString() + "��";
        Time_Text.text = "��ƾ �ð�" + time.ToString() + "��";
    }

    void Update()
    {
        time += Time.deltaTime;

        //���� true�̸�
        if (checkpp)
        {
            //�ڷ�ƾ �߻�
            StartCoroutine("CreatePP",Delay);
        }

        //�Ͻ�����
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            IsStop = true;
            Stop_Screen.SetActive(true);
        }
        else if (IsStop && Input.GetKeyDown(KeyCode.Escape))
        {
            IsStop = false;
            Continue();
        }

        if(Hp <= 0)
        {
            Time.timeScale = 0f;
            Result();
            Dead_Screen.SetActive(true);
        }
        ViewText();
    }
}
