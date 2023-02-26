//Date: 2/23/22
//COPYRIGHT: YOU ARE ALLOWED TO USE THIS 100% FREE FOR COMMERCIAL AND PERSONAL (just please credit [at Mythic {email: mythicgaming234@gmail.com}]).
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mythics Player Controller Stats", menuName = "New Mythics Player Stats")]//tells Unity to create object through Create Asset Menu
public class Mythics_PlayerStatsDefualtScriptable : ScriptableObject
{
	[Header("Key Binds:")]
	public KeyCode jumpKey_Stats;

	[Header("Player Parameters: ")]
	public float moveSpeed_Stats;
	public float groundDrag_Stats;//without this the player will not have drag and will feel like it is on ice:
	public float jumpForce_Stats;
	public float jumpCoolDown_Stats;
	public float airMultiplier_Stats;
	public float playerHeight_Stats;

	[Header("LayerMask: ")]
	[Tooltip("Layer for player drag and ground check:")]
	public LayerMask groundLayer_Stats;
}
