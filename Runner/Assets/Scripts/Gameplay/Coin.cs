using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private FloatVariable playerScore;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerScore.Value++;
            Destroy(gameObject);
        }
    }
}
