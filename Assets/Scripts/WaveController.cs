using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class WaveController : MonoBehaviour
{

    public WaveSettings settings;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    Vector3 GetRandomSpawnPoint()
    {
        // for now get the player by find the type but later remember to get reference from GameManager
        Player player = FindAnyObjectByType<Player>();
        Vector3 center = player.transform.position;

        List<Vector3> spawnPoints = new List<Vector3>();    
        
        for (int i = 0; i < settings.radialCount; i++)
        {
            float t = i / (settings.radialCount - 1);
            float radius = Mathf.Lerp(settings.innerRadius, settings.outerRadius,t);
        }

        
        int randIndex = Random.Range(0, spawnPoints.Count);
        return spawnPoints[randIndex];
    }
}

public class WaveSettings
{
    public int enemyCount;
    public float spawnRate;
    public float radialCount;
    public float angularSteps;
    public float innerRadius;
    public float outerRadius;

}