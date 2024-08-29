using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    
    Rigidbody rb;
    [Header("Player Movement Data")]
    public float speed;
    [SerializeField] Transform focalPoint;
    Vector3 startPos;
    [SerializeField] float fallLimit;

    [Header("Power up Data")]
    public bool hasRepelPower;
    public float repelForce;
    public GameObject repelIndicator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 moveDirection = new Vector3(horizontalInput, verticalInput).normalized;

        //rb.AddForce(focalPoint.forward * speed * moveDirection.y);
        //rb.AddForce(focalPoint.right * speed * moveDirection.x);

        rb.AddForce((focalPoint.forward * moveDirection.y + focalPoint.right * moveDirection.x) * speed);

        //rb.AddForce(moveDirection * speed);

        if(transform.position.y < fallLimit)
        {
            transform.position = startPos;
            rb.angularVelocity = Vector3.zero;
            rb.velocity = Vector3.zero;
            hasRepelPower = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.angularVelocity = Vector3.zero;
            rb.velocity = Vector3.zero;
        }

        repelIndicator.SetActive(hasRepelPower);
        repelIndicator.transform.position = transform.position + new Vector3(0, -0.4f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("repelPowerUp"))
        {
            StartCoroutine(PowerCooldown(10));
            Destroy(other.gameObject);
        } 
    }

   

    private void OnCollisionEnter(Collision collision)
    {
        if (hasRepelPower && collision.transform.CompareTag("Enemy"))
        {
            Rigidbody enemyRb = collision.transform.GetComponent<Rigidbody>();
            enemyRb.AddForce((collision.transform.position - transform.position).normalized * repelForce, ForceMode.Impulse);
        }
    }


    IEnumerator PowerCooldown(float waitTime)
    {
        //turn on the bool
        hasRepelPower = true;
        //waits for a particular amount of time
        yield return new WaitForSeconds(waitTime);
        //turns the bool off
        hasRepelPower = false;
    }
}
