using UnityEngine;

public class DestructiblePiller : MonoBehaviour
{
    [SerializeField] private GameObject destroyedPiller;

    public void DestroyPiller()
    {
        Sound_Manager.Instance.Play(AudioClips.Sfx_PillerDestruction);
        Instantiate(destroyedPiller, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
