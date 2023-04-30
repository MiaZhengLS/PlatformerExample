using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveMode
{
    AddForce,
    Impulse,
    SetVelocity
}

public class PlayerController : MonoBehaviour
{
    public MoveMode moveMode;
    public InputController inputController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
