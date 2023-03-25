using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
  public void ChangeScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

  public void SalirdelJuego()
    {
        Application.Quit();
    }
}
