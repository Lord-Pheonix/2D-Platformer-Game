using UnityEngine;

public class DisableDoorScript : MonoBehaviour
{
    [SerializeField] private GameObject Door;
    [SerializeField] private Collider2D BigDoorCollider;

    public void DisableDoor()
    {
        if(Door != null)
            Door.SetActive(false);
        if(BigDoorCollider != null)
            BigDoorCollider.GetComponent<Collider2D>().enabled = false;
    }
}
