using UnityEngine;

public class CamaraFollow : MonoBehaviour
{
    public Transform player;
    private float highestPoint;

    void Start()
    {
        highestPoint = player.position.y;
    }

    void Update()
    {
        if (player.position.y > highestPoint)
        {
            highestPoint = player.position.y;
            transform.position = new Vector3(
                transform.position.x,
                highestPoint,
                transform.position.z
            );
        }
    }
}
