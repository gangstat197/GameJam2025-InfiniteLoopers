using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;


// Waiting for link with gameState
public class WaveManager: MonoBehaviour
{

    protected static WaveManager instance;
    public static WaveManager Instance{get => instance;}
    public int wave;
    public int waveMax;

    public int curBubbles;

    // random ra monster mỗi lần

    public List<GameObject> bubbles;
    public GameObject goldBubblePrefab;


    public Transform[] spawnPoints1;
    
    public Transform[] endPoints1;


    public Transform[] spawnPoints2;
    
    public Transform[] endPoints2;

    // Time spawn each wave 
    public float spawnInterval = 0.5f; 
    public float Speed = 1.5f;  

    private float timer;

    protected void Awake(){
    
        if (instance == null){instance = this;}
          
    }

    public void Start(){
        curBubbles = 20;

        GameManager.OnGameStateChanged += WaveManagerOnStateChanged;
    }

    public void OnDestroy() {
        GameManager.OnGameStateChanged -= WaveManagerOnStateChanged;
    }

    public void WaveManagerOnStateChanged(GameState newState) {
        if (newState == GameState.PlayState) {
            gameObject.SetActive(true);
        } else {
            gameObject.SetActive(false);
        }
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
        Vector3 emptyVector = new Vector3(0f, 0f, 0f);

        if(wave <= 2){
            float randomValue = Random.Range(0f, 100f);

            if(randomValue - 5f <= 0){
                process(goldBubblePrefab, emptyVector);
            }

            process(bubbles[0], emptyVector);

            curBubbles--;

            if(curBubbles == 0){
                wave++;

                waveMax = Mathf.Max(waveMax, wave);
                curBubbles = 20 + 20*wave/10;
            }
            
        }

        else if(wave <= 4){
            float randomValue = Random.Range(0f, 100f);

            if(randomValue - 5f <= 0){
                process(goldBubblePrefab, emptyVector);
            }

            int random = Random.Range(0, 2);
            process(bubbles[random], emptyVector);

            curBubbles--;

            if(curBubbles == 0){
                wave++;

                waveMax = Mathf.Max(waveMax, wave);
                curBubbles = 20 + 20*wave/10;
            }
        }

        else{

            float randomValue = Random.Range(0f, 100f);

            if(randomValue - 5f <= 0){
                process(goldBubblePrefab, emptyVector);
            }

            int random = Random.Range(0, bubbles.Count);
            Debug.Log(random);
            process(bubbles[random], emptyVector);

            curBubbles--;

            if(curBubbles == 0){
                wave++;

                waveMax = Mathf.Max(waveMax, wave);
                curBubbles = 20 + 20*wave/10;
            }

        }
        
    }

    public void process(GameObject cur, Vector3 startPoint){
        Vector3 emptyVector = new Vector3(0f, 0f, 0f);

        int rand = Random.Range(1, 3);

        if(startPoint == emptyVector){
            // Random start-end point

            if(rand == 1){
                startPoint = spawnPoints1[Random.Range(0, spawnPoints1.Length)].position;
            }
            else{
                startPoint = spawnPoints2[Random.Range(0, spawnPoints2.Length)].position;
            }
            
            
        }

        Vector3 endPoint;

        if(rand == 1){
            endPoint = endPoints1[Random.Range(0, endPoints1.Length)].position;
        }
        else{
            endPoint = endPoints2[Random.Range(0, endPoints2.Length)].position;
        }
        

        GameObject bubble = Instantiate(cur, startPoint, Quaternion.identity);
        bubble.GetComponent<BubbleUnit>().Spawn(startPoint, endPoint, Speed);
    }


}
