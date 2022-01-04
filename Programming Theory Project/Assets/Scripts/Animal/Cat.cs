using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Animal
{

    public int speed = 10;
    public int jump = 5;

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
