using UnityEngine;
using System.Collections;

public class Break : MonoBehaviour 
{
	public Transform brokenObject;
	public float magnitudeCol, radius, power, upwards;

	public bool isBreak=false;

	int num = 3;
	Vector3 StartPos;

    public GameObject WarningPannel;
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

       // StartCoroutine(Warning());
    }
    private void Update()
    {
        //transform.position = StartPos;
        if (isBreak)
        {
            StopCoroutine(Warning());
			isBreak = false;
		
				BreakGlass();
			

		}
            
    }

    IEnumerator Warning()
    {
        if (WarningPannel!=null)
        {
            while (!isBreak)
            {
                yield return new WaitForSeconds(0.6f);
                WarningPannel.SetActive(true);
                yield return new WaitForSeconds(0.6f);
                WarningPannel.SetActive(false);
            }
         
        }
   
    }
}
