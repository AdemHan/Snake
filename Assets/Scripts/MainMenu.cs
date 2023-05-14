using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;  //ses dosyasý referansý için gerekli

    public TMP_Dropdown resolutionDropdown;  // referans vermemiz için gerekli bir deðiþken

    Resolution[] resolutions;  //resolution yani ölçeklendirme verilerini tutan bir dizi

    private void Start()
    {
        resolutions = Screen.resolutions;  //ekran boyutunu resolution degiskenine atadik

        resolutionDropdown.ClearOptions();  // resolutionDropdown referansýndaki tüm secenekleri sildik

        List<string> options = new List<string>();  //seceneklerimizi listeye ekleyip her boyut için yazi ekleyeceðiz. sonra onlarý resolutionDropdowna aktaricaz. O yüzden bir list olusturduk.

        for (int i = 0; i < resolutions.Length; i++)  //dizinin boyutunda bir dizi olusturduk
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;  // i indexli eleman için en boy verilerini alýp seçenek adýndaki degiskene atadik.
            options.Add(option);   // seçenekler listesine, seçenek adýndaki degiskeni atadik
        }

        resolutionDropdown.AddOptions(options);     // resolutionDropdown degiskenine options listesini ekledik
    }

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

    public void SetVolume(float volume)    //Ses seviyesini audioMixer aracýlýðýyla slidera baðlamýþtýk. Deðerin atamasýný burada yaptýk.
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality (int qualityIndex)  //Grafik kalitesini Quality ayarlarýndaki index numarasina eriþerek düzenledik.
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen (bool isFullscreen)  // ekranýn tam ekran oluð olmama durumunu bool cinsinden kontrol ediyoruz.
    {
        Screen.fullScreen = isFullscreen;
    }

}
