using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        //Burada aktif olan sahnemizin index numarasýna bir ekledik ve yüklemesini soyledik. Yani build settingsdeki siradaki sahneyi yüklemesini soyledik.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

}
