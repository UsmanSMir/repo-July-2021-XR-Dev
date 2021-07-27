using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    [SerializeField] private float m_movementForce;
    [SerializeField] private float m_torqueForce;
    [Range(1,15)]
    [SerializeField] private float m_maxSpeed;


    [SerializeField] private float m_shootingForce;
    [SerializeField] private GameObject m_laserBolt;
    [SerializeField] private Transform m_spawnLaserBoltTransform;

    private Rigidbody m_rb;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = this.GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) //If we are holding down the W key
        {
            //Add a force in the forward direction
            m_rb.AddForce(this.transform.forward * m_movementForce, ForceMode.Impulse);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            m_rb.AddForce(this.transform.forward * -m_movementForce, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.A))
        {
            m_rb.AddForce(this.transform.right * -m_movementForce);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            m_rb.AddForce(this.transform.right * m_movementForce);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            m_rb.AddForce(this.transform.up * -m_movementForce);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            m_rb.AddForce(this.transform.up * m_movementForce);
        }

        m_rb.AddTorque(this.transform.forward * -Input.GetAxis("Mouse X") * m_torqueForce);
        m_rb.AddTorque(this.transform.right * -Input.GetAxis("Mouse Y") * m_torqueForce);

        if (m_rb.velocity.magnitude > m_maxSpeed)
        {
            m_rb.velocity = m_rb.velocity.normalized * m_maxSpeed;
        }

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject go = Instantiate(m_laserBolt, m_spawnLaserBoltTransform.position, m_spawnLaserBoltTransform.rotation);
            go.GetComponent<Rigidbody>().AddForce(go.transform.forward * m_shootingForce);
            Destroy(go, 10);
        }
    }
}
