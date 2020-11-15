using DG.Tweening;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private FloatVariable playerScore;

    private void Start()
    {
        transform.localEulerAngles = 90 * Vector3.forward;
        transform.DOLocalRotate(new Vector3(0, 360, 90), 1, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1);
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
