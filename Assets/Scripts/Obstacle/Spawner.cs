using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabs;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;

    // Tambahkan reference ke Oxygen
    public Oxygen oxygen;

    public float timeToAdd;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        GameObject corals = Instantiate(prefabs, transform.position, Quaternion.identity);
        corals.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);

        // Tambahkan waktu ke timer Oxygen
        if (oxygen != null)
        {
            oxygen.AddTime(timeToAdd); // Menggunakan variabel timeToAdd
        }
    }
}
