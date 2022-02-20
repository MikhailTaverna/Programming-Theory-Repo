using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text scoreText;
    public GameObject[] chickenPrefabs;
    public GameObject dogPrefab;
    public bool isGameActive = false;
    private int score;
    int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            if(score < 0)
            {
                Debug.Log("Error! Score cannot be less than 0");
            }
        }
    }
    void Start()
    {
        scoreText.text = $"Score: {score}";
        isGameActive = true;
        StartCoroutine(SpawnChickenPrefab());
        StartCoroutine(SpawnGodPrefab());
    }
    IEnumerator SpawnChickenPrefab()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(2);
            int index = Random.Range(0, chickenPrefabs.Length);
            Instantiate(chickenPrefabs[index], GenerateRandomChickenPosition(), chickenPrefabs[index].transform.rotation);
        }
    }
    IEnumerator SpawnGodPrefab()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(1);            
            Instantiate(dogPrefab, GenerateRandomDogPosition(), dogPrefab.transform.rotation);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    Vector3 GenerateRandomChickenPosition()
    {
        return new Vector3(Random.Range(-14, 14), 0, 12);
    }
    Vector3 GenerateRandomDogPosition()
    {
        return new Vector3(Random.Range(-14, 14), 0, -12);
    }
    public void AddScore(int points)
    {
        score += points;
        scoreText.text = $"Score: {score}";
    }
}
