using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private GameObject m_asteroid;
    [SerializeField] private float m_spawningInterval = 5;

    private AudioSource m_as;
    private float m_spawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        m_spawnTimer = m_spawningInterval;
        m_as = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        m_spawnTimer -= Time.deltaTime;

        if(m_spawnTimer < 0)
        {
            m_spawnTimer = m_spawningInterval;
            GameObject go = Instantiate(m_asteroid, this.transform.position, this.transform.rotation);
            Destroy(go, m_spawningInterval - 1);
            m_as.Play();
        }
    }
}
