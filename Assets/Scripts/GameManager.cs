using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text scoreText;
    public Text recordText;
    public GameObject gameOverScreen;
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
    private string playerName;
    
    void Start()
    {
        playerName = MenuManager.Instance.playerName;
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
            yield return new WaitForSeconds(3);            
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
    public void GameOver()
    {
        SaveData data = new SaveData();
        data.LoadResult();
        if(score > data.bestScore)
        {
            data.bestScore = score;
            data.playerName = playerName;
            data.SaveResult();
        }
        recordText.text = $"Name: {data.playerName} Score: {data.bestScore}";
        gameOverScreen.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
        
    }
    [System.Serializable]
    public class SaveData
    {
        public string playerName;
        public int bestScore;

        public void SaveResult()
        {
            SaveData data = new SaveData();
            data.playerName = playerName;
            data.bestScore = bestScore;

            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }
        public void LoadResult()
        {
            string path = Application.persistentDataPath + "/savefile.json";
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                SaveData data = JsonUtility.FromJson<SaveData>(json);
                bestScore = data.bestScore;
                playerName = data.playerName;
            }

        }
    }

}
