
using Microsoft.Extensions.ML;
using static NeuroAssistWeb.TumorModel;

namespace NeuroAssistWeb.Services
{
    public class BrainscanService
    {
        private readonly PredictionEnginePool<ModelInput, ModelOutput> _predictionEnginePool;

        public BrainscanService(
            PredictionEnginePool<ModelInput, ModelOutput> predictionEnginePool
            )
        {
            _predictionEnginePool = predictionEnginePool;
        }

        public async Task<List<ModelOutput>> UploadScans(List<string> scans)
        {
            var res = new List<ModelOutput>();

            foreach (var imagePath in scans)
            {
                var input = new TumorModel.ModelInput
                {
                    ImageSource = System.IO.File.ReadAllBytes(imagePath)
                };

                var prediction = await Task.FromResult(_predictionEnginePool.Predict(input));

                res.Add(prediction);
            }

            return res;
        }

    }
}
