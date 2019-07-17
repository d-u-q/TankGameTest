using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    private Rigidbody rb;
    [SerializeField] private int speed;
    [SerializeField] private int angSpeed;
    [SerializeField] private Rigidbody projectile;
    private Rigidbody instantiatedProjectile;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
        float rotate = Input.GetAxisRaw("Horizontal");
        float movement = Input.GetAxisRaw("Vertical");
        Move(new Vector3(rotate,0,movement));
    }
    void Move(Vector3 movement)
    {
        rb.velocity = rb.transform.right * speed * movement.z;
        rb.angularVelocity = new Vector3(0, movement.x*angSpeed, 0);
    }
 
    void Shoot()
    {
        instantiatedProjectile = Instantiate(projectile, rb.transform.position, rb.transform.rotation) as Rigidbody;
        instantiatedProjectile.velocity = rb.transform.right * 100;
        instantiatedProjectile.angularVelocity = new Vector3(100, 0, 0);
    }
}
