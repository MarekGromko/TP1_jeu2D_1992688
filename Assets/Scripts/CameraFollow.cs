using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector2 offset;
    public float damping = 0.5f;
    void FixedUpdate()
    {
        if (this.target == null || this.target.IsDestroyed())
        {
            this.target = null;
            return;
        }
        var current = new Vector2(transform.position.x, transform.position.y);
        var target = new Vector2(this.target.position.x, this.target.position.y);
        current += (target+offset - current) * damping;
        transform.position = new Vector3(current.x, current.y, transform.position.z);
    }
}
