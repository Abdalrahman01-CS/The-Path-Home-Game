using UnityEngine;

public class RainSpawner : MonoBehaviour
{
    public GameObject poisonPrefab;
    public GameObject collectiblePrefab;
    public Transform spawnPoint;
    public float spawnInterval = 1f;
    public int spawnCount = 10;
    public float spawnRangeX = 2f;

    private int spawned = 0;
    private int collectibleIndex;
    private bool spawnActive = false;

    void Start()
    {
        // collectible ALWAYS after the 2nd diamond
        collectibleIndex = Random.Range(2, spawnCount - 1);
    }

    void Update()
    {
        if (spawnActive && spawned < spawnCount)
        {
            spawnActive = false;
            InvokeRepeating("SpawnDiamond", 0f, spawnInterval);
        }
    }

    void SpawnDiamond()
    {
        if (spawned >= spawnCount)
        {
            CancelInvoke("SpawnDiamond");
            return;
        }

        bool isCollectible = (spawned == collectibleIndex);
        GameObject prefabToSpawn = isCollectible ? collectiblePrefab : poisonPrefab;

        Vector3 spawnPos = spawnPoint.position +
                           new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, 0);

        GameObject obj = Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);

        // Tell the diamond what type it is
        PoisonDiamond pd = obj.GetComponent<PoisonDiamond>();
        if (pd != null)
            pd.isCollectible = isCollectible;

        spawned++;
    }

    public void BeginRain()
    {
        spawned = 0;
        spawnActive = true;
        collectibleIndex = Random.Range(2, spawnCount - 1);
    }
}
