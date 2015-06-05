using UnityEngine;

/// <summary>
/// Handle hitpoints and damages
/// </summary>
public class Health : MonoBehaviour
{
	public GameObject cloudPoof;
	public GameObject shotConnect;
	/// <summary>
	/// Total hitpoints
	/// </summary>
	public int hp = 10;
	
	/// <summary>
	/// Enemy or player?
	/// </summary>
	public bool isEnemy = true;
	
	/// <summary>
	/// Inflicts damage and check if the object should be destroyed
	/// </summary>
	/// <param name="damageCount"></param>
	public void Damage(int damageCount)
	{
		hp -= damageCount;
		
		if (hp <= 0)
		{
			// Dead!
			Instantiate(cloudPoof, transform.position, transform.rotation);
			Destroy(gameObject);			
		}
	}
	
	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		// Is this a shot?
		ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
		if (shot != null)
		{
			// Avoid friendly fire
			if (shot.isEnemyShot != isEnemy)
			{
				Damage(shot.damage);
				
				// Destroy the shot
				Instantiate(shotConnect, shot.transform.position, shot.transform.rotation);
				Destroy(shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script
			}
		}
	}
}