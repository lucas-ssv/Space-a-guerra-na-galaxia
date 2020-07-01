﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InimigoBoss : MonoBehaviour {

	private pontuacao pontuacao;

	public int Hp;

	public GameObject explosaoPrefab;
	public GameObject fumacaPrefab;

	public int pontosGanhos;

	public GameObject loot; // soltar poções durante o jogo
	public int chanceDrop;
	public int aleatorio;

	[Header("Unity Stuff")]
	public Image healthBar;

	void Start () {
	
		pontuacao = FindObjectOfType (typeof(pontuacao)) as pontuacao;
	
	}
		
	void OnTriggerEnter2D (Collider2D col) {
	
		switch (col.gameObject.tag) {

		case "tiro":
			tomarDano (1);
			break;

		case "Respawn":
			explodir ();
			break;

		}
	
	}

	void OnCollisionEnter2D (Collision2D col) {
	
		switch (col.gameObject.tag) {

		case "Player":
			explodir ();
			break;

		case "Respawn":
			explodir ();
			break;
		}
	
	}

	void tomarDano (int danoTomado) {
	
		Hp -= danoTomado;

		healthBar.fillAmount = Hp / 5f;

		if (Hp <= 0) {
			explodir ();
		}
	
	}

	void explodir () {

		GameObject tempPrefab = Instantiate (explosaoPrefab) as GameObject;
		tempPrefab.transform.position = transform.position;
		tempPrefab.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
		pontuacao.pontos += pontosGanhos;

		aleatorio = Random.Range (0, 100);

		if (aleatorio <= chanceDrop) {
		
			GameObject tempLoot = Instantiate (loot) as GameObject;
			tempLoot.transform.position = transform.position;

		}
			
		Destroy (this.gameObject);

	}

	void fumaca () {

		GameObject tempPrefab = Instantiate (fumacaPrefab) as GameObject;
		tempPrefab.transform.position = transform.position;
		tempPrefab.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
		pontuacao.pontos += pontosGanhos;

		aleatorio = Random.Range (0, 100);

		if (aleatorio <= chanceDrop) {

			GameObject tempLoot = Instantiate (loot) as GameObject;
			tempLoot.transform.position = transform.position;

		}

		//Destroy (this.gameObject);

	}

}
