using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCubeManagement : MonoBehaviour
{
    [SerializeField]
    private GameObject playerCube;

    private GenerateShape generateShape;
    private float cubeSize;

    private void Awake()
    {
       
        generateShape = GameObject.Find("ShapeGenerator").GetComponent<GenerateShape>();
        // cubeSize = generateShape.Size;
        cubeSize = 0.125f;
    }

    public void GeneratePlayerCube(int totalCubes)
    {
        int totalCubesCount = totalCubes;
        int xwidth = 6, ywidth = 28, zwidth = 6;
        for (int y = 0; y < ywidth; y++)
        {
            for (int z = 0; z < zwidth; z++)
            {
                for (int x = 0; x < xwidth; x++)
                {
                    if (totalCubesCount == 0)
                    {
                        break;
                    }
                    GameObject cubeObj = Instantiate(playerCube, transform);
                    Vector3 cubePos = new Vector3((x - (xwidth / 2)) * cubeSize , y *cubeSize, z *cubeSize);
                    cubeObj.transform.localPosition = cubePos;
                    cubeObj.transform.localScale = new Vector3(cubeSize,cubeSize,cubeSize);
                    cubeObj.GetComponent<Renderer>().material.color = Color.green;
                    totalCubesCount--;
                }
            }
        }


    }

    
}
