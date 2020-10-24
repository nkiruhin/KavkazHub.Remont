using KavkazHub.Remont.Core.Interfaces;
using KavkazHub.Remont.ML;
using System;
using System.Collections.Generic;
using System.Text;

namespace KavkazHub.Remont.Core.Services
{
    public class MLRemontService : IMLRemontService
    {
        private readonly RemontMLModel _model;

        public MLRemontService(RemontMLModel model)
        {
            _model = model;
        }
        public ModelOutput Predict(ModelInput input)
        {
            return _model.Predict(input);
        }
    }
}
