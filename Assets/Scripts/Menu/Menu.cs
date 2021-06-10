using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public string cena;
    //public GameObject PanelOpitions;
    public GameObject PanelCreditos;
    public GameObject PanelLoad;

    public void StartGame()
    {
        PanelLoad.SetActive(true);
        SceneManager.LoadScene(cena);

    }

    public void quietGame()
    {

        //editor unity
        UnityEditor.EditorApplication.isPlaying = false;
        //jogo compilado 
        //Application.Quit();

    }
   

    public void ShowCredit()
    {

        PanelCreditos.SetActive(true);

    }

    public void BackToMenu()
    {

        PanelCreditos.SetActive(false);

    }
}
