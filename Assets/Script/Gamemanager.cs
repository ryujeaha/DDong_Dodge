using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    //Score,HP 변수
    public static int Score;
    public static int Hp = 5;
    public int totalScore;
    public float time = 0;

    //UI,Text 변수
    public Text Score_Text;
    public Text Total_Score_Txt;
    public Text Time_Text;
    public Text HP_Text;

    //논리형 체크변수
    private bool checkpp = true;

    //게임 오브젝트 변수
    private GameObject PP;
    private GameObject canvas;
    private GameObject AndPanel;
    [SerializeField] GameObject Stop_Screen;
    [SerializeField] GameObject Dead_Screen;

    //변수
    private int Ran;
    public static int Increas_Score;
    public static float Delay;
    bool IsStop = false;
    void Start()
    {
        // Score,HP 변수 초기화 
        Score = 0;
        Hp = 5;

        //각 오브젝트 게임 오브젝트 변수 참조
        PP = Resources.Load("DDong") as GameObject;
        canvas = GameObject.Find("Canvas");
        AndPanel = Resources.Load("AndPanel") as GameObject;
    }

    // UI Text
    void ViewText()
    {
        // 점수 값 화면에 가시화
        Score_Text.text = Score.ToString()+"점";
        HP_Text.text = Hp.ToString();
    }

    //점수 증가 역할을 하는 public static Score 함수 생성
    public static void AddScore()
    {
        Score = Score + Increas_Score;
    }

    //체력 감소 역할을 하는 public static MinHp 함수 생성
    public static void MinHp()
    {
        Hp--;
    }

    public void Continue()
    {
        Time.timeScale = 1.0f;
        Stop_Screen.SetActive(false);
    }    

    //코루틴
     public IEnumerator CreatePP(float Delay)
    {
        //논리형 false로 준 후 랜덤 값을 생성하고 객체 생성하고 1초가 지난뒤 다시 논리값 true
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
        Total_Score_Txt.text = "총점수" + totalScore.ToString() + "점";
        Time_Text.text = "버틴 시간" + time.ToString() + "초";
    }

    void Update()
    {
        time += Time.deltaTime;

        //논리형 true이면
        if (checkpp)
        {
            //코루틴 발생
            StartCoroutine("CreatePP",Delay);
        }

        //일시정지
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
