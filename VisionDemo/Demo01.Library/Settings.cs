namespace Demo01
{
    public struct Settings
    {
        public static string ProjectId { get; } = "03c20e12-05ea-47c7-920c-c74e32514786";
        public static string ProjectName { get; } = "VisionDemo-PlayingCards";
        public static string TrainingKey { get; } = "8010f8fa08934de6a1302dd8446373ac";
        public static string PredictionKey { get; } = "c2c44ce3832f48baa34a1a792df79df2";
        public static string Endpoint { get; } = "https://southcentralus.api.cognitive.microsoft.com/customvision/v1.1/Prediction/03c20e12-05ea-47c7-920c-c74e32514786/image";

        //public static string ProjectId { get; } = "000-000";
        //public static string ProjectName { get; } = "XXX-XXX";
        //public static string TrainingKey { get; } = "000-000";
        //public static string PredictionKey { get; } = "08eeaca3d815406abae0d22e7b407dda";
        //public static string Endpoint { get; } = "https://southcentralus.api.cognitive.microsoft.com/customvision/v1.1/Prediction/ba1ec5d2-29dd-4a83-8e74-21e86a5b3bcc/image?iterationId=aa90e9ea-c2ec-40b0-979b-0b2096535409";
    }
}
