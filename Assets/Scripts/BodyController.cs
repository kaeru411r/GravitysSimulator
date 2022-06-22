using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BodyController : MonoBehaviour
{
    static List<BodyController> _bcs = new List<BodyController>();

    const float Gravitation = 0.01f;

    [SerializeField] float _mass;

    [SerializeField] Vector2 _velocity;
    [SerializeField] bool _isTranslate;

    public float Mass { get => _mass;}

    // Start is called before the first frame update
    void Start()
    {
        _bcs.Add(this);
        BodysMethodManager.Instance.GravityCalculation += Calculation;
        if(_isTranslate)
        BodysMethodManager.Instance.BodyTranslate += Translate;
    }

    public void Calculation()
    {
        foreach(var b in _bcs)
        {
            if(b != this && b)
            {
                float dis = Vector2.Distance(transform.position, b.transform.position);
                float g = Gravitation * b.Mass / dis * dis;
                _velocity += (Vector2)(b.transform.position - transform.position).normalized * g * Time.deltaTime;
            }
        }
    }

    public void Translate()
    {
        transform.position += (Vector3)_velocity * Time.deltaTime;
    }
}
