using UnityEngine;
using System.Collections;

namespace Player {
	public class Attack {
		private int warmup = 0;
		private int cooldown = 10;

		private int damage = 100;

		private GameObject parent;

		public Attack (GameObject parent) {
			this.parent = parent;
		}

		public bool countdown() {
			if (warmup == 0) {
				performAttack();
			}
			if (warmup <= 0) {
				cooldown--;
				if (cooldown <= 0) {
					return true;
				}
			}
			warmup--;
			return false;
		}

		private void performAttack() {

		}
	}
}