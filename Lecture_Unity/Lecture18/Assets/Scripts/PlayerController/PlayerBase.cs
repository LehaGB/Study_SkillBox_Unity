using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    public static PlayerBase Instance;

    public PlayerInput playerInput;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
}
