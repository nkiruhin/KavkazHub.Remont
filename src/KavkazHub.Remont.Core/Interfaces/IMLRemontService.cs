using KavkazHub.Remont.ML;

namespace KavkazHub.Remont.Core.Interfaces
{
    public interface IMLRemontService
    {
        ModelOutput Predict(ModelInput input);
    }
}
