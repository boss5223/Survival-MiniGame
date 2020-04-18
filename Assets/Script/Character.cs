using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    //state
    public bool IsDeath { get; set; }
    public bool IsPlayer { get { return this.tag == "Player"; } }
    public bool IsMonster { get { return this.tag == "Monster"; } }

    //event
    public Action<Character> onAttacked;
    public Action<Character> onDie;
    public Action<Character> onDestroy;
    public Action<Character> onJump;

    //method

    protected void DeregisterEvent()
    {
        onAttacked = null;
        onDie = null;
        onDestroy = null;
        onJump = null;
    }
}

   
