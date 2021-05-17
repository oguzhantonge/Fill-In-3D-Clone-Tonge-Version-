using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;

    Vector3 firstTouchPos = Vector3.zero;
    Vector3 deltaTouchPos = Vector3.zero;
    Vector3 direction = Vector3.zero;

    Rigidbody body;
    public float RotationSpeed = 55;
    //float angle;

    Vector3 position1, position2;

    void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       // angle += Input.GetAxis("Mouse X") * RotationSpeed * Time.deltaTime;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
       // position1 = transform.Find("position1").transform.position;
        //position2 = transform.Find("position2").transform.position;
        //float playerAngle = CalculatePlayerAngle(position1, position2);
        
    }

    void FixedUpdate()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            firstTouchPos = Input.mousePosition;
            
        }

        if (Input.GetMouseButton(0))
        {
            deltaTouchPos = Input.mousePosition - firstTouchPos;
           
            direction = new Vector3(deltaTouchPos.x, 0f, deltaTouchPos.y);

            body.velocity = direction.normalized * speed;
           
            float mouseAngle = Mathf.Atan2(deltaTouchPos.y,deltaTouchPos.x) * Mathf.Rad2Deg;
            
            position1 = transform.Find("position1").transform.position;
            position2 = transform.Find("position2").transform.position;
            //Debug.Log(CalculatePlayerAngle(position1, position2));
            float playerAngle = CalculatePlayerAngle(position1, position2);
            
            if ((int)transform.rotation.y != (int)mouseAngle)
            {
               // Debug.Log("PA" +(int)playerAngle);
                //  transform.rotation = Quaternion.Euler(0f, -(playerAngle- mouseAngle), 0f);
                Vector3 rotation = new Vector3(transform.rotation.x, mouseAngle , transform.rotation.z);
                transform.rotation = Quaternion.Euler(-rotation);
                playerAngle = CalculatePlayerAngle(position1, position2);
                //Debug.Log("PAi" + (int)playerAngle);
                //Debug.Log((int)mouseAngle);
            }
        }
        else
        {
            body.velocity = Vector3.zero;
        }
        
    }

    float CalculatePlayerAngle(Vector3 position1, Vector3 position2)
    {
        Vector3 vec = position1 - position2;
        float angle = Mathf.Atan2(vec.z, vec.x) * Mathf.Rad2Deg;
        return angle;
    }


}
