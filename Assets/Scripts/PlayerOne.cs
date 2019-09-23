using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOne : MonoBehaviour
{
    public float speed;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 3.0f, 0.0f);
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void OnTriggerEnter(Collider other)
    {
         if (other.gameObject.tag == "Jump")
         {
             rb.AddForce(jump * jumpForce, ForceMode.Impulse);
             isGrounded = false;
             Debug.Log("Hit");
         }
    }


    // Update is called once per frame
    void Update()
    {

        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 p1Movement = new Vector3(hor, 0, ver);
        p1Movement = Vector3.ClampMagnitude(p1Movement, 1) * speed * Time.deltaTime;
        transform.Translate(p1Movement, Space.Self);

        if (p1Movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(p1Movement.normalized), 0.1f);
        }
    }
}
