using System;
using System.Collections.Generic;

namespace Full_GRASP_And_SOLID
{
    public class Recipe
    {
        private IList<Step> steps = new List<Step>();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        // Método CreateStep para crear un nuevo paso
        public Step CreateStep(Product input, double quantity, Equipment equipment, int time)
        {
            return new Step(input, quantity, equipment, time);
        }

        // Método GetTextToPrint para obtener la representación textual de la receta
        public string GetTextToPrint()
        {
            string result = $"Receta de {this.FinalProduct.Description}:\n";
            foreach (Step step in this.steps)
            {
                result += step.GetTextToPrint() + "\n";
            }

            result += $"Costo de producción: {this.GetProductionCost()}";
            return result;
        }

        // Método para obtener el costo de producción de la receta
        public double GetProductionCost()
        {
            double result = 0;
            foreach (Step step in this.steps)
            {
                result += step.GetStepCost();
            }
            return result;
        }
    }
}
