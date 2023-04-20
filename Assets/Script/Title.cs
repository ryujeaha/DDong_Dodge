using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Title : MonoBehaviour
{
    [SerializeField] GameObject Level_Screen;
    [SerializeField] GameObject Ui;
    [SerializeField] GameObject[] Level_Btn_Txt;

    public void Start_Game()
     {        
        Ui.SetActive(false);
        Level_Screen.SetActive(true);
        Time.timeScale = 1.0f;
    }
    public void Back_Btn()
    {
        Ui.SetActive(true);
        Level_Screen.SetActive(false);
    }

    public void Easy()
    {
        PP_down.Speed = 1000;
        Gamemanager.Increas_Score = 50;
        Gamemanager.Delay = 0.7F;
        Level_Btn_Txt[0].SetActive(true);
        Level_Btn_Txt[1].SetActive(false);
        Level_Btn_Txt[2].SetActive(false);
    }
    public void Normal()
    {
        PP_down.Speed = 1500;
        Gamemanager.Increas_Score = 70;
        Gamemanager.Delay = 0.5F;
        Level_Btn_Txt[0].SetActive(false);
        Level_Btn_Txt[1].SetActive(true);
        Level_Btn_Txt[2].SetActive(false);
    }
    public void Hard()
    {
        PP_down.Speed = 1800;
        Gamemanager.Increas_Score = 100;
        Gamemanager.Delay = 0.3F;
        Level_Btn_Txt[0].SetActive(false);
        Level_Btn_Txt[1].SetActive(false);
        Level_Btn_Txt[2].SetActive(true);
    }

    public void Check()
    {
        SceneManager.LoadScene("Game");
    }

    public void Quit_Game()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else   
        Application.Quit();   
#endif
    }

}
