using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            GameProgress.CurrentScore++;
            Destroy(gameObject);
        }
    }
}
