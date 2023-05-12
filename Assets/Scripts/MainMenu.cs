using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        //Burada aktif olan sahnemizin index numaras�na bir ekledik ve y�klemesini soyledik. Yani build settingsdeki siradaki sahneyi y�klemesini soyledik.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

}
