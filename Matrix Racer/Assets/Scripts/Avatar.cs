using UnityEngine;

public class Avatar : MonoBehaviour {

	public ParticleSystem shape, trail, burst, explosion;

	private Player player;

	public float deathCountdown = -1f;
	public GameObject spaceship;

	private void Awake () {
		player = transform.root.GetComponent<Player>();
		
	}

	private void OnTriggerEnter (Collider collider) {
		if (deathCountdown < 0f) {
			spaceship.SetActive(false);
			shape.enableEmission = false;
			trail.enableEmission = false;
			burst.Emit(burst.maxParticles);
			explosion.Emit(explosion.maxParticles);
			deathCountdown = burst.startLifetime;
		}
	}
	
	private void Update () {
		if (deathCountdown >= 0f) {
			deathCountdown -= Time.deltaTime;
			if (deathCountdown <= 0f) {
				spaceship.SetActive(true);
				deathCountdown = -1f;
				shape.enableEmission = true;
				trail.enableEmission = true;
				player.Die();
			}
		}
	}
}