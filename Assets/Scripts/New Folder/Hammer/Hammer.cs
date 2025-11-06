using UnityEngine;

public class Hammer : MonoBehaviour, ICollectable
{
    [SerializeField] private float activeDuration = 10f;

    public void Collect(PlayerController collector)
    {
        collector.ActivateHammer(activeDuration);
        GameManager.Instance.IncreaseScore(500);
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (player != null)
        {
            Collect(player);
        }
    }
}