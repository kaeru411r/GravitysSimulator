using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BodyController : MonoBehaviour
{
    static List<Transform> _trs = new List<Transform>();

    const float Gravitation = 1;

    [SerializeField] float _mass;

    Vector2 _dirction;

    public float Mass { get => _mass;}

    // Start is called before the first frame update
    void Start()
    {
        _trs.Add(transform);
    }

    public void Calculation()
    {

    }
}
