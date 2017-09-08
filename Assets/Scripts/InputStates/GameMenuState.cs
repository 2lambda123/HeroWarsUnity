
public class GameMenuState : InputState {

   public override void HandleInput(string input, params object[] context) {
      switch (input) {
         case "optionsBtn":
            // handle
            break;
         case "saveBtn":
            // handle
            break;
         case "restartBtn":
            TransitionTo(new ConfirmChangeSceneState("restart"));
            break;
         case "quitBtn":
            TransitionTo(new ConfirmChangeSceneState("quit"));
            break;
         case "cancelBtn":
            TransitionBack();
            break;
         case "yesBtn":
            // handle
            break;
         case "noBtn":
            // handle
            break;
         default:
            base.HandleInput(input, context); 
            break;
      }
   }

   public override void Enter() {
      uiManager.gameMenu.SetActive(true);
   }

   public override void Exit() {
      uiManager.gameMenu.SetActive(false);
   }
}