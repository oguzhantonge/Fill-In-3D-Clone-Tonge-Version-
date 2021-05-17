using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBoard : MonoBehaviour
{
    public int width = 55;
    public int height = 88;

    [SerializeField]
    private float size = 0.2f;

    [SerializeField]
    private GameObject cube;

    GameObject boardCube;

    public static GameObject[,] board;

    void Awake()
    {
        CreateNewBoard();
    }
    private void Start()
    {
        GameObject x = GameObject.Find("BoardGenerator");
        Debug.Log(x.transform.localPosition);
    }

    public void CreateNewBoard()
    {
        board = new GameObject[width, height];
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Vector3 cubePos = new Vector3(size * j, 0.5f, size * i);
                boardCube = Instantiate(cube, transform);
                boardCube.transform.localPosition = cubePos;
                boardCube.transform.localScale = Vector3.one * size;


                board[j, i] = boardCube;
            }
        }
    }

    public void DestroyAllBoard()
    {
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (board[j,i])
                {
                    Destroy(board[j, i]);
                    board[j, i] = null;
                }
            }
        }
    }
}
