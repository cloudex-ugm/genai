using System;
using System.Reflection;
using Microsoft.ML;
using Microsoft.ML.Data;
using ML.NET_Sample_Code;

var context = new MLContext();

// Load data
var trainData = context.Data.LoadFromTextFile<HouseData>("C:\\ML.NET Sample Code\\ML.NET Sample Code\\Housing.csv", separatorChar: ',', hasHeader: true);

// Menampilkan schema (struktur kolom)
var schema = trainData.Schema;

Console.WriteLine("Columns in the dataset:");
foreach (var column in schema)
{
    Console.WriteLine($"Column name: {column.Name}, Column type: {column.Type}");
}


// Split data menjadi training dan testing set
var dataSplit = context.Data.TrainTestSplit(trainData, testFraction: 0.2);
var trainingData = dataSplit.TrainSet;
var testData = dataSplit.TestSet;


IEstimator<ITransformer> dataPrepEstimator =
    context.Transforms.Concatenate("Features",
        "Area", "Bedrooms", "Bathrooms", "Stories", "Mainroad", "Guestroom",
        "Basement", "Hotwaterheating", "Airconditioning", "Parking", "Prefarea")
        .Append(context.Transforms.NormalizeMinMax("Features"));



// Create data prep transformer
ITransformer dataPrepTransformer = dataPrepEstimator.Fit(trainData);

// Apply transforms to training data
IDataView transformedTrainingData = dataPrepTransformer.Transform(trainData);


// Evaluasi model menggunakan test data
var sdcaEstimator = context.Regression.Trainers.Sdca(
    labelColumnName: "Label",      // Kolom target  
    maximumNumberOfIterations: 100,  
    l2Regularization: (float?)0.01    
);

// Build machine learning model
var trainedModel = sdcaEstimator.Fit(transformedTrainingData);

IDataView transformedTestData = dataPrepTransformer.Transform(testData);

// Use trained model to make inferences on test data
IDataView testDataPredictions = trainedModel.Transform(transformedTestData);

// Extract model metrics and get RSquared
RegressionMetrics trainedModelMetrics = context.Regression.Evaluate(testDataPredictions);
double rSquared = trainedModelMetrics.RSquared;

Console.WriteLine($"R^2: {rSquared}");
Console.WriteLine($"MAE: {trainedModelMetrics.MeanAbsoluteError}");
Console.WriteLine($"RMSE: {trainedModelMetrics.RootMeanSquaredError}");







