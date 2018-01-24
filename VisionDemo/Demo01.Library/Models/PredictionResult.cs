using Demo01.Json;
using System;
using System.Collections.Generic;

namespace Demo01.Models
{
    public class PredictionResult
    {
        internal PredictionResult(IEnumerable<Prediction> predictions)
        {
            Predictions = predictions;
            Cards = CreateCards(predictions);
        }

        private IEnumerable<CardInfo> CreateCards(IEnumerable<Prediction> predictions)
        {
            foreach (var prediction in predictions)
            {
                yield return new CardInfo(prediction.Tag);
            }
        }

        public IEnumerable<Prediction> Predictions { get; }

        public IEnumerable<CardInfo> Cards { get; }
    }
}
