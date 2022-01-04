using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Animal
{
    public int speed = 5;
    public int jump = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move(speed, jump);
    }
}
