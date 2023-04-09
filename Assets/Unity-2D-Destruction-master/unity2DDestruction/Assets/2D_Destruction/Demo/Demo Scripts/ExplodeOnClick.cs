
using UnityEngine;
using System.Collections;
using EZCameraShake;

[RequireComponent(typeof(Explodable))]
public class ExplodeOnClick : MonoBehaviour {

	private Explodable _explodable;
	private ExplosionForce ef;
	public AudioSource wall;
	void Start()
	{
		_explodable = GetComponent<Explodable>();
		ef = GetComponent<ExplosionForce>();
	}
	void OnMouseDown()
	{
		wall.Play();
		_explodable.explode();
		ExplosionForce ef = GameObject.FindObjectOfType<ExplosionForce>();
		ef.doExplosion(transform.position);
		CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);
		//Debug.Log(ef);
	}
}