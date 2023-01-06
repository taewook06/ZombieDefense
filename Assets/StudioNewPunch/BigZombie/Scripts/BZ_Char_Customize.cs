﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BZ_Char_Customize : MonoBehaviour
{
	private int bodyTyp;
	private int shirtTyp;
	private int shortsTyp;
	private Renderer skinRend;


	private BZ_AssetsList materialsList;

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
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
	public void charCustomize(int body, int top, int bottom)
	{
		materialsList = gameObject.GetComponent<BZ_AssetsList>();
		Material[] mat;
		// Set Body Type
		//		

		// Set Body and Shorts Type
		Transform curSub = gameObject.transform.Find("Geo/BigZombie");
		Transform curSubBody = gameObject.transform.Find("Geo/BigZombie/BigZombie_LOD0");
		foreach (Transform child in curSub)
		{
			//print ("Foreach loop: " + child);
			skinRend = child.gameObject.GetComponent<Renderer>();
			//skinRend.material = materialsList.SkinMaterials[top];
			skinnedMeshRenderer = curSubBody.GetComponent<SkinnedMeshRenderer>();
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
			mat = new Material[2];
			mat[0] = materialsList.ClothesMaterials[bottom];
			mat[1] = materialsList.SkinMaterials[body];
			skinRend.materials = mat;
		}


		
		//skinRend = curSub.GetComponent<Renderer>();
		

		curSub = gameObject.transform.Find("Geo/BigZombieShirt");
		foreach (Transform child in curSub)
        {
// Set ShirtType
			if (top != 4)
		{

			curSub.gameObject.SetActive(true);
			skinRend = child.GetComponent<Renderer>();


			skinRend.material = materialsList.ClothesMaterials[top];
		}
		else
		{
			curSub.gameObject.SetActive(false);

		}
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
