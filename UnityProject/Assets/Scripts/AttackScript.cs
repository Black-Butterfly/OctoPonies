using UnityEngine;
using UnityEditor;

public class AttackScript : MonoBehaviour
{
	public Transform Weapon;
	private float shootCooldown;
	public float timeAttack = 0.2f;

	void Start()
	{
		shootCooldown = 0f;
	}
	public void Attack(int Direction)
	{
		if(shootCooldown <= 0f && Direction != 0)
		{
			shootCooldown = timeAttack;
		}
	}
	public bool isAttacking()
	{
		return shootCooldown > 0f;
	}
	void Update()
	{
		if (shootCooldown > 0)
		{
			shootCooldown -= Time.deltaTime;
		}
	}
}