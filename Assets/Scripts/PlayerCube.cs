using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCube : MonoBehaviour
{
    List<GameObject> detectedShapes = new List<GameObject>();

    [SerializeField]
    private float upForce = .2f;

    [SerializeField]
    private float sideForce = .04f;

    private GenerateBoard generateBoard;

    private float minXPos, minZPos, maxXPos, maxZPos;
    private GenerateShape generateShape;

    private float cubeSize;

    public bool isCollision = false;


    private void Awake()
    {
        generateShape = GameObject.Find("ShapeGenerator").GetComponent<GenerateShape>();
        cubeSize = generateShape.Size;
        generateBoard = GameObject.Find("BoardGenerator").GetComponent<GenerateBoard>();
    }
    void Start()
    {
        minXPos = 0f;
        minZPos = 0f;
        maxXPos = generateBoard.width / cubeSize;
        maxZPos = generateBoard.height / cubeSize;
        
        float xForce = Random.Range(-sideForce, sideForce);
        float yForce = Random.Range(upForce / 2f, upForce);
        float zForce = Random.Range(sideForce /2f, sideForce);

        //Vector3 force = new Vector3(xForce, yForce, zForce);

        //GetComponent<Rigidbody>().velocity = force;
    }
    void Update()
    {
        CheckPlayerCubePosition(minXPos, minZPos, maxXPos, maxZPos);

    }

    void CheckPlayerCubePosition(float minXPos, float minZPos, float maxXPos, float maxZPos )
    {

        if(transform.position.x <= minXPos)
        {
            transform.position = new Vector3(minXPos, transform.position.y, transform.position.z);
            Vector3 force = new Vector3(sideForce,0f,0f);

            GetComponent<Rigidbody>().velocity = force;
            
        }
        if(transform.position.z <= minZPos)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, minZPos);
            Vector3 force = new Vector3(0f, 0f, sideForce);

            GetComponent<Rigidbody>().velocity = force;

        }
        if (transform.position.x >= maxXPos)
        {
            transform.position = new Vector3(maxXPos, transform.position.y,transform.position.z);
            Vector3 force = new Vector3(-sideForce, 0f, 0f);

            GetComponent<Rigidbody>().velocity = force;

        }
        if (transform.position.z>= maxZPos)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, maxZPos);
            Vector3 force = new Vector3(0f, 0f, -sideForce);

            GetComponent<Rigidbody>().velocity = force;

        }

    }

    
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "shape")
        {
            detectedShapes.Add(collision.gameObject);
            //  if (detectedShapes.Count > 1)
            // {
            //Debug.Log("hi");
            if (!isCollision)
            {
                detectedShapes.Clear();
            }

            if (isCollision)
            {
                detectedShapes[0].gameObject.GetComponent<MeshRenderer>().enabled = true;

                if (detectedShapes[0].gameObject.tag != "colored")
                {
                    GenerateShape.totalPlayerCubes--;
                }
                detectedShapes[0].gameObject.tag = "colored";

                Destroy(this.gameObject);
            }

            //}
        }
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "shape")
        {
            detectedShapes.Add(other.gameObject);
            if (detectedShapes.Count > 1)
            {
                transform.gameObject.GetComponent<BoxCollider>().isTrigger = true;
                Destroy(this.gameObject, 1.3f);
                detectedShapes[0].gameObject.GetComponent<BoxCollider>().isTrigger = false;
                detectedShapes[0].gameObject.GetComponent<MeshRenderer>().enabled = true;
            }


        }

    }
    */

}
