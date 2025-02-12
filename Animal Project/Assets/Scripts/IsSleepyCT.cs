using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class IsSleepyCT : ConditionTask {


        public float energyThreshold;

        Blackboard agentBlackBoard;


        public float timer;
        private float resetTimer;



        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit()
        {

            agentBlackBoard = agent.GetComponent<Blackboard>();


            return null;
        }

        //Called whenever the condition gets enabled.
        protected override void OnEnable()
        {
            resetTimer = timer;
        }

        //Called whenever the condition gets disabled.
        protected override void OnDisable()
        {

        }

        //Called once per frame while the condition is active.
        //Return whether the condition is success or failure.
        protected override bool OnCheck()
        {
            resetTimer -= Time.deltaTime;
            float energyLevel = agentBlackBoard.GetVariableValue<float>("energy");



            if (resetTimer <= 0  && energyLevel < energyThreshold)
            {
                resetTimer = timer;
                return true;
            }

            else
            {
               
                return false;
            }

        }
    }
}