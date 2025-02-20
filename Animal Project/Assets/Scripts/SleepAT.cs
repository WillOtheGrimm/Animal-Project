using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class SleepAT : ActionTask {

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        private Animator animator;

        //for the time that the animation take (6 sec)
        float animationTimer = 6f;
        private float resetTimer;


        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit()
        {
            //get component reference
            animator = agent.GetComponent<Animator>();
            //reset time when it start
            resetTimer = animationTimer;




            return null;
        }

        //This is called once each time the task is enabled.
        //Call EndAction() to mark the action as finished, either in success or failure.
        //EndAction can be called from anywhere.
        protected override void OnExecute()
        {

            //Triggers this animation instantly
            animator.CrossFade("Sleep", 0);

            //EndAction(true);
        }

        //Called once per frame while the action is active.
        protected override void OnUpdate()
        {

            //Timer goes down, 
            resetTimer -= Time.deltaTime;

            if (resetTimer <= 0)
            {
                EndAction(true);
            }
        }

        //Called when the task is disabled.
        protected override void OnStop()
        {



        }

        //Called when the task is paused.
        protected override void OnPause()
        {

        }
    }
}