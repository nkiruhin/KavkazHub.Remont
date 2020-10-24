using KavkazHub.Remont.ML.Interfaces;
using Microsoft.ML;
using Microsoft.VisualBasic.FileIO;
using System;

namespace KavkazHub.Remont.ML
{
    public class RemontMLModel: IRemontMLModel
    {
        private Lazy<PredictionEngine<ModelInput, ModelOutput>> PredictionEngine = new Lazy<PredictionEngine<ModelInput, ModelOutput>>(CreatePredictionEngine());

        // For more info on consuming ML.NET models, visit https://aka.ms/mlnet-consume
        // Method for consuming model in your app
        public ModelOutput Predict(ModelInput input)
        {
            ModelOutput result = PredictionEngine.Value.Predict(input);
            return result;
        }

        private static PredictionEngine<ModelInput, ModelOutput> CreatePredictionEngine()
        {
            // Create new MLContext
            MLContext mlContext = new MLContext();

            // Load model & create prediction engine
            string modelPath = @"MLModel.zip";
            ITransformer mlModel = mlContext.Model.Load(modelPath, out var modelInputSchema);
            var predEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);

            return predEngine;
        }
    }
}
