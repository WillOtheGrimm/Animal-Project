using NodeCanvas.Framework;
using NodeCanvas.Tasks.Actions;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class WaitForCT : ConditionTask {


		//to make my own timer Conditional task
		public float timer;
		private float resetTimer;



		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			resetTimer = timer;
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {



			// Timer goes down then ends the CT
			resetTimer -= Time.deltaTime;

			if (resetTimer <= 0)
			{
				return true;
			}
			else return false;

		}
	}
}