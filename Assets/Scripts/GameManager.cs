using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;
    private int score;
    private float spwanRate = 1.0f;
    public bool isGameOver;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator SpawnTarget()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(spwanRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);

        }

    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    public void GameOver()
    {
        isGameOver = true;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }
    public void RestarGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StarGame(int difficulty)
    {
        spwanRate /= difficulty;
        StartCoroutine(SpawnTarget());
        score = 0;
        scoreText.text = "Score: " + score;
        isGameOver = false;
        titleScreen.SetActive(false);

    }
}
