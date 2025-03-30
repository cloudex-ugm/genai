# ML.NET House Price Prediction Project

This project uses **ML.NET** to predict house prices based on various features like area, bedrooms, bathrooms, etc. This step-by-step guide will help you set up and run the project in **Visual Studio**.

## Prerequisites

Before running the project, make sure you have the following installed:

- **Visual Studio 2022 or later** (with the `.NET` desktop development workload)
- **.NET SDK** (Recommended: .NET 5.0 or later)
- **ML.NET NuGet Package** for machine learning functionality

## Step-by-Step Guide

### 1. **Open the Project in Visual Studio**

1.1. First, open **Visual Studio** on your machine.  
 1.2. Click on **File > Open > Project/Solution**.  
 1.3. Navigate to the folder where the project is saved.  
 1.4. Select the **`.sln`** file (e.g., `MLNET_Sample_Code.sln`) and click **Open**.  
 1.5. Wait for Visual Studio to load the project and restore any required NuGet packages.

### 2. **Restore NuGet Packages**

Visual Studio should automatically restore the NuGet packages required by the project. If not, you can manually restore them.

2.1. Right-click on the solution in **Solution Explorer**.  
 2.2. Click on **Restore NuGet Packages** to ensure all dependencies are downloaded.

### 3. **Install ML.NET NuGet Package**

3.1. If the ML.NET package is not installed yet, go to **Tools > NuGet Package Manager > Manage NuGet Packages for Solution**.  
 3.2. Search for **`Microsoft.ML`** in the **Browse** tab and click **Install**.

### 4. **Build the Project**

4.1. To ensure everything is set up correctly, click on **Build > Build Solution** (or press `Ctrl + Shift + B`).  
 4.2. Wait for the build to complete successfully without errors.

### 5. **Update the CSV File Path (if necessary)**

The data file `Housing.csv` should be placed in the correct directory. By default, the path is hard-coded as:

```csharp
"C:\\ML.NET Sample Code\\ML.NET Sample Code\\Housing.csv"
```

5.1. Ensure the **`Housing.csv`** file is placed in the correct location on your computer.  
 5.2. If you want to change the location of the file, update the path in the code:

```csharp
var trainData = context.Data.LoadFromTextFile<HouseData>(
    "path_to_your_Housing.csv", separatorChar: ',', hasHeader: true);
```

### 6. **Run the Project**

6.1. Press **F5** or click on **Debug > Start Debugging** to run the project.  
 6.2. The console application will execute, and it will load the data, train the model, and evaluate the performance of the model. You will see output similar to this:

```
Columns in the dataset:
Column name: Price, Column type: Single
Column name: Area, Column type: Single
...
R^2: 0.6131
Root Mean Squared Error: 1029759
```

### 7. **Review the Output**

7.1. Once the project has finished running, the console will display the **R-squared (R²)** value and **Root Mean Squared Error (RMSE)**, which are the performance metrics for the regression model. These values represent how well the model performs:

- **R² (Coefficient of Determination)**: A value closer to 1.0 indicates a better fit of the model to the data.
- **RMSE (Root Mean Squared Error)**: A lower value indicates better accuracy in predictions.

This `README.md` file provides a **step-by-step guide** for anyone new to the project, from opening the solution to evaluating the model.
