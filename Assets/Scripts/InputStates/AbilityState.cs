using System.Collections.Generic;
using UnityEngine;

public class AbilityState : InputState {

   public Unit selectedUnit;

   public override void HandleInput(string input, object context) {
      switch (input) {
         case "tapRedHighlight":
            HandleRedHighlightTapped((Vector3) context);
            break;
         case "dragUnit":
            // handle
            break;
         default:
            base.HandleInput(input, context); 
            break;
      }
   }

   public void HandleRedHighlightTapped(Vector2 position) {
      Unit target = GridManager.GetUnit(position);
      if (target) {
         bool isEnemy = target.owner != BattleManager.GetCurrentPlayerIndex();
         if (isEnemy) Attack(target);
      }
   }

   public void Attack(Unit target) {
      GridManager.CalculateAttack(selectedUnit, target);
      selectedUnit.Deactivate();
      TransitionTo(new BaseState());
   }

   public override void Enter() {
      List<Vector2> coords = GridManager.GetCoordsToAttackHighlight(selectedUnit.transform.position, selectedUnit.range);
      GridManager.ShowDamageLabels(coords, selectedUnit);
      uiManager.ShowTargetUI(coords);
   }

   public override void Exit() {
      GridManager.HideDamageLabels();
      uiManager.HideTargetUI();
   }

   public AbilityState(Unit unit) {
      selectedUnit = unit;
   }
}