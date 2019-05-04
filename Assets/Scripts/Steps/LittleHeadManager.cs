﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleHeadManager : MonoBehaviour
{
    public enum WhichAbility
    {
        JUMP_HIGHER,
        FLY,
        DOUBLE_JUMP
    }
    public WhichAbility unlock;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (unlock)
        {
            case WhichAbility.JUMP_HIGHER:
                PlayerManager.s_Singleton.jumpHigher = 1000;
                break;
            case WhichAbility.FLY:
                PlayerManager.s_Singleton.fly = true;
                break;
            case WhichAbility.DOUBLE_JUMP:
                PlayerManager.s_Singleton.doubleJump = true;
                break;
            default:
                break;
        }
    }

    

}