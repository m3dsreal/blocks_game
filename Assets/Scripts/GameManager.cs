using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public BlockGenerate BG;
    public TextMeshProUGUI score;
    public GameObject gameover;
    public GameObject youWin;
    public GameObject Restart;


    public GameObject ButtonStart;
    public GameObject GeneratorBlocks;

    private Vector3 Respawn;
    public GameObject parentObject;

    [SerializeField] GameObject[] ChildsParents;

    private int AddPoint;

    private void Start()
    {
        AddPoint = 0;
        Respawn = GeneratorBlocks.transform.position;
    }

    private void Update()
    {
        if (BG.Count > 10)
        {
            youWin.SetActive(true);
            GeneratorBlocks.SetActive(false);
            Restart.SetActive(true);
        }
    }

    public void UpdateScore()
    {
        BG.Count++;
        int point = 1;
        AddPoint += point;
        Debug.Log(AddPoint);
        score.text = "SCORE: " + AddPoint;
    }

    public void GameOver()
    {
        gameover.SetActive(true);
        Restart.SetActive(true);
        GeneratorBlocks.SetActive(false);


    }

    public void StartGame()
    {
        GeneratorBlocks.SetActive(true);
        ButtonStart.SetActive(false);
        AddPoint = 0;
        score.text = "SCORE: " + AddPoint;
        gameover.SetActive(false);
        Restart.SetActive(false);
        GeneratorBlocks.transform.position = Respawn;
        BG.Count = 0;

        
    }

    public void RestartGame()
    {
        GeneratorBlocks.SetActive(true);
        ButtonStart.SetActive(false);
        AddPoint = 0;
        score.text = "SCORE: " + AddPoint;
        gameover.SetActive(false);
        Restart.SetActive(false);
        GeneratorBlocks.transform.position = Respawn;
        youWin.SetActive(false);
        deleteBlock();
        BG.Count = 0;
    }


    public void deleteBlock()
    {
        ChildsParents = new GameObject[parentObject.transform.childCount];

        for(int i = 0; i <ChildsParents.Length; i++)
        {
            ChildsParents[i] = parentObject.transform.GetChild(i).gameObject;
            Destroy(ChildsParents[i]);
        }
    }



}
