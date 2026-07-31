using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isWin;

    private void OnTriggerEnter(Collider other)
    {
        if(isWin) return;

        if (!other.gameObject.CompareTag("Win"))  return;

        isWin = true;

        GameEvents.RaisePlayerWin();
        Debug.Log("Win");
    }
}
