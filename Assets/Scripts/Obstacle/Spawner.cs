using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject coralPrefab;
    public GameObject ranjauPrefab;
    public float spawnRateCoral = 1f;
    public float spawnRateRanjau = 2f;

    public Oxygen oxygen;
    public float timeToAdd;

    private void OnEnable()
    {
        InvokeRepeating(nameof(SpawnCoral), 0f, spawnRateCoral);
        InvokeRepeating(nameof(SpawnRanjau), 0f, spawnRateRanjau);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(SpawnCoral));
        CancelInvoke(nameof(SpawnRanjau));
    }

    private void SpawnCoral()
    {
        GameObject coral = Instantiate(coralPrefab, transform.position, Quaternion.identity);

        // Tambahkan waktu ke timer Oxygen
        if (oxygen != null)
        {
            oxygen.AddTime(timeToAdd);
        }
    }

    private void SpawnRanjau()
    {
        GameObject coral = GameObject.FindWithTag("Obstacle");
        if (coral != null)
        {
            Vector3 coralPosition = coral.transform.position;

            // Lakukan percobaan spawn ranjau di sekitar posisi coral
            for (int i = 0; i < 10; i++)
            {
                Vector3 ranjauSpawnPosition = GetRandomRanjauSpawnPosition(coralPosition);

                // Cek tumpang tindih dengan objek lain yang sudah ada
                Collider[] colliders = Physics.OverlapSphere(ranjauSpawnPosition, 0.5f);
                if (colliders.Length == 0)
                {
                    Instantiate(ranjauPrefab, ranjauSpawnPosition, Quaternion.identity);
                    break;
                }
            }
        }
    }

    private Vector3 GetRandomRanjauSpawnPosition(Vector3 coralPosition)
    {
        float spawnRadius = 5f;

        // Posisi acak di sekitar posisi coral
        Vector3 randomOffset = new Vector3(Random.Range(-spawnRadius, spawnRadius), Random.Range(-spawnRadius, spawnRadius), Random.Range(-spawnRadius, spawnRadius));

        Vector3 ranjauSpawnPosition = coralPosition + randomOffset;

        return ranjauSpawnPosition;
    }
}
