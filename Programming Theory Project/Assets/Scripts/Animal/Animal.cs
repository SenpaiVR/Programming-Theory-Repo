using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public static GameObject Player;
    public Rigidbody playerRB;
    public bool isInAir = false;
    public float feetDist = 0.01f;

    private void Awake()
    {
        Player = gameObject;
    }

    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.down);

        if (Physics.Raycast(transform.position, fwd, feetDist))
        {
            isInAir = false;
        }
        else
        {
            isInAir = true;
        }
    }

    public void Move(int speed, int jump)
    {
        float verticalMovement = Input.GetAxis("Vertical");
        Player.transform.Translate(0, 0, verticalMovement * speed * Time.deltaTime); ;

        float horizontalMovement = Input.GetAxis("Horizontal");
        Player.transform.Rotate(0, horizontalMovement, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isInAir)
            {
                playerRB.AddForce(Vector3.up * jump, ForceMode.Impulse);
            }
        }
    }
}
