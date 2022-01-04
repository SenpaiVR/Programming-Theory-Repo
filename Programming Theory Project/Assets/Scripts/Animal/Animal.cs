using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public static GameObject Player;
    public static GameObject cat;
    public static GameObject dog;

    public Rigidbody playerRB;
    public bool isInAir = false;
    [SerializeField] public static float distToGround;
    public static Collider animalCollider;

    private void Awake()
    {
        Player = GameObject.Find("Player");
        dog = GameObject.Find("Dog");
        cat = GameObject.Find("Cat");

        ChooseAnimal();
    }

    private bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }

    public void Move(int speed, int jump)
    {
        float verticalMovement = Input.GetAxis("Vertical");
        Player.transform.Translate(0, 0, verticalMovement * speed * Time.deltaTime); ;

        float horizontalMovement = Input.GetAxis("Horizontal");
        Player.transform.Rotate(0, horizontalMovement, 0);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            playerRB.AddForce(Vector3.up * jump, ForceMode.Impulse);
        }
    }

    private void ChooseAnimal()
    {
        if(MainManager.Instance != null)
        {
            if (MainManager.Instance.isCat)
            {
                Destroy(dog);
            }
            else
            {
                Destroy(cat);
            }
        }
        else
        {
            Destroy(cat);
        }
    }
}
