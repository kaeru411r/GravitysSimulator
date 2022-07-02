using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBlain : MonoBehaviour
{
    static public GravityBlain Instance;

    [SerializeField] List<GravityGroup> _gravityGroups = new List<GravityGroup>();

    public List<GravityGroup> GravityGroups { get => _gravityGroups; set => _gravityGroups = value; }

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
    }

    private void FixedUpdate()
    {
        Calculation();
    }

    void Calculation()
    {
        foreach(var go in _gravityGroups)
        {
            foreach(var g1 in go.Bodys)
            {
                if (g1.IsFallUnder && g1.Body)
                {
                    BodyCalculation(go, g1);
                }
            }
        }
    }

    private void BodyCalculation(GravityGroup go, GravityBody g1)
    {
        foreach (var g2 in go.Bodys)
        {
            if (g2.IsExert && g2.Body && g1 != g2)
            {
                float dis = Vector2.Distance(g1.Body.transform.position, g2.Body.transform.position);
                float g = go.Gravitation * g2.Body.mass / dis * dis;
                g1.Body.velocity += (Vector2)(g2.Body.transform.position - g1.Body.transform.position).normalized * g * Time.fixedDeltaTime;
            }
        }
    }
}

[System.Serializable]
public class GravityGroup
{
    [Tooltip("万有引力定数")]
    [SerializeField] float _gravitation = 0.01f;
    [Tooltip("GravityBody")]
    [SerializeField] List<GravityBody> _bodys = new List<GravityBody>();

    public float Gravitation { get => _gravitation; set => _gravitation = value; }
    public List<GravityBody> Bodys { get => _bodys; set => _bodys = value; }

    public GravityGroup(List<GravityBody> bodys, float gravitation)
    {
        _bodys = bodys;
        _gravitation = gravitation;
    }
}

[System.Serializable]
public class GravityBody
{
    [Tooltip("オブジェクトのリジッドボディ")]
    [SerializeField] Rigidbody2D _body;
    [Tooltip("他のオブジェクトに影響を与えるか")]
    [SerializeField] bool _isExert = true;
    [Tooltip("他のオブジェクトからの影響を受けるか")]
    [SerializeField] bool _isFallUnder = true;

    /// <summary></summary>
    public Rigidbody2D Body { get => _body; set => _body = value; }
    /// <summary></summary>
    public bool IsExert { get => _isExert; set => _isExert = value; }
    /// <summary></summary>
    public bool IsFallUnder { get => _isFallUnder; set => _isFallUnder = value; }

    public GravityBody(Rigidbody2D body, bool isExert, bool isFallUnder)
    {
        _body = body;
        _isExert = isExert;
        _isFallUnder = isFallUnder;
    }

    public GravityBody(Rigidbody2D body)
    {
        _body = body;
        _isExert = true;
        _isFallUnder = true;
    }
} 
