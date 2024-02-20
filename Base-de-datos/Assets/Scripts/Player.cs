using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header ("Movimiento")]
    [SerializeField] private int vida;
    [SerializeField] private float  speed;
    private Rigidbody  rb;
    private float posX;
    private float posZ;
    private Vector3 movimiento;




    [Header ("Jump")]
    [SerializeField] private float forceJump;
    [SerializeField] private LayerMask layer;
    [SerializeField] private bool isCollider;

    private float camRayDistance = 1000f;


    private void Awake(){
        rb = GetComponent<Rigidbody>();
    }
    

    private void Move() {
          posX = Input.GetAxis("Horizontal");
        posZ = Input.GetAxis("Vertical");

        movimiento.Set(posX, 0, posZ);
        movimiento = movimiento.normalized * speed * Time.deltaTime;
        rb.MovePosition(transform.position + movimiento);
    }

    private void Jump() {

        RaycastHit hit;
        isCollider = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 2, layer );
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.green);

        if(Input.GetKeyDown(KeyCode.Space) && isCollider)
        {
            rb.velocity = new Vector3(rb.velocity.x, forceJump, rb.velocity.z);
        }
            Debug.Log(hit.transform.name);
            Destroy(hit.transform);
    }

    private void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorhit;

        if(Physics.Raycast(camRay, out floorhit, camRayDistance, layerMask:layer))
        {
            Vector3 PlayerToMouse = floorhit.point - transform.position;
            PlayerToMouse.y = 0;
            Quaternion newRotation = Quaternion.LookRotation(PlayerToMouse);
            rb.MoveRotation(newRotation);

        }


    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKey(KeyCode.W))
        // {   
        //     transform.Translate(
        //      -speed * Time.deltaTime,
        //         0,
        //         0
        //     );
        // }   
        // if(Input.GetKey(KeyCode.S))
        // {   
        //     transform.Translate(
        //     speed * Time.deltaTime,
        //     0,
        //     0
        //     );
        // }   
        //  if(Input.GetKey(KeyCode.A))
        // {   
        //     transform.Translate(
        //     0,
        //     0,
        //     -speed * Time.deltaTime
        //     );
        // }   
        //  if(Input.GetKey(KeyCode.D))
        // {   
        //     transform.Translate(
        //     0,
        //     0,
        //     speed * Time.deltaTime
        //     );
        // }   
        Move();
        Jump();
        Turning();
      

    }
}
