using UnityEngine;
using System.Collections.Generic;


// Waiting for link with gameState
public class WaveManager: MonoBehaviour
{

    protected static WaveManager instance;
    public static WaveManager Instance{get => instance;}
    public int wave;
    public int curBubbles;

    // random ra monster mỗi lần

    public List<GameObject> bubbles;
    public GameObject goldBubblePrefab;


    public Transform[] spawnPoints;  
    public Transform[] endPoints;   

    // Time spawn each wave 
    public float spawnInterval = 2f; 
    public float Speed = 3f;  

    private float timer;

    protected void Awake(){
    
        if (instance == null){instance = this;}
          
    }

    public void Start(){
        curBubbles = 20;
    }

    void Update()
    {
        timer += Time.deltaTime;

        
        if (timer >= spawnInterval)
        {
            Spawn();
            timer = 0f;
        }
    }

    void Spawn()
    {

        if(wave <= 2){
            float randomValue = Random.Range(0f, 100f);

            if(randomValue - 5f <= 0){
                process(goldBubblePrefab);
            }

            process(bubbles[0]);

            curBubbles--;

            if(curBubbles == 0){
                wave++;
                curBubbles = 20 + 20*wave/10;
            }
            
        }

        else if(wave <= 4){
            float randomValue = Random.Range(0f, 100f);

            if(randomValue - 5f <= 0){
                process(goldBubblePrefab);
            }

            int random = Random.Range(0, 2);
            process(bubbles[random]);

            curBubbles--;

            if(curBubbles == 0){
                wave++;
                curBubbles = 20 + 20*wave/10;
            }
        }

        else{

            float randomValue = Random.Range(0f, 100f);

            if(randomValue - 5f <= 0){
                process(goldBubblePrefab);
            }

            int random = Random.Range(0, bubbles.Count);
            Debug.Log(random);
            process(bubbles[random]);

            curBubbles--;

            if(curBubbles == 0){
                wave++;
                curBubbles = 20 + 20*wave/10;
            }

        }
        
    }

    void process(GameObject cur){
        // Random start-end point
        Vector3 startPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
        Vector3 endPoint = endPoints[Random.Range(0, endPoints.Length)].position;

        GameObject bubble = Instantiate(cur, startPoint, Quaternion.identity);
        bubble.GetComponent<BubbleUnit>().Spawn(startPoint, endPoint, Speed);
    }


}
