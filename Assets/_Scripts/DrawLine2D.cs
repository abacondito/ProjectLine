using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//creates the line when the screen is touched


public class DrawLine2D : MonoBehaviour
{

    [SerializeField]
    protected LineRenderer m_LineRenderer;
    protected Rigidbody2D m_Rigidbody2d;
    [SerializeField]
    protected bool m_AddCollider = true;//bool that determines if the line will have a collider
    [SerializeField]
    protected EdgeCollider2D m_EdgeCollider2D;
    [SerializeField]
    protected Camera m_Camera;
    [SerializeField]
    protected List<Vector2> m_Points;
    private Shader shader;
    public Material material;

    public float lineWidth = 0.05f;//width of the line before solidification
    public float lineWidth2 = 0.0f;//width of the solidified line
    public GameObject prefabLine;//prefab for the line
    GameObject line;
    public Slider energySlider;//the energy bar
    public float energyRecharge=0.5f;//how much the energy recharges
    public float maxEnergy = 100.0f;

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
        Input.simulateMouseWithTouches = true;//probably not necessary

        if (m_Camera == null)
        {
            m_Camera = Camera.main;
        }       
    }


    protected virtual void Update()
    {
        if (Input.GetMouseButtonDown(0))//if screen is touched and it wasn't before
        {

            CreateNewLine();
           
        }
        if (Input.GetMouseButton(0))//the screen is touched
        {
            Vector2 mousePosition = m_Camera.ScreenToWorldPoint(Input.mousePosition);//get mouse position
            
                if (!m_Points.Contains(mousePosition))
                {
                    m_Points.Add(mousePosition);
                
                    m_LineRenderer.positionCount = m_Points.Count;
                    m_LineRenderer.SetPosition(m_LineRenderer.positionCount - 1, mousePosition);//add the new position to the current line
                    
                    if (m_EdgeCollider2D != null && m_AddCollider && m_Points.Count > 1)
                    {
                        m_EdgeCollider2D.points = m_Points.ToArray();//update collider
                    }
                }                
        }
        if (Input.GetMouseButtonUp(0))//if the touch is interrumpted
        {
            if(m_Points.Count <= energySlider.value)//check if energy is enough
            {
                //the line is made solid: the collider is activated and the rigidbody added
                m_LineRenderer.startWidth = lineWidth2;
                m_LineRenderer.endWidth = lineWidth2;
                m_EdgeCollider2D.points = m_Points.ToArray();
                energySlider.value -= m_Points.Count;//energy is subtracted
                line.AddComponent<SelfDestroyLine>();//the component for line autodestruction is added
                //add rigid body
                m_Rigidbody2d = line.AddComponent<Rigidbody2D>();
                m_Rigidbody2d.bodyType = RigidbodyType2D.Kinematic;
                m_Rigidbody2d.simulated = true;
                m_Rigidbody2d.mass = 12;
                m_Rigidbody2d.gravityScale = 0;
                //end add rigid body
                m_LineRenderer.startColor = Color.cyan;
                m_LineRenderer.endColor = Color.blue;
                m_EdgeCollider2D.enabled = true;
            }
            else//not enough energy,the line is not made solid and canceleds
            {
                m_LineRenderer.positionCount = 0;
                m_Points = new List<Vector2>();
            }
        }
    }

    protected virtual void CreateNewLine()
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
        m_LineRenderer.startColor = Color.green;
        m_LineRenderer.endColor = Color.green;
        m_LineRenderer.startWidth = lineWidth;
        m_LineRenderer.endWidth = lineWidth;
        m_LineRenderer.useWorldSpace = true;
    }
       

    protected virtual void CreateDefaultEdgeCollider2D()
    {
        m_EdgeCollider2D = line.AddComponent<EdgeCollider2D>();
        m_EdgeCollider2D.enabled = false;
    }

    private void FixedUpdate()//manages the recharge for line's energy
    {
        if((energySlider.value + energyRecharge) <= maxEnergy)
        {
            energySlider.value += energyRecharge;
        }
        else
        {
            energySlider.value = maxEnergy;
        }
        
    }
}

