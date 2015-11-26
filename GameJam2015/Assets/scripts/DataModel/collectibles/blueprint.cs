using UnityEngine;
using System;
using System.Collections.Generic;

public class blueprint : Item
{
   public blueprint()
   {
      Consumable = false;
      Stackable = false;
   }

   protected override bool _Add(IDictionary<string, string> props) 
   { 
      if (!props.ContainsKey("output"))
      {
         Debug.LogError("No output property for blueprint!");
         return false;
      }

      if (!props.ContainsKey("input"))
      {
         Debug.LogError("No input property for blueprint!");
         return false;
      }

      mOutput = props["output"];
      Type elementType = Type.GetType(mOutput);
      if (elementType == null)
      {
         Debug.LogError("No c# class for output of blueprint!");
         return false;
      }

      // parse inputs...
      string inputsString = props["input"];
      string[] inputStrings = inputsString.Split(':');
      foreach (string input in inputStrings)
      {
         string[] itemAndCount = input.Split(',');
         BlueprintCondition condition = new BlueprintCondition(itemAndCount[0], int.Parse(itemAndCount[1]));
         mConditions.Add(condition);
      }
      return true; 
   }

   string mOutput;
   public List<BlueprintCondition> mConditions = new List<BlueprintCondition>();

   public bool AttemptCraft(ItemInventory inventory)
   {
      foreach (BlueprintCondition condition in mConditions)
      {
         if (!condition.Check(inventory))
            return false;
      }
      foreach (BlueprintCondition condition in mConditions)
      {
         inventory.ConsumeItem(condition.Name, condition.Count);
      }
      return true;
   }
}
