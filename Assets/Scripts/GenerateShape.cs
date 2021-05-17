using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateShape : MonoBehaviour
{

    public static int texture2DWidth;
    public static int texture2DHeight;

    [SerializeField]
    private float size = 0.2f;

  //  public static float Size; // Diðer scriptlerden rahat ulaþabilmemiz için size static oldu.

    public float Size
    {
        get
        {
            return size;
        }
        set
        {
            size = value;
        }
    }

    [SerializeField]
    private GameObject cube;

    [SerializeField]
    private Sprite image;

    public Texture2D texture2D;
    Vector3 cubePos = Vector3.zero;
    GameObject cubeObj;
    Color color;

    [SerializeField]
    private float xGap = 0.1f;

    [SerializeField]
    private float zGap = 1f;

    public float XGap
    {
        get
        {
            return xGap;
        }
    }

    public float ZGap
    {
        get
        {
            return zGap;
        }
    }
    public static int totalPlayerCubes;
    public static int totalPlayerCubesConstant;

    PlayerCubeManagement playerCubeManagement;

    public GameObject[,] shapes;


    private void Awake()
    {
        
        Size = size;
        texture2D = image.texture;
        texture2DWidth = texture2D.width;
        texture2DHeight = texture2D.height;

        playerCubeManagement = GameObject.Find("PlayerCubeManagement").GetComponent<PlayerCubeManagement>();
        shapes = new GameObject[texture2DWidth, texture2DHeight];
    }

    void Start()
    {
       
        CreateShape();
    }

    public void CreateShape()
    {
        for (int i = 0; i < texture2DHeight; i++)
        {
            for (int j = 0; j < texture2DWidth; j++)
            {
                color = texture2D.GetPixel(j, i);

                if (color.a == 0)
                {
                    continue;
                }
                totalPlayerCubes++;

                GenerateBoard.board[(j + (int)(xGap * 5)), (i + (int)(zGap * 5))].SetActive(false);
                cubePos = new Vector3(size * j + xGap, 0.5f, size * i + zGap);
                cubeObj = Instantiate(cube, transform);
                cubeObj.transform.localPosition = cubePos;
                cubeObj.GetComponent<Renderer>().material.color = color;
                cubeObj.transform.localScale = Vector3.one * size;
                cubeObj.GetComponent<MeshRenderer>().enabled = false;
                shapes[j, i] = cubeObj;

            }
        }
        totalPlayerCubesConstant = totalPlayerCubes;
        playerCubeManagement.GeneratePlayerCube(totalPlayerCubes);
     
    }
    public void DestroyAllShapes()
    {
        for (int i = 0; i < texture2DHeight; i++)
        {
            for (int j = 0; j < texture2DWidth; j++)
            {
                if (shapes[j,i])
                {
                    Destroy(shapes[j, i]);
                    shapes[j, i] = null;
                }

            }
        }
    }
    
}
