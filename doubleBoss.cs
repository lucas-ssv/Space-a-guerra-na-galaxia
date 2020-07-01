﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doubleBoss : MonoBehaviour {

	private pontuacao pontuacao;

	public int Hp;

	public GameObject explosaoPrefab;

	//public Transform spawn1;
	//public Transform spawn2;
	public GameObject inimigo1;
	//public GameObject inimigo2;

	public int pontosGanhos;

	public GameObject loot; // soltar poções durante o jogo
	public int chanceDrop;
	public int aleatorio;

	private bool isDead = false;

	void Start () {

		pontuacao = FindObjectOfType (typeof(pontuacao)) as pontuacao;

	}

	void OnTriggerEnter2D (Collider2D col) {

		switch (col.gameObject.tag) {

		case "tiro":
			tomarDano (1);
			inimigoClone ();
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
		if (Hp <= 0 && !isDead) {
			explodir ();
		}

	}

	void explodir () {

		isDead = true;

		GameObject tempPrefab = Instantiate (explosaoPrefab) as GameObject;
		tempPrefab.transform.position = transform.position;
		tempPrefab.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
		pontuacao.pontos += pontosGanhos;

		aleatorio = Random.Range (0, 100);

		if (aleatorio <= chanceDrop) {

			GameObject tempLoot = Instantiate (loot) as GameObject;
			tempLoot.transform.position = transform.position;

		}

		WaveSpawner.EnemiesAlive--;

		Destroy (this.gameObject);

	}

	void inimigoClone () {

		GameObject tempPrefab = Instantiate (inimigo1) as GameObject;
		tempPrefab.transform.position = transform.position;
		//tempPrefab.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
		//spawnPrefab.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
		pontuacao.pontos += pontosGanhos;

		aleatorio = Random.Range (0, 100);

		if (aleatorio <= chanceDrop) {

			GameObject tempLoot = Instantiate (loot) as GameObject;
			tempLoot.transform.position = transform.position;

		}

		//Destroy (this.gameObject);

	}
}