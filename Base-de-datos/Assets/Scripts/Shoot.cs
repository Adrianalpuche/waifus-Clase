using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public int damege = 20;
    public float TiempoEntreBala = 0.15f;
    public float rango = 100f;

    private float tiempo;
    private Ray disparoRay;
    private RaycastHit disparoHit;
    private int disparableMask;
    private LineRenderer disparoLine;
    private Player _player;

    private void Awake()
    {
        disparableMask = LayerMask.GetMask("disparable");
        disparoLine = GetComponent<LineRenderer>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        tiempo += Time.deltaTime;
        if(Input.GetButton("Fire1") && tiempo >= TiempoEntreBala )
        {
            StartCoroutine(Disparo());
        }
        if(tiempo >= TiempoEntreBala * 0.2f)
        {
            disparoLine.enabled = false;
        }   
    }


    IEnumerator Disparo() 
    {
        tiempo = 0;

        yield return new WaitForSeconds(0.2f);

        disparoLine.enabled = true;

        disparoLine.SetPosition(0,new Vector3(transform.position.x, transform.position.y, transform.position.z));

        disparoRay.origin = transform.position;
        disparoRay.direction = transform.forward;

        if(Physics.Raycast(disparoRay, out disparoHit, rango, disparableMask))
        {
                //Daño al enemigo

                disparoLine.SetPosition(1,disparoHit.point);

        }
        else{
            disparoLine.SetPosition(1, disparoRay.origin + disparoRay.direction * rango);
        }

    }

}
