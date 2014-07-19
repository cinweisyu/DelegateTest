using UnityEngine;
using System.Collections;

public class SoldierController : MonoBehaviour {
	//Dictionary<string,BaseSoldier> soldierList = new Dictionary<string, BaseSoldier>();
	// Use this for initialization
	[SerializeField]
	GameObject m_Soldier;
	[SerializeField]
	GameObject m_Group;

	string[] names = new string[]
	{

		"Arlen",
		"Cedric",
		"Frank",
		"Gary",
		"Harley",
		"Mason",
		"Oliver",
		"Richard",
		"Stanley",
		"Tommy",
	};
	void Start () 
	{
		CreateSoldier();
	}
	void CreateSoldier()
	{
		for(int i =0;i<names.Length;i++)
		{
			GameObject tmpObj = Instantiate(m_Soldier) as GameObject;
			tmpObj.transform.parent = m_Group.transform;
			tmpObj.GetComponent<BaseSoldier>().Setup(names[i],100,SaveSomeOne);
		}
	}
	void SaveSomeOne(params object[] p_param)
	{
		BaseSoldier tmpSoldier = p_param[0] as BaseSoldier;
		int tmpHp = tmpSoldier.m_Hp;
		tmpSoldier.m_Hp +=10;
		Debug.Log(string.Format("Soldier {0} be Saved. \n Hp {1} ---> {2}.",tmpSoldier.m_Name,tmpHp,tmpSoldier.m_Hp.ToString()));
	}
}
