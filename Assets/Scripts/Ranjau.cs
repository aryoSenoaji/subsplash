using System.Collections;
using UnityEngine;

public class Ranjau : MonoBehaviour
{
    public float speed = 5f;
    private float leftEdge;

    // Referensi ke Oxygen
    public Oxygen oxygen;

    // Tambahkan variabel untuk menentukan seberapa banyak waktu yang akan dikurangi
    public float timeToReduce = 5f;

    void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    void Update()
    {
        MoveRanjau();
        CheckDestroy();
    }

    void MoveRanjau()
    {
        transform.position += speed * Time.deltaTime * Vector3.left;
    }

    void CheckDestroy()
    {
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }

    // Ketika ada tabrakan dengan pemain
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Kurangi waktu pada Oxygen
            if (oxygen != null)
            {
                oxygen.ReduceTime(timeToReduce);
            }

            // Hancurkan ranjau
            Destroy(gameObject);
        }
    }
}
