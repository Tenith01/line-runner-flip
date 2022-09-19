using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class BallView : MonoBehaviour
{
    [SerializeField] private float jumpForce;

    [SerializeField] private Rigidbody rigidbody;

    // public GameObject splashPrefab;
    private void Start()
    {
        this.OnCollisionEnterAsObservable()
            .Subscribe(collision => BallHit(collision)).AddTo(this);
    }


    private void BallHit(Collision collision)
    {
        rigidbody.velocity = new Vector3(0, jumpForce, 0);

        // GameObject splash = Instantiate(splashPrefab, transform.position+new Vector3(0,-0.22f,0), Quaternion.Euler(90, 0, Random.Range(0,360)));
        // splash.transform.SetParent(collision.gameObject.transform);

        var materialName = collision.gameObject.GetComponent<MeshRenderer>().material.name;

        if (materialName == "PlatformSafe (Instance)")
        {
        }
        else if (materialName == "PlatformDanger (Instance)")
        {
            // SoundManager.instance.HitPlatformDanger();
            // gm.RestartGame();
        }
        else if (materialName == "PlatformSafe (Instance)")
        {
        }
    }
}