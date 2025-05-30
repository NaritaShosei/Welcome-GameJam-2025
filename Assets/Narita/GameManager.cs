﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    float _timer;
    public float Timer => _timer;

    public bool IsCountUp => _timer >= 15;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
    }
}
