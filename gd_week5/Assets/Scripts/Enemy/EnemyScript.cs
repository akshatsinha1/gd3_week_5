using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    Rigidbody rb;
    public float movementSpeed;
    Transform player;
    [SerializeField] float fallThreshold;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindObjectOfType<playerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce((player.position - transform.position).normalized * movementSpeed);

        if(transform.position.y < fallThreshold)
        {
            Destroy(gameObject);
        }
    }
}
