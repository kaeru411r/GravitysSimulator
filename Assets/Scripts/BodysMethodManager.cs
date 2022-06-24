using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BodysMethodManager :MonoBehaviour
{
    public static BodysMethodManager Instance;

    public Action GravityCalculation;
    public Action BodyTranslate;


    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GravityCalculation();
        BodyTranslate();
    }
}
