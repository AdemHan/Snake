using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D gridArea;  //ýzgara Alaný
    void Start()
    {
        RandomizePosition();
    }

    private void RandomizePosition()  //rastgele yem üreten fonksiyon
    {
        //sýnýrlar paketini kullanarak sýnýrlar adýnda deðiþken oluþturduk. 
        Bounds bounds = this.gridArea.bounds;  

        // Bu deðiþkenin x ve y koordinatlarý için alabildiði minimum ve maksimum deðerlerden random olarak x ve y deðiþkenlerine atama yaptýk
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        //Yeni konumu x ve y için oluþturulan random konum olarak atandý. Fakat ondalýklý sonuçlar çýkmasýný engellemek için Mathf.Round ile tam sayýya çevirdik.
        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }

    //isTrigger özelliðini açtýðýmýz zaman bu methodu kullanabiliriz. Çarpýþmalarý denetleriz
    private void OnTriggerEnter2D(Collider2D other)
    {
        //çarpýþtýðýmýz nesnenin tagi Player ise yeniden konumlandýrýr.
        if (other.tag == "Player")
        {
            RandomizePosition();
        }
    }
}
