using UnityEngine;
using UnityEditor;

public class AttackScript : MonoBehaviour
{
	public Transform Weapon;
	private float shootCooldown;
	public float timeAttack = 0.3f;

	void Start()
	{
		shootCooldown = 0f;
	}
	public void Attack(int Direction)
	{
		if(shootCooldown <= 0f && Direction != 0)
		{
			shootCooldown = timeAttack;
			var weapon = Instantiate(Weapon) as Transform;
			weapon.transform.parent = transform;
			weapon.localPosition = new Vector2(0.33f * (float)Direction, 0);

			Destroy(weapon.gameObject, timeAttack);
		}
	}
	public bool isAttacking()
	{
		return shootCooldown > 0;
	}
	void Update()
	{
		if (shootCooldown > 0)
		{
			shootCooldown -= Time.deltaTime;
		}
	}
}