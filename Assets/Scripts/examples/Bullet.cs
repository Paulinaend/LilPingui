using UnityEngine;

public class Bullet : MonoBehaviour {


    [SerializeField]
    private float speed;

    [SerializeField]
    private float DestroyAfterSeconds;

    private Rigidbody rbody;
	void Awake ()
    {
        rbody = GetComponent<Rigidbody>();
        Destroy(gameObject, DestroyAfterSeconds);
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        rbody.velocity = transform.forward * speed;
	}

    private void OnTriggerEnter(Collider collision)
    {
        Destroy(gameObject);
    }


}
