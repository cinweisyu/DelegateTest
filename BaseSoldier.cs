using UnityEngine;
using System.Collections;

public class BaseSoldier : MonoBehaviour {

	public delegate void CallHelp(params object[] p_param);

	string m_name;
	public string m_Name 
	{
		get{return m_name;}
	}
	int m_hp;
	public int m_Hp 
	{
		get{return m_hp;}
		set{m_hp = value;}
	}

	CallHelp m_cb;

	public void Setup(string p_name,int p_hp,CallHelp p_cb = null)
	{
		this.gameObject.SetActive(true);
		m_name = p_name;
		m_hp = p_hp;
		m_cb = p_cb;
		//test
		hurt(95);
	}
	void hurt(params object[] p_param)
	{
		int tmpDamage = (int)p_param[0];
		m_hp -= tmpDamage;
		Debug.Log(string.Format("Soldier {0} Get {1} Damage",m_Name,tmpDamage.ToString()));
		if(m_hp <=5 || m_cb != null)
			m_cb(this);
	}

}
