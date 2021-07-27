using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanet : MonoBehaviour
{    
    [Range(0,10)]
    [SerializeField] private float m_turnSpeed;

    [SerializeField] private Vector3 m_rotationalAxis;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(m_rotationalAxis * Time.deltaTime * m_turnSpeed);
    }
}

