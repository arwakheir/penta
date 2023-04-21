
using UnityEngine;
using System.Collections;
using EZCameraShake;

[RequireComponent(typeof(Explodable))]
public class ExplodeOnClick : MonoBehaviour {

	private Explodable _explodable;
	private WallRespawn1 wallSpawner;
	private ExplosionForce ef;
	//public AudioSource wall;
	public AudioClip destructionSound;
	// [SerializeField] private AudioSource wall;

	void Start()
	{
		_explodable = GetComponent<Explodable>();
		ef = GetComponent<ExplosionForce>();
		wallSpawner = FindObjectOfType<WallRespawn1>();
	}
	void OnMouseDown()
	{
		//wall.Play(destructionSound);
		AudioSource.PlayClipAtPoint(destructionSound, transform.position);
		_explodable.explode();
		ExplosionForce ef = GameObject.FindObjectOfType<ExplosionForce>();
		ef.doExplosion(transform.position);
		CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);
        wallSpawner.isWallInScene = false;
		
	}

}