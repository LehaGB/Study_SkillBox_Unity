using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 offset;


    private void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
