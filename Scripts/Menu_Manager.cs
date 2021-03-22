using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_Manager : MonoBehaviour
{
    public GameObject You_Dead;
    public GameObject Menu_Panel;
    public GameObject Pause_Menu_Panel;

    public Character_Controller Char_Cont;


    public void New_Game()
    {
        SceneManager.LoadScene(0);
        Menu_Panel.SetActive(false);   
        Time.timeScale = 1;
    }

    // Pause Button in game Scene.
    public void Pause_Game()
    {
        Char_Cont.state = Character_Controller.State.Pause;
        Pause_Menu_Panel.SetActive(true);
        Time.timeScale = 0;
    }

    // Pause menu Buttons.
    public void Continue_Game()
    {
        Char_Cont.state = Character_Controller.State.Play;
        Pause_Menu_Panel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Back_To_Main_Menu()
    {
        Pause_Menu_Panel.SetActive(false);
        Menu_Panel.SetActive(true);
        You_Dead.SetActive(false);
    }

    public void Restart_Game()
    {
        Pause_Menu_Panel.SetActive(false);
        SceneManager.LoadScene(0);
        Time.timeScale = 1;

    }

    public void YOu_Dead_Active()
    {

        You_Dead.SetActive(true);
        Invoke("Back_To_Main_Menu", 3f);

    }

    public void Quit_The_Game()
    {
        Application.Quit();
    }
}
