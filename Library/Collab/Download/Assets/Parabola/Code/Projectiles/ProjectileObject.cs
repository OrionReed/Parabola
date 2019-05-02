using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Projectile", menuName = "Parabola/New Projectile")]
public class ProjectileInfo : ScriptableObject {

	[SerializeField]
	enum Type {Ballistic, Guided};

	[SerializeField]
	int DamageLocal;

	[SerializeField]
	int DamageArea;

}
