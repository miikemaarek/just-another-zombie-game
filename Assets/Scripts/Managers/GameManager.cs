﻿/**
* GameManager.cs
* Created by Michael Marek (2016)
*
* Manages all of the highest-level game logic and all other managers resonsible for running the
* game and also the entry point for the game in general.
**/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [Header("Managers")]
    public  SceneManager            sceneManager;
    public  CameraManager           cameraManager;
    public  LevelManager            levelManager;
    public  ItemManager             itemManager;

    private List<Transform>         players;


    /**
    * Aquire references to all other managers and have them initialize the game world.
    *
    * @param    null
    * @return   null
    **/
    void Awake()
    {
        if (sceneManager == null)  sceneManager = GameObject.Find("Scene Manager").GetComponent<SceneManager>();
        if (cameraManager == null) cameraManager = GameObject.Find("Camera Manager").GetComponent<CameraManager>();
        //if (levelManager == null)  levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
        if (itemManager == null)   itemManager = GameObject.Find("Item Manager").GetComponent<ItemManager>();

        sceneManager.InitializePlayers();
        cameraManager.Initialize(sceneManager.playerList);
    }


    /**
    *
    * @param    null
    * @return   null
    **/
    void Start()
    {
    }


    /**
    *
    * @param    null
    * @return   null
    **/
    void Update()
    {
    }
}
