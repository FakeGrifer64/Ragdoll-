using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;         // Prefab a ser instanciado
    [SerializeField] private float spawnInterval = 10f; // Tempo entre instâncias
    [SerializeField] private float startDelay = 5f;     // Tempo antes do primeiro spawn

    private float timer = 0f;
    private float startTimer = 0f;
    private bool hasStarted = false;

    void Update()
    {
        if (!hasStarted)
        {
            startTimer += Time.deltaTime;
            if (startTimer >= startDelay)
            {
                hasStarted = true;
                SpawnObject();
            }
            return;
        }

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        Instantiate(prefab, transform.position, Quaternion.Euler(0f, -90f, 0f));

        timer = 0f;
    }
}
