using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BodysMethodManager
{
    static private BodysMethodManager _instance = new BodysMethodManager();
    private BodysMethodManager() { }
    public static BodysMethodManager Instance { get { return _instance; } }

    public Action GravityCalculation;
    public Action BodyTranslate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
