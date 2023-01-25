using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{
    private Button button;
    public GameManager gameManager;
    public int difficulty;

    // Start is called before the first frame update
    void Start()
    {
        //get the easy, medium, hard button
        button = GetComponent<Button>();
        //when click one of the buttun it set the assigned spawnrate of the targets,
        button.onClick.AddListener(SetDifficulty);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetDifficulty()
    {
        //set the level of difficulty.
        gameManager.StartGame(difficulty);
    }
}
