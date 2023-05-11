using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D gridArea;  //�zgara Alan�
    void Start()
    {
        RandomizePosition();
    }

    private void RandomizePosition()  //rastgele yem �reten fonksiyon
    {
        //s�n�rlar paketini kullanarak s�n�rlar ad�nda de�i�ken olu�turduk. 
        Bounds bounds = this.gridArea.bounds;  

        // Bu de�i�kenin x ve y koordinatlar� i�in alabildi�i minimum ve maksimum de�erlerden random olarak x ve y de�i�kenlerine atama yapt�k
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        //Yeni konumu x ve y i�in olu�turulan random konum olarak atand�. Fakat ondal�kl� sonu�lar ��kmas�n� engellemek i�in Mathf.Round ile tam say�ya �evirdik.
        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }

    //isTrigger �zelli�ini a�t���m�z zaman bu methodu kullanabiliriz. �arp��malar� denetleriz
    private void OnTriggerEnter2D(Collider2D other)
    {
        //�arp��t���m�z nesnenin tagi Player ise yeniden konumland�r�r.
        if (other.tag == "Player")
        {
            RandomizePosition();
        }
    }
}
