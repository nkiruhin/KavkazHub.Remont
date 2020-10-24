using KavkazHub.Remont.ML.Configuration;
using KavkazHub.Remont.ML.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.ML;
using System;

namespace KavkazHub.Remont.ML
{
    public class RemontMLModel : IRemontMLModel
    {
        private Lazy<PredictionEngine<ModelInput, ModelOutput>> PredictionEngine;
        private IOptions<MLModelOptions> _options;
        public RemontMLModel(IOptions<MLModelOptions> options)
        {
            _options = options;
            PredictionEngine = new Lazy<PredictionEngine<ModelInput, ModelOutput>>(CreatePredictionEngine());

        }

        // For more info on consuming ML.NET models, visit https://aka.ms/mlnet-consume
        // Method for consuming model in your app
        public ModelOutput Predict(ModelInput input)
        {
            ModelOutput result = PredictionEngine.Value.Predict(input);
            return result;
        }

        private PredictionEngine<ModelInput, ModelOutput> CreatePredictionEngine()
        {
            // Create new MLContext
            MLContext mlContext = new MLContext();
            var modelPath = _options.Value.ModelPath;
            // Load model & create prediction engine
            ITransformer mlModel = mlContext.Model.Load(modelPath, out var modelInputSchema);
            var predEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);

            return predEngine;
        }
    }
}
