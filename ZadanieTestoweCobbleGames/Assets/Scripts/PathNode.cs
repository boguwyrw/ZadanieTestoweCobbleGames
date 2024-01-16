using UnityEngine;

public class PathNode : MonoBehaviour
{
    [SerializeField] private MeshRenderer cudeNode;

    [SerializeField] private LayerMask walkableLayer;

    private Color32 defaultColor;
    private Color32 hoverOverColor = new Color32(253, 127, 57, 255);
    private Color32 startColor = new Color32(47, 253, 47, 255);
    private Color32 endColor = new Color32(253, 47, 47, 255);
    private Color32 markColor = new Color32(47, 47, 253, 255);

    private bool isWalkable = false;
    private bool isUnavailable = false;

    private AStarPathfinding aStarPathfinding;

    public bool IsWalkable { get { return isWalkable; } }
    public bool IsUnavailable { get { return isUnavailable; } }

    public int PositionX { get { return (int)transform.position.x; } }
    public int PositionZ { get { return (int)transform.position.z; } }
    public int GCost { get; set; }
    public int HCost { get; set; }
    public int FCost { get { return GCost + HCost; } }

    public PathNode CameFromNode { get; set; }

    private void Start()
    {
        defaultColor = cudeNode.material.color;
        aStarPathfinding = transform.parent.GetComponent<AStarPathfinding>();
        
        if (1 << gameObject.layer == walkableLayer)
        {
            isWalkable = true;
        }
    }

    public void SetDefaultColor()
    {
        cudeNode.material.color = defaultColor;
    }

    public void SetHoverOverColor()
    {
        cudeNode.material.color = hoverOverColor;
    }

    public void SetStartColor()
    {
        cudeNode.material.color = startColor;
        isUnavailable = true;
        aStarPathfinding.StartNode = this;
    }

    public void SetEndColor()
    {
        cudeNode.material.color = endColor;
        isUnavailable = true;
        aStarPathfinding.EndNode = this;
    }

    public void SetMarkColor()
    {
        cudeNode.material.color = markColor;
    }
}
