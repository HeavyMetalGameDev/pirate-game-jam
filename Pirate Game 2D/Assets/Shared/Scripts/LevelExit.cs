using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExit : MonoBehaviour
{
    bool isActive = false;
    public delegate void OnLevelOver();
    public static event OnLevelOver onLevelOver;

    private void OnEnable()
    {
        GooChamber.onGooRelease += OnGooRelease;
    }
    private void OnDisable()
    {
        GooChamber.onGooRelease -= OnGooRelease;
    }

    void OnGooRelease()
    {
        //do something
    }
}