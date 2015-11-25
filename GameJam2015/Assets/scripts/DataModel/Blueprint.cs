using System;
using System.Collections.Generic;

public class Blueprint : Item
{
   public List<BlueprintCondition> mConditions = new List<BlueprintCondition>();

   public Item mResult;

   public bool AttemptCraft(Inventory inventory)
   {
      foreach(BlueprintCondition condition in mConditions)
      {
         if(!condition.Check(inventory))
            return false;
      }
      foreach(BlueprintCondition condition in mConditions)
      {
         inventory.ChangeItemCount(condition.Name, -condition.Count);
      }
      return true;
   }

   public Blueprint(Item result)
   {
      mResult = result;
      Name = mResult.Name + " Blueprint";
   }
}

