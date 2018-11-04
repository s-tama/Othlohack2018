using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class male : MonoBehaviour {
	float vector = 1;
	float accel = 1000.0f;
	float m_power =3.0f;
	Vector3 m_powerDir;
	// Use this for initialization
	void Start () {
		m_powerDir = Vector3.forward;
	}
	
	// Update is called once per frame
	void Update () {
		
		//this.transform.position += new Vector3 (0, 0, 1);
		//vector += 1;
		//this.transform.localScale = new Vector3 (6, 4, 1);
		//this.GetComponent<Rigidbody>().AddForce(
		Rigidbody rigidbody = GetComponent<Rigidbody>();
        //rigidbody.AddForce (m_powerDir.normalized * m_power);
		rigidbody.velocity+=new Vector3(0, -0.1f, m_powerDir.z) * m_power;
		m_power -= 0.1f;
		m_power = Mathf.Max (0,m_power);

        //if(m_power <= 0)
        //{
        //    rigidbody.freezeRotation = false;
        //}

	}
			private void FixedUpdate()
	{}
				
}
