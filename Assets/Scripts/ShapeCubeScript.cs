using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeCubeScript : MonoBehaviour
{
    List<GameObject> detectedPlayerShapes = new List<GameObject>();
    GenerateShape generateShape;
    public Texture2D texture2D;
    float xGap, zGap;
    void Start()
    {
       InvokeRepeating("ChangeColorContinuous", 2f, .3f);
        generateShape = GameObject.Find("ShapeGenerator").GetComponent<GenerateShape>();
        texture2D = generateShape.texture2D;
        xGap = generateShape.XGap;
        zGap = generateShape.ZGap;
    }

    void Update()
    {
        texture2D = generateShape.texture2D;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerCube")
        {
            detectedPlayerShapes.Add(collision.gameObject);
            if (detectedPlayerShapes[0].gameObject)
            {
               
                
                detectedPlayerShapes[0].gameObject.GetComponent<PlayerCube>().isCollision = true;
                detectedPlayerShapes.Clear();
            }
        }
    }

    void ChangeColorContinuous()
    {
        if (GenerateShape.totalPlayerCubes <= 15)
        {
            
            if (this.gameObject.tag == "shape")
            {
                this.gameObject.GetComponent<MeshRenderer>().enabled = true;
                StartCoroutine("ChangeColor");
            }
            else
            {
                int xPos = Mathf.RoundToInt((this.gameObject.transform.position.x - xGap) * 5);
                int zPos = Mathf.RoundToInt((this.gameObject.transform.position.z - zGap) * 5);
               // Debug.Log("x : " + xPos + "y : " +zPos);
                Color color = texture2D.GetPixel(xPos, zPos);
               // Debug.Log("xPos :"+xPos + "zPos:"+zPos );
                this.gameObject.GetComponent<Renderer>().material.color = color;
            }
        }
    }

    IEnumerator ChangeColor()
    {
        yield return new WaitForSeconds(.15f);
        this.gameObject.GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(.15f);
        this.gameObject.GetComponent<Renderer>().material.color = Color.black;
    }
}
