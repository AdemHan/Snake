using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;  //ses dosyas� referans� i�in gerekli

    public TMP_Dropdown resolutionDropdown;  // referans vermemiz i�in gerekli bir de�i�ken

    Resolution[] resolutions;  //resolution yani �l�eklendirme verilerini tutan bir dizi

    private void Start()
    {
        resolutions = Screen.resolutions;  //ekran boyutunu resolution degiskenine atadik

        resolutionDropdown.ClearOptions();  // resolutionDropdown referans�ndaki t�m secenekleri sildik

        List<string> options = new List<string>();  //seceneklerimizi listeye ekleyip her boyut i�in yazi ekleyece�iz. sonra onlar� resolutionDropdowna aktaricaz. O y�zden bir list olusturduk.

        int currentResolutionIndex = 0;  //varsay�lan ayarlari tutmasi icin bir degisken atadik 

        for (int i = 0; i < resolutions.Length; i++)  //dizinin boyutunda bir dizi olusturduk
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;  // i indexli eleman i�in en boy verilerini al�p se�enek ad�ndaki degiskene atadik.
            options.Add(option);   // se�enekler listesine, se�enek ad�ndaki degiskeni atadik

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)   //eleman indexindeki boyutlar bizim mevcut verimizdekileri dogruluyorsa mevcut olan o seciliyor numaralarinin
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);     // resolutionDropdown degiskenine options listesini ekledik
        resolutionDropdown.value = currentResolutionIndex;     //esitleme islemleri yapildi
        resolutionDropdown.RefreshShownValue();
    }

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

    public void SetResolution (int resolutionIndex)  //varsayilan olarak tam ekran tusunu secme
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetVolume(float volume)    //Ses seviyesini audioMixer arac�l���yla slidera ba�lam��t�k. De�erin atamas�n� burada yapt�k.
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality (int qualityIndex)  //Grafik kalitesini Quality ayarlar�ndaki index numarasina eri�erek d�zenledik.
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen (bool isFullscreen)  // ekran�n tam ekran olu� olmama durumunu bool cinsinden kontrol ediyoruz.
    {
        Screen.fullScreen = isFullscreen;
    }

}
