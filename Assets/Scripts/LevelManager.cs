using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    GenerateShape generateShape;
    GenerateBoard generateBoard;
    ShapeCubeScript shapeCubeScript;
    GameUI gameUI;
    public Sprite[] shapes;
    int level = 1;
    private void Awake()
    {
        generateShape = GameObject.Find("ShapeGenerator").GetComponent<GenerateShape>();
        generateBoard = GameObject.Find("BoardGenerator").GetComponent<GenerateBoard>();
        gameUI = GameObject.Find("GameUI").GetComponent<GameUI>();

    }
    void Start()
    {

        level = 1;
        gameUI.ChangeCurrentLevelText(level);
    }

    void Update()
    {
        CheckLevelCompleted();
    }

    void CheckLevelCompleted()
    {
        if (GenerateShape.totalPlayerCubes > 0)
        {
            float completedLevel = (float)(GenerateShape.totalPlayerCubesConstant - GenerateShape.totalPlayerCubes) / (float)GenerateShape.totalPlayerCubesConstant;
            gameUI.LevelSliderFill(completedLevel);
            Debug.Log(GenerateShape.totalPlayerCubesConstant);
            Debug.Log(GenerateShape.totalPlayerCubes);
            Debug.Log(completedLevel);

        }
        if (GenerateShape.totalPlayerCubes <= 0)
        {
            level++;
            gameUI.ChangeCurrentLevelText(level);
            generateShape.texture2D = shapes[level - 1].texture;
            
            generateBoard.DestroyAllBoard();
            generateBoard.CreateNewBoard();
            generateShape.DestroyAllShapes();
            generateShape.CreateShape();

        }
    }
}
