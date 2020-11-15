using DG.Tweening;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private FloatVariable playerScore;

    private void Start()
    {
        transform.localEulerAngles = 90 * Vector3.right;
        transform.DOLocalRotate(new Vector3(90, 360, 0), 1, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerScore.Value++;
            transform.DOKill();
            Destroy(gameObject);
        }
    }
}
