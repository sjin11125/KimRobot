using UnityEngine;
using System.Collections;

public class Break : MonoBehaviour 
{
	public Transform brokenObject;
	public float magnitudeCol, radius, power, upwards;

	public bool isBreak=false;
	Vector3 StartPos;
	void OnCollisionEnter(Collision collision)
    {
		
		/*Debug.Log("속도는 "+collision.relativeVelocity.magnitude);
		Debug.Log(collision.transform.gameObject);
		if (collision.transform.tag=="R_Hand")
		{
			Debug.Log("부딪힘");
			Destroy(gameObject);
			Instantiate(brokenObject, transform.position, transform.rotation);
			brokenObject.localScale = transform.localScale;
			Vector3 explosionPos = transform.position;
			Collider[] colliders = Physics.OverlapSphere (explosionPos, radius);

			foreach (Collider hit in colliders)
			{
				if (hit.attachedRigidbody)
				{
					hit.attachedRigidbody.AddExplosionForce(power*collision.relativeVelocity.magnitude, explosionPos, radius, upwards);
				}
			}
		}*/
	}
    private void BreakGlass() {
		Debug.Log("부딪힘");
		Destroy(gameObject);
		Instantiate(brokenObject, transform.position, transform.rotation);
		brokenObject.localScale = transform.localScale;
		Vector3 explosionPos = transform.position;
		Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

		foreach (Collider hit in colliders)
		{
			if (hit.attachedRigidbody)
			{
				hit.attachedRigidbody.AddExplosionForce(power , explosionPos, radius, upwards);
			}
		}
	}
    private void Start()
    {
		StartPos = transform.position;


	}
    private void Update()
    {
        //transform.position = StartPos;
        if (isBreak)
        {
			isBreak = false;
			BreakGlass();

		}
    }
}
