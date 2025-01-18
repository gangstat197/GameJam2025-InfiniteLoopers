using UnityEngine;

public class WaveManager: MonoBehaviour
{

    protected static WaveManager instance;
    public static WaveManager Instance{get => instance;}
    public int wave = 1;

    // random ra monster mỗi lần
    public GameObject bubblePrefab; 
    public Transform[] spawnPoints;  
    public Transform[] endPoints;   

    // Time spawn each wave 
    public float spawnInterval = 2f; 
    public float Speed = 3f;  

    private float timer;

    protected void Awake(){
    
        if (instance == null){instance = this;}
          
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnMonster();
            timer = 0f;
        }
    }

    void SpawnMonster()
    {
        // Random start-end point
        Vector3 startPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
        Vector3 endPoint = endPoints[Random.Range(0, endPoints.Length)].position;

        
        GameObject bubble = Instantiate(bubblePrefab, startPoint, Quaternion.identity);

        
        bubble.GetComponent<BubbleUnit>().Spawn(startPoint, endPoint, Speed);
    }
}
