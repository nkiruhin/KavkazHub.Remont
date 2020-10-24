using System;
using System.Collections.Generic;
using System.Text;

namespace KavkazHub.Remont.ML.Interfaces
{
    interface IRemontMLModel
    {
        public ModelOutput Predict(ModelInput input);
    }
}
