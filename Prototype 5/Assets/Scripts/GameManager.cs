using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using UnityEngine.SceneManagement;
using UnityEngine.UI;




public class GameManager : MonoBehaviour
{
    //for the number of objects needed to spawn.
    public List<GameObject> targets;
    //how fast will the targets be spawn.
    private float spawnRate = 1.0f;
    //get the textmeshprogui dic.
    public TextMeshProUGUI scoreText;
    //stor the number of scores.
    private int score;
    //get the TextMeshProUGUI dic.
    public TextMeshProUGUI GameOverText;
    //if false or true.
    public bool isGameActive;
    //for restart button
    public Button restartButton;
    //for quit button
    public Button quitButton;
    //for title screen
    public GameObject titleScreen;

    // Start is called before the first frame update
    void Start()
    {

    }
    public void StartGame(int difficulty)
    {
        // declare that the game is active
        isGameActive = true;

        StartCoroutine(SpawnTarget());
        //store the number destroyed targets.
        score = 0;
        //call the updatescore method.
        UpdateScore(0);

        titleScreen.gameObject.SetActive(false);
        spawnRate /= difficulty;
    }

    // Update is called once per frame
    void Update()
    {

    }
    //for spawning the targets
    IEnumerator SpawnTarget()
    {
        //only works when the game is active or its value is true.
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);

        }

    }
    //sycronize the scores to the number of destroyed gameObjects targets.
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score:" + score;
    }

    //When called it will show gameover text and replay button
    public void GameOver()
    {
        // activate the restart and gameover text.
        quitButton.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        GameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }
    //give functionality to the restart button.
    public void RestartGame()
    {
        //restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    //give functionality to the quit button.
    public void QuitGame()
    {
        //quit the game
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
