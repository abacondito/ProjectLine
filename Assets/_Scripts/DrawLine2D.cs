using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DrawLine2D : MonoBehaviour
{

    [SerializeField]
    protected LineRenderer m_LineRenderer;
    [SerializeField]
    protected bool m_AddCollider = true;
    [SerializeField]
    protected EdgeCollider2D m_EdgeCollider2D;
    [SerializeField]
    protected Camera m_Camera;
    [SerializeField]
    protected List<Vector2> m_Points;
    private Shader shader;
    public Material material;
    public float lineWidth = 0.05f;
    public float lineWidth2 = 0.0f;
    public GameObject prefabLine;
    GameObject line;

    public virtual LineRenderer lineRenderer
    {
        get
        {
            return m_LineRenderer;
        }
    }

    public virtual bool addCollider
    {
        get
        {
            return m_AddCollider;
        }
    }

    public virtual EdgeCollider2D edgeCollider2D
    {
        get
        {
            return m_EdgeCollider2D;
        }
    }

    public virtual List<Vector2> points
    {
        get
        {
            return m_Points;
        }
    }

    protected virtual void Awake()
    {
        Input.simulateMouseWithTouches = true;
        shader = Shader.Find("Particles/Additive");
        material = new Material(shader);        
        if (m_Camera == null)
        {
            m_Camera = Camera.main;
        }       
    }


    protected virtual void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            Reset();
           
        }
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePosition = m_Camera.ScreenToWorldPoint(Input.mousePosition);
            
                if (!m_Points.Contains(mousePosition))
                {
                    m_Points.Add(mousePosition);                   
                    m_LineRenderer.positionCount = m_Points.Count;
                    m_LineRenderer.SetPosition(m_LineRenderer.positionCount - 1, mousePosition);
                    
                    if (m_EdgeCollider2D != null && m_AddCollider && m_Points.Count > 1)
                    {
                        m_EdgeCollider2D.points = m_Points.ToArray();
                    }
                }                
        }
        if (Input.GetMouseButtonUp(0))
        {
            m_LineRenderer.startWidth = lineWidth2;
            m_LineRenderer.endWidth = lineWidth2;
            //CreateDefaultEdgeCollider2D();
            m_EdgeCollider2D.points = m_Points.ToArray();
            line.AddComponent<SelfDestroyLine>();
            m_LineRenderer.startColor = Color.cyan;
            m_LineRenderer.endColor = Color.blue;
            m_EdgeCollider2D.enabled = true;
        }
    }

    protected virtual void Reset()
    {
        line = Instantiate(prefabLine);
        CreateDefaultLineRenderer();
        m_Points = new List<Vector2>();
        CreateDefaultEdgeCollider2D();

    }

    protected virtual void CreateDefaultLineRenderer()
    {
        m_LineRenderer = line.AddComponent<LineRenderer>();
        m_LineRenderer.positionCount = 0;
        m_LineRenderer.material = material; 
        m_LineRenderer.startColor = Color.red;
        m_LineRenderer.endColor = Color.red;
        m_LineRenderer.startWidth = lineWidth;
        m_LineRenderer.endWidth = lineWidth;
        m_LineRenderer.useWorldSpace = true;
        //line.AddComponent<SelfDestroyLine>();
    }

    protected virtual void CreateDefaultEdgeCollider2D()
    {
        m_EdgeCollider2D = line.AddComponent<EdgeCollider2D>();
        m_EdgeCollider2D.enabled = false;
    }

}

