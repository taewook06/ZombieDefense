﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BZ_CharCustomizeBP : MonoBehaviour
{
	private int bodyTyp;
	private int shirtTyp;
	private int shortsTyp;


	private BZ_AssetsListBP materialsList;

	private SkinnedMeshRenderer skinnedMeshRenderer;

	public enum BodyType
	{
		V1,
		V2,
		V3,
		V4
	}

	public enum ShirtType
	{
		V1,
		V2,
		V3,
		V4,
		No


	}

	public enum ShortsType
	{
		V1,
		V2,
		V3,
		V4
	}

	public BodyType bodyType;
	public ShirtType shirtType;
	public ShortsType shortsType;
	public float openMouthBS;
	public float angryBS;
	public float closeLeftEyeBS;
	public float closeRightEyeBS;
	public float closeBothEyesBS;
	void Start()
    {
        
    }

	public void charCustomize(int body, int top, int bottom)
	{
		materialsList = gameObject.GetComponent<BZ_AssetsListBP>();
		Material[] mat;
		// Set Body Type
		//	
		//	
		//		
		Transform curSub = gameObject.transform.Find("BigZombieParts/Arm_L");
		Renderer skinRend = curSub.GetComponent<Renderer>();
		skinRend.material = materialsList.SkinMaterials[body];
		//
		curSub = gameObject.transform.Find("BigZombieParts/Body");
		skinRend = curSub.GetComponent<Renderer>();
		mat = new Material[2];
		mat[1] = materialsList.ClothesMaterials[bottom];
		mat[0] = materialsList.SkinMaterials[body];
		skinRend.materials = mat;
		//
		curSub = gameObject.transform.Find("BigZombieParts/Leg_L");
		skinRend = curSub.GetComponent<Renderer>();
		skinRend.material = materialsList.ClothesMaterials[bottom];
		//
		curSub = gameObject.transform.Find("BigZombieParts/Leg_R");
		skinRend = curSub.GetComponent<Renderer>();
		skinRend.material = materialsList.ClothesMaterials[bottom];
		//
		curSub = gameObject.transform.Find("BigZombieParts/Hand_L");
		skinRend = curSub.GetComponent<Renderer>();
		skinRend.material = materialsList.SkinMaterials[body];
		//
		curSub = gameObject.transform.Find("BigZombieParts/Hand_R");
		skinRend = curSub.GetComponent<Renderer>();
		skinRend.material = materialsList.SkinMaterials[body];
		//
		curSub = gameObject.transform.Find("BigZombieParts/Foot_L");
		skinRend = curSub.GetComponent<Renderer>();
		skinRend.material = materialsList.SkinMaterials[body];
		//
		curSub = gameObject.transform.Find("BigZombieParts/Foot_R");
		skinRend = curSub.GetComponent<Renderer>();
		skinRend.material = materialsList.SkinMaterials[body];
		//
		curSub = gameObject.transform.Find("BigZombieParts/Arm_R");
		skinRend = curSub.GetComponent<Renderer>();
		skinRend.material = materialsList.SkinMaterials[body];
		//
		curSub = gameObject.transform.Find("BigZombieParts/ForeArm_L");
		skinRend = curSub.GetComponent<Renderer>();
		skinRend.material = materialsList.SkinMaterials[body];
		//
		curSub = gameObject.transform.Find("BigZombieParts/ForeArm_R");
		skinRend = curSub.GetComponent<Renderer>();
		skinRend.material = materialsList.SkinMaterials[body];
		//
		curSub = gameObject.transform.Find("BigZombieParts/Knee_L");
		skinRend = curSub.GetComponent<Renderer>();
		skinRend.material = materialsList.SkinMaterials[body];
		//
		curSub = gameObject.transform.Find("BigZombieParts/Knee_R");
		skinRend = curSub.GetComponent<Renderer>();
		skinRend.material = materialsList.SkinMaterials[body];
		//
		curSub = gameObject.transform.Find("BigZombieParts/Head");
		skinnedMeshRenderer = curSub.GetComponent<SkinnedMeshRenderer>();
		skinnedMeshRenderer.SetBlendShapeWeight(0, openMouthBS);
		skinnedMeshRenderer.SetBlendShapeWeight(1, angryBS);
		float closeL = closeLeftEyeBS + closeBothEyesBS;
		if (closeL > 100f)
		{
			closeL = 100f;
		}
		float closeR = closeRightEyeBS + closeBothEyesBS;
		if (closeR > 100f)
		{
			closeR = 100f;
		}
		skinnedMeshRenderer.SetBlendShapeWeight(3, closeL);
		skinnedMeshRenderer.SetBlendShapeWeight(4, closeR);
		if (body == 1 || body == 3)
		{
			skinnedMeshRenderer.SetBlendShapeWeight(2, 100f);
		}
		else
		{
			skinnedMeshRenderer.SetBlendShapeWeight(2, 0f);
		}

		skinRend = curSub.GetComponent<Renderer>();
		skinRend.material = materialsList.SkinMaterials[body];

		// Set ShirtType
		if (top != 4)
		{
			
			
			curSub = gameObject.transform.Find("BigZombieParts/Body/BigZombie_Shirt");
			curSub.gameObject.SetActive(true);
			skinRend = curSub.GetComponent<Renderer>();
			skinRend.material = materialsList.ClothesMaterials[top];
			
			
		}
		else
		{
			
			curSub = gameObject.transform.Find("BigZombieParts/Body/BigZombie_Shirt");
			curSub.gameObject.SetActive(false);

		}

	}

	void OnValidate()
	{
		//code for In Editor customize

		bodyTyp = (int)bodyType;
		shirtTyp = (int)shirtType;
		shortsTyp = (int)shortsType;

		charCustomize(bodyTyp, shirtTyp, shortsTyp);

	}
}
